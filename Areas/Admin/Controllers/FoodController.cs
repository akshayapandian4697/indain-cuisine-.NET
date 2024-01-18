using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IndainCuisine.Models;
using Microsoft.AspNetCore.Hosting;


namespace IndainCuisine.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class FoodController : Controller
    {
        private IndianCusineUnitOfWork FoodStore { get; set; }

        private readonly IWebHostEnvironment _webHostEnvironment;

        public FoodController(IWebHostEnvironment webHostEnvironment, IndianCusineContext indianCuisineRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            FoodStore = new IndianCusineUnitOfWork(indianCuisineRepository);
        }

        public ViewResult Index()
        {
            var search = new SearchData(TempData);
            search.Clear();
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Search(SearchViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Search");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ViewResult Search()
        {
            var search = new SearchData(TempData);

            if (search.HasSearchTerm)
            {
                var vm = new SearchViewModel
                {
                    SearchTerm = search.SearchTerm
                };
                var options = new QueryOptions<Food>
                {
                    Include = "Category"
                };
                vm.Foods = FoodStore.foods.List(options);
                return View("SearchResults", vm);
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet]
        public ViewResult Add(int id) => GetFood(id, "Add");

        [HttpPost]
        public IActionResult Add(FoodViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                if (vm.food.ImageFile != null && vm.food.ImageFile.Length > 0)
                {
                    var fileName = Path.GetFileName(vm.food.ImageFile.FileName);
                    var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Assets", "Product");
                    var path = Path.Combine(uploadsFolder, fileName);
                    vm.food.ImageUrl = "/Assets/Product/" + fileName;
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        vm.food.ImageFile.CopyToAsync(stream);
                    }
                }
                FoodStore.foods.Insert(vm.food);
                FoodStore.Save();

                TempData["message"] = $"{vm.food.Name} added to Food section.";
                return RedirectToAction("Index");

            }
            else
            {
                Load(vm, "Add");
                return View("Food", vm);
            }
        }
        [HttpGet]
        public IActionResult UploadImage()
        {
            return View();
        }



        [HttpGet]
        public ViewResult Edit(int id) => GetFood(id, "Edit");

        [HttpPost]
        public IActionResult Edit(FoodViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                if (vm.food.ImageFile != null && vm.food.ImageFile.Length > 0)
                {
                    var fileName = Path.GetFileName(vm.food.ImageFile.FileName);
                    var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Assets", "Product");
                    var path = Path.Combine(uploadsFolder, fileName);
                    vm.food.ImageUrl = "/Assets/Product/" + fileName;
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        vm.food.ImageFile.CopyToAsync(stream);
                    }
                }
                FoodStore.foods.Update(vm.food);
                FoodStore.Save();
                TempData["message"] = $"{vm.food.Name} updated.";
                return RedirectToAction("Search");
            }
            else
            {
                Load(vm, "Edit");
                return View("Food", vm);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id) => GetFood(id, "Delete");

        [HttpPost]
        public IActionResult Delete(FoodViewModel vm)
        {
            FoodStore.foods.Delete(vm.food);
            FoodStore.Save();
            TempData["message"] = $"{vm.food.Name} removed from Food items.";
            return RedirectToAction("Search");
        }

        private ViewResult GetFood(int id, string operation)
        {
            var food = new FoodViewModel();
            Load(food, operation, id);
            return View("Food", food);

        }
        private void Load(FoodViewModel vm, string op, int? id = null)
        {
            if (Operation.IsAdd(op))
            {
                vm.food = new Food();
            }
            else
            {
                vm.food = FoodStore.foods.Get(new QueryOptions<Food>
                {
                    Include = "Category",
                    Where = b => b.FoodId == (id ?? vm.food.FoodId)
                });
            }
            vm.Categories = FoodStore.categories.List(new QueryOptions<Category>
            {
                OrderBy = g => g.Name
            });
        }

    }
}