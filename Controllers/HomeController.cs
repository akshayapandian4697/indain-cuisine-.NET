using IndainCuisine.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace IndainCuisine.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IndianCusineUnitOfWork data { get; set; }
        public HomeController(ILogger<HomeController> logger, IndianCusineContext context)
        {
            data = new IndianCusineUnitOfWork(context);
            _logger = logger;

        }

        public IActionResult Index()
        {
            var vm = new FoodListViewModel
            {
                Categories = data.categories.List(new QueryOptions<Category>
                {
                    OrderBy = g => g.Name
                })
            };

            return View(vm);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}