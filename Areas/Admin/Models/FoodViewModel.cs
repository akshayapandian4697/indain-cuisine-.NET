using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndainCuisine.Models
{
    public class FoodViewModel : IValidatableObject
    {
        public Food food { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
