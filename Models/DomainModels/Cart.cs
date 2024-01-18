using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace IndainCuisine.Models
{
    public class Cart
    {
        private const string CartKey = "mycart";
        private const string CountKey = "mycount";

        private List<CartItem> items { get; set; }
        private List<CartItemDTO> storedItems { get; set; }

        private ISession session { get; set; }
        private IRequestCookieCollection requestCookies { get; set; }
        private IResponseCookies responseCookies { get; set; }


        public Cart(HttpContext ctx)
        {
            session = ctx.Session;
            requestCookies = ctx.Request.Cookies;
            responseCookies = ctx.Response.Cookies;
            items = new List<CartItem>();
        }

        public void Load(Repository<Food> food)
        {
            items = session.GetObject<List<CartItem>>(CartKey);
            if (items == null) {
                items = new List<CartItem>();
                storedItems = requestCookies.GetObject<List<CartItemDTO>>(CartKey);
            }
            if (storedItems?.Count > items?.Count) {
                foreach (CartItemDTO storedItem in storedItems) {
                    var foodItems = food.Get(new QueryOptions<Food> {
                        Include = "Category",
                        Where = b => b.FoodId == storedItem.FoodId
                    });
                    if (foodItems != null) {
                        var dto = new FoodDTO();
                        dto.Load(foodItems);

                        CartItem item = new CartItem {
                            Food = dto,
                            Quantity = storedItem.Quantity
                        };
                        items.Add(item);
                    }
                }
                Save();
            }
        }

        public double Subtotal => items.Sum(i => i.Subtotal);
        public int? Count => session.GetInt32(CountKey) ?? requestCookies.GetInt32(CountKey);
        public IEnumerable<CartItem> List => items;

        public CartItem GetById(int id) => 
            items.FirstOrDefault(ci => ci.Food.FoodId == id);

       public void Add(CartItem item) {
            var itemInCart = GetById(item.Food.FoodId);
           
            if (itemInCart == null) {
                items.Add(item);
            }
            else {  
                itemInCart.Quantity += 1;
            }
        }

        public void Edit(CartItem item)
        {
            var itemInCart = GetById(item.Food.FoodId);
            if (itemInCart != null) {
                itemInCart.Quantity = item.Quantity;
            }
        }

        public void Remove(CartItem item) => items.Remove(item);
        public void Clear() => items.Clear();
        
        public void Save() {
            if (items.Count == 0) {
                session.Remove(CartKey);
                session.Remove(CountKey);
                responseCookies.Delete(CartKey);
                responseCookies.Delete(CountKey);
            }
            else {
                session.SetObject(CartKey, items);
                session.SetInt32(CountKey, items.Count);
                responseCookies.SetObject(CartKey, items.ToDTO());
                responseCookies.SetInt32(CountKey, items.Count);
            }
        }
    }
}
