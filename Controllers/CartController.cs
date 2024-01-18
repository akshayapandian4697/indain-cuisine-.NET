using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IndainCuisine.Models;
using Microsoft.AspNetCore.Identity;
using IndainCuisine.Models.DomainModels;
using IndainCuisine.Models.ViewModels;

namespace IndainCuisine.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private Repository<Food> data { get; set; }
        private Repository<UserDetails> customerDetails { get; set; }

        public CartController(IndianCusineContext context)
        {
            data = new Repository<Food>(context);
            customerDetails = new Repository<UserDetails>(context);
        }
        private Cart GetCart()
        {
            var cart = new Cart(HttpContext);
            cart.Load(data);
            return cart;
        }

        public ViewResult Index()
        {
            var cart = GetCart();
            var builder = new FoodGridBuilder(HttpContext.Session);

            var vm = new CartViewModel
            {
                List = cart.List,
                Subtotal = cart.Subtotal,
                FoodGridRoute = builder.CurrentRoute
            };
            return View(vm);
        }

        [HttpPost]
        public RedirectToActionResult Add(int id)
        {
            var foods = data.Get(new QueryOptions<Food>
            {
                Include = "Category",
                Where = b => b.FoodId == id
            });
            if (foods == null)
            {
                TempData["message"] = "Unable to add food items in the cart.";
            }
            else
            {
                var dto = new FoodDTO();
                dto.Load(foods);
                CartItem item = new CartItem
                {
                    Food = dto,
                    Quantity = 1
                };

                Cart cart = GetCart();
                cart.Add(item);
                cart.Save();
                TempData["message"] = $"{foods.Name} added to cart";
            }

            var builder = new FoodGridBuilder(HttpContext.Session);
            return RedirectToAction("List", "Food", builder.CurrentRoute);
        }

        [HttpPost]
        public RedirectToActionResult Remove(int id)
        {
            Cart cart = GetCart();
            CartItem item = cart.GetById(id);
            cart.Remove(item);
            cart.Save();

            TempData["message"] = $"{item?.Food?.Name} removed from cart.";
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> OrderConfirmation(UserDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserDetails
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.UserName,
                    Address = model.Address,
                    Country = model.Country,
                    CardName = model.CardName,
                    CardNumber = model.CardNumber,
                    SecurityNumber = model.SecurityNumber,
                    ExpireDate = model.ExpireDate
                };
                customerDetails.Insert(user);
                customerDetails.Save();
                Clear();
                return RedirectToAction("OrderConfirmation", "Cart");
            }
            else
            {
                return View("Checkout",model);
            }
          
        }

        public ViewResult OrderConfirmation()
        {
            return View();
        }


        public ViewResult Checkout()
        {
            return View();
        }


        [HttpPost]
        public RedirectToActionResult Clear()
        {
            Cart cart = GetCart();
            cart.Clear();
            cart.Save();

            TempData["message"] = "Cart cleared.";
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            Cart cart = GetCart();
            CartItem item = cart.GetById(id);
            if (item == null)
            {
                TempData["message"] = "Unable to locate cart item";
                return RedirectToAction("List");
            }
            else
            {
                return View(item);
            }
        }

        [HttpPost]
        public RedirectToActionResult Edit(CartItem item)
        {
            Cart cart = GetCart();
            cart.Edit(item);
            cart.Save();

            TempData["message"] = $"{item?.Food?.Name} updated";
            return RedirectToAction("Index");
        }

    }
}