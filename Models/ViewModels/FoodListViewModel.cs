using System.Collections.Generic;

namespace IndainCuisine.Models
{
    public class FoodListViewModel 
    {
        public IEnumerable<Food> Foods { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<Category> Categories { get; set; }
       
    }
}
