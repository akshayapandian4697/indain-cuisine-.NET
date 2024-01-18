using Microsoft.AspNetCore.Http;

namespace IndainCuisine.Models
{
    public class FoodGridBuilder : GridBuilder
    {
        public FoodGridBuilder(ISession sess) : base(sess) { }

        public FoodGridBuilder(ISession sess, FoodGridDTO values, 
            string defaultSortField) : base(sess, values, defaultSortField)
        {
            bool isInitial = values.Category.IndexOf(FilterPrefix.Category) == -1;
            routes.CategoryFilter = (isInitial) ? FilterPrefix.Category + values.Category : values.Category;
            routes.PriceFilter = (isInitial) ? FilterPrefix.Price + values.Price : values.Price;
        }

        public void LoadFilterSegments(string[] filter)
        {
            routes.CategoryFilter = FilterPrefix.Category + filter[1];
            routes.PriceFilter = FilterPrefix.Price + filter[2];
        }
        public void ClearFilterSegments() => routes.ClearFilters();

        string def = FoodGridDTO.DefaultFilter;   
        public bool IsFilterByCategory => routes.CategoryFilter != def;
        public bool IsFilterByPrice => routes.PriceFilter != def;

        public bool IsSortByCategory =>
            routes.SortField.EqualsNoCase(nameof(Category));
        public bool IsSortByPrice =>
            routes.SortField.EqualsNoCase(nameof(Food.Price));
    }
}
