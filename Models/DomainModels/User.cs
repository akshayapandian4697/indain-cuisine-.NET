using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace IndainCuisine.Models
{
    public class User : IdentityUser
    {
        [NotMapped]
        public IList<string>? Role { get; set; }
    }
}
