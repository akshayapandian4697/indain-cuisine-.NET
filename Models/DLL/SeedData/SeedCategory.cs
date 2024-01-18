using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndainCuisine.Models
{
    internal class SeedCategory : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasData(
                new Category { CategoryId = "appetizers", Name = "Appetizers",Description= "Discover a tantalizing array of bite-sized wonders that ignite your appetite and elevate your dining experience with our diverse collection of appetizers.", ImagePath= "/Assets/Category/appetizers.jpg" },
                new Category { CategoryId = "main",Name="Main Courses", Description = "Savor the heart of every meal with our exquisite selection of main courses, where culinary mastery transforms the finest ingredients into unforgettable dining moments." ,ImagePath = "/Assets/Category/maincourses.jpg" },
                new Category { CategoryId = "breads", Name = "Breads", Description = "Indulge in the comforting world of freshly baked breads, where aroma, flavor, and texture unite to create a symphony of wholesome goodness", ImagePath = "/Assets/Category/breads.jpg" },
                new Category { CategoryId = "rice", Name = "Rice", Description = "Explore the global tapestry of flavors woven through our rice dishes, offering a diverse palette of grains transformed into delectable culinary art.", ImagePath = "/Assets/Category/rice.jpg" },
                new Category { CategoryId = "sidedishes", Name = "Side Dishes", Description = "Elevate your meal with our thoughtfully curated side dishes, designed to complement and enhance the main flavors while adding a touch of culinary sophistication.", ImagePath = "/Assets/Category/sidedishes.jpg" },
                new Category { CategoryId = "desserts", Name = "Desserts", Description = "Satisfy your sweet cravings and conclude your meal on a delightful note with our array of irresistible and beautifully crafted side desserts.", ImagePath = "/Assets/Category/appetizers.jpg" },
                new Category { CategoryId = "beverages", Name = "Beverages", Description = "Quench your thirst and tantalize your taste buds with our diverse selection of beverages, ranging from refreshing classics to innovative and exotic concoctions.", ImagePath = "/Assets/Category/beverages.jpg" }
            );
        }
    }

}
