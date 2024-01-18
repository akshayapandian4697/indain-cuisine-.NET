using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IndainCuisine.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndainCuisine.Models
{
    public class Category
    {
        [MaxLength(10)]
        [Required(ErrorMessage = "Please enter a category id.")]
        [Remote("CheckCategory", "Validation", "Area")]
        public string? CategoryId { get; set; }
        
        [StringLength(25)]
        [Required(ErrorMessage = "Please enter a category.")]
        public string? Name { get; set; }


        [StringLength(int.MaxValue)]
        [Required(ErrorMessage = "Please enter a description.")]
        public string? Description { get; set; }

        [StringLength(int.MaxValue)]
        public string? ImagePath { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        public ICollection<Food>? Foods { get; set; }
    }
}