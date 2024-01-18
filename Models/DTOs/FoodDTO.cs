using System.Collections.Generic;

namespace IndainCuisine.Models
{
    public class FoodDTO
    {
        public int FoodId { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public void Load(Food food)
        {
            FoodId = food.FoodId;
            Name = food?.Name;
            Price = food.Price;
            Description = food?.Description;
            ImageUrl= food?.ImageUrl;
        }
    }

}
