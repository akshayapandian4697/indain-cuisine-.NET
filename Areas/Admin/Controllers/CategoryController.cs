using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IndainCuisine.Models;
using Microsoft.AspNetCore.Hosting.Server;

namespace IndainCuisine.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private  IWebHostEnvironment _webHostEnvironment;
        private Repository<Category> data { get; set; }
        public CategoryController(IndianCusineContext context, IWebHostEnvironment webHostEnvironment)
        {
            data = new Repository<Category>(context);
            _webHostEnvironment = webHostEnvironment;
        }


        
        public ViewResult Index()
        {
            var search = new SearchData(TempData);
            search.Clear();

            var categories = data.List(new QueryOptions<Category> {
                OrderBy = g => g.Name
            });
            return View(categories);
        }

        [HttpGet]
        public ViewResult Add() => View("Category", new Category());

        [HttpPost]
        public IActionResult Add(Category category)
        {
            var validate = new Validate(TempData);
            if (!validate.IsCategoryChecked) {
                validate.CheckCategory(category?.CategoryId, data);
                if (!validate.IsValid) {
                    ModelState.AddModelError(nameof(category.CategoryId), validate.ErrorMessage);
                }     
            }

            if (!ModelState.IsValid) {
                if (category.ImageFile != null && category.ImageFile.Length > 0)
                {
                    var fileName = Path.GetFileName(category.ImageFile.FileName);
                    var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Assets", "Category");
                    var path = Path.Combine(uploadsFolder, fileName);
                    category.ImagePath = "/Assets/Category/" + fileName;
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        category.ImageFile.CopyToAsync(stream);
                    }
                }
                data.Insert(category);
                data.Save();
                validate.ClearCategory();
                TempData["message"] = $"{category.Name} added to Categories.";
                return RedirectToAction("Index");  
            }
            else {
                return View("Category", category);
            }
        }

        [HttpGet]
        public ViewResult Edit(string id) => View("Category", data.Get(id));

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid) {
                if (category.ImageFile != null && category.ImageFile.Length > 0)
                {
                    var fileName = Path.GetFileName(category.ImageFile.FileName);
                    var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Assets", "Category");
                    var path = Path.Combine(uploadsFolder, fileName);
                    category.ImagePath = "/Assets/Category/"+fileName;
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        category.ImageFile.CopyToAsync(stream);
                    }
                }
                data.Update(category);
                data.Save();
                TempData["message"] = $"{category.Name} updated.";
                return RedirectToAction("Index");  
            }
            else {
                return View("Category", category);
            }
        }

        [HttpGet]
        public IActionResult Delete(string id) {
            var categories = data.Get(new QueryOptions<Category> {
                Include = "Foods",
                Where = g => g.CategoryId == id
            });

            if (categories.Foods.Count > 0) {
                TempData["message"] = $"Can't delete Category {categories.Name} " 
                                    + "because it's associated with these Foods.";
                return GoToFoodSearchResults(id);
            }
            else {
                return View("Category", categories);
            }
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            data.Delete(category);
            data.Save();
            TempData["message"] = $"{category.Name} removed from Categories.";
            return RedirectToAction("Index");        }

        public RedirectToActionResult ViewFoods(string id) => GoToFoodSearchResults(id);

        private RedirectToActionResult GoToFoodSearchResults(string id)
        {
            var search = new SearchData(TempData) {
                SearchTerm = id,
                Type = "category"
            };
            return RedirectToAction("Search", "Food");
        }

    }
}