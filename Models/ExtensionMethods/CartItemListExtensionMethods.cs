using System.Linq;
using System.Collections.Generic;

namespace IndainCuisine.Models
{
    public static class CartItemListExtensions
    {
        public static List<CartItemDTO> ToDTO(this List<CartItem> list) =>
            list.Select(ci => new CartItemDTO {
                FoodId = ci.Food.FoodId,
                Quantity = ci.Quantity
            }).ToList();
    }
}
