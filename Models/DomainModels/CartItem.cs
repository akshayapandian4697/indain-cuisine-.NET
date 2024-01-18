using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace IndainCuisine.Models
{
    public class CartItem
    {
        public FoodDTO? Food { get; set; }
        public int Quantity { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public double Subtotal => Food.Price * Quantity;
    }
}
