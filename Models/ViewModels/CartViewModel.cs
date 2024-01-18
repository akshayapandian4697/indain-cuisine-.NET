using System.Collections.Generic;

namespace IndainCuisine.Models
{
    public class CartViewModel 
    {
        public IEnumerable<CartItem> List { get; set; }
        public double Subtotal { get; set; }
        public RouteDictionary FoodGridRoute { get; set; }
    }
}
