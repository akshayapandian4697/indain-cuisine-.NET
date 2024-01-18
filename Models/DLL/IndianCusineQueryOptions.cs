using System.Linq;

namespace IndainCuisine.Models
{
    public class IndianCusineQueryOptions : QueryOptions<Food>
    {
        public void SortFilter(FoodGridBuilder builder)
        {
            if (builder.IsFilterByCategory) {
                Where = b => b.CategoryId == builder.CurrentRoute.CategoryFilter;
            }
            if (builder.IsSortByCategory) {
                OrderBy = b => b.Category.Name;
            }
            else if (builder.IsSortByPrice) {
                OrderBy = b => b.Price;
            }
            else  {
                OrderBy = b => b.Name;
            }
        }
    }
}
