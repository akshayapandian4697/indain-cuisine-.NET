using IndainCuisine.Models;
using Microsoft.AspNetCore.Mvc;

namespace IndainCuisine.Controllers
{
    public class FoodController : Controller
    {
        private IndianCusineUnitOfWork data { get; set; }
        public FoodController(IndianCusineContext ctx) => data = new IndianCusineUnitOfWork(ctx);

        public RedirectToActionResult Index() => RedirectToAction("List");

        public ViewResult List(FoodGridDTO values)
        {
            var builder = new FoodGridBuilder(HttpContext.Session, values,
                defaultSortField: nameof(Food.Name));

            var options = new IndianCusineQueryOptions
            {
                Include = "Category",
                OrderByDirection = builder.CurrentRoute.SortDirection,
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize
            };
            options.SortFilter(builder);

            var vm = new FoodListViewModel
            {
                Foods = data.foods.List(options),
                Categories = data.categories.List(new QueryOptions<Category>
                {
                    OrderBy = g => g.Name
                }),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.foods.Count)
            };

            return View(vm);
        }

        public ViewResult Details(int id)
        {
            var food = data.foods.Get(new QueryOptions<Food>
            {
                Include = "Category",
                Where = b => b.FoodId == id
            });
            return View(food);
        }
    }
}