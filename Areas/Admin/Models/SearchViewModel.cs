using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IndainCuisine.Models
{
    public class SearchViewModel
    {
        public IEnumerable<Food> Foods { get; set; }
        [Required(ErrorMessage = "Please enter a search term.")]
        public string SearchTerm { get; set; }
        public string Header { get; set; }
    }
}
