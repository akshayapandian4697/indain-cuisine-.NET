using Newtonsoft.Json;

namespace IndainCuisine.Models
{
    public class FoodGridDTO : GridDTO
    {
        [JsonIgnore]
        public const string DefaultFilter = "all";
        public string Category { get; set; } = DefaultFilter;
        public string Price { get; set; } = DefaultFilter;
        public string Description { get; set; } = DefaultFilter;
        public string ImageUrl { get; set; } = DefaultFilter;
    }
}
