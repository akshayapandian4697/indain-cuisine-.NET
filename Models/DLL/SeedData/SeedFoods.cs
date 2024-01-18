using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System;

namespace IndainCuisine.Models
{
    internal class SeedFoods : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> entity)
        {
            entity.HasData(
                new Food { FoodId = 1, Name = "Samosa", CategoryId = "appetizers", Price = 8.00, Description = "Triangular fried pastry containing spiced vegetables or meat.", ImageUrl = "/Assets/Product/Samosa.jpg" },
                new Food { FoodId = 2, Name = "Pakora", CategoryId = "appetizers", Price = 10.00, Description = "Indian fritter which contains deep-fried vegetables coated in batter.", ImageUrl = "/Assets/Product/Pakora.jpg" },
                new Food { FoodId = 3, Name = "Paneer Tikka", CategoryId = "appetizers", Price = 18.00, Description = "Paneer marinated with cashew, chili, garlic, and tomatoes grilled.", ImageUrl = "/Assets/Product/Paneer Tikka.jpg" },
                new Food { FoodId = 4, Name = "Aloo Tikki", CategoryId = "appetizers", Price = 24.00, Description = "Golden fried potato patty, stuffed with peas, chutneys.", ImageUrl = "/Assets/Product/Aloo Tikki.jpg" },
                new Food { FoodId = 5, Name = "Papadum", CategoryId = "appetizers", Price = 5.00, Description = "Indian crisps made from lentil flour.", ImageUrl = "/Assets/Product/Papadum.jpg" },
                new Food { FoodId = 6, Name = "Vegetable Cutlet", CategoryId = "appetizers", Price = 6.00, Description = "Mashed, spiced vegetable patty in Indian cuisine, dipped in batter, bread crumbs, and fried in oil.", ImageUrl = "/Assets/Product/Vegetable Cutlet.jpg" },
                new Food { FoodId = 7, Name = "Dhokla", CategoryId = "appetizers", Price = 16.00, Description = "Gujarat-based vegetarian dish, which is made with fermented gram flour batter for breakfast, main course, side dish, or snack.", ImageUrl = "/Assets/Product/Dhokla.jpg" },
                new Food { FoodId = 8, Name = "Bhaji", CategoryId = "appetizers", Price = 8.00, Description = "Fritters where fresh chilies are dipped in gram flour batter and deep fried to perfection, until crispy & aromatic.", ImageUrl = "/Assets/Product/Bhaji.jpg" },
                new Food { FoodId = 9, Name = "Seekh Kebab", CategoryId = "appetizers", Price = 4.00, Description = "Kabab made with minced beef. Flavoured with chopped ginger, chili and coriander skewered in clay oven.", ImageUrl = "/Assets/Product/Seekh Kebab.jpg" },
                new Food { FoodId = 10, Name = "Chaat", CategoryId = "appetizers", Price = 7.00, Description = "Fried dough with various ingredients that typically create a spicy, tangy, or salty flavour.", ImageUrl = "/Assets/Product/Chaat.jpeg" },

                new Food { FoodId = 11, Name = "Biryani(chicken, mutton, vegetable)", CategoryId = "main", Price = 20.00, Description = "Made with Indian spices, vegetables, rice, and meat.", ImageUrl = "/Assets/Product/Biryani.jpeg" },
                new Food { FoodId = 12, Name = "Curry(chicken, lamb, beef, vegetable)", CategoryId = "main", Price = 20.00, Description = "Composed with a gravy seasoned with a mixture of ground spices.", ImageUrl = "/Assets/Product/Curry.jpg" },
                new Food { FoodId = 13, Name = "Tikka Masala(chicken, paneer)", CategoryId = "main", Price = 20.00, Description = "Curry which is rich, tomato based sauce, mixed with onions, cream, and traditional Indian spices.", ImageUrl = "/Assets/Product/Tikka Masala.jpeg" },
                new Food { FoodId = 14, Name = "Saag(paneer, chicken, lamb)", CategoryId = "main", Price = 20.00, Description = "Green dish, served as a side dish, natural taste of spinach and mustard greens enhanced with ginger, hot peppers and lemon juice.", ImageUrl = "/Assets/Product/Saag.jpg" },
                new Food { FoodId = 15, Name = "Rogan Josh(lamb)", CategoryId = "main", Price = 20.00, Description = "Curry with thick, flavorful red sauce and tender meat.", ImageUrl = "/Assets/Product/Rogan Josh.jpg" },
                new Food { FoodId = 16, Name = "Chana Masala(chickpea curry)", CategoryId = "main", Price = 20.00, Description = "Exquisite blend of 15 spices to create the seasoning that goes into Chana.", ImageUrl = "/Assets/Product/Chana Masala.jpg" },
                new Food { FoodId = 17, Name = "Dal Makhani", CategoryId = "main", Price = 20.00, Description = "Authentic Indian dish made with black lentils and kidney beans, cooked in a rich, creamy tomato sauce.", ImageUrl = "/Assets/Product/Dal Makhani.jpg" },
                new Food { FoodId = 18, Name = "Butter Chicken", CategoryId = "main", Price = 20.00, Description = "Curry made from chicken with a spiced tomato and butter (makhan) sauce.", ImageUrl = "/Assets/Product/Butter Chicken.jpg" },
                new Food { FoodId = 19, Name = "Vindaloo(chicken, pork)", CategoryId = "main", Price = 20.00, Description = "Hot, fiery and tangy dish made with meat, vegetables and plenty of spices.", ImageUrl = "/Assets/Product/Vindaloo.jpg" },
                new Food { FoodId = 20, Name = "Korma(chicken, vegetable)", CategoryId = "main", Price = 20.00, Description = "Indian dish with braised meat or vegetables cooked with spices and cream.", ImageUrl = "/Assets/Product/Korma.jpg" },

                new Food { FoodId = 21, Name = "Naan", CategoryId = "breads", Price = 8.00, Description = "Leavened flatbread made from white flour.", ImageUrl = "/Assets/Product/Naan.jpg" },
                new Food { FoodId = 22, Name = "Roti", CategoryId = "breads", Price = 10.00, Description = "Thin flatbread made from whole wheat flour and perfect carrier for curries or cooked vegetables.", ImageUrl = "/Assets/Product/Roti.jpg" },
                new Food { FoodId = 23, Name = "Paratha(plain, stuffed)", CategoryId = "breads", Price = 18.00, Description = "Unleavened Indian wheat bread that is usually fried on a griddle.", ImageUrl = "/Assets/Product/Paratha.jpg" },
                new Food { FoodId = 24, Name = "Chapati", CategoryId = "breads", Price = 24.00, Description = "Round pieces of thin dough made from whole wheat flour.", ImageUrl = "/Assets/Product/Chapati.jpeg" },
                new Food { FoodId = 25, Name = "Puri", CategoryId = "breads", Price = 5.00, Description = "Deep-fried dough made from unleavened whole-wheat flour.", ImageUrl = "/Assets/Product/Puri.jpg" },
                new Food { FoodId = 26, Name = "Bhatura", CategoryId = "breads", Price = 6.00, Description = "Puffy, leavened, deep-fried Indian bread.", ImageUrl = "/Assets/Product/Bhatura.jpg" },

                new Food { FoodId = 27, Name = "Plain Rice", CategoryId = "rice", Price = 16.00, Description = "Steamed basmati rice.", ImageUrl = "/Assets/Product/Plain Rice.jpg" },
                new Food { FoodId = 28, Name = "Jeera Rice", CategoryId = "rice", Price = 8.00, Description = "Indian dish consisting of rice and cumin seeds.", ImageUrl = "/Assets/Product/Jeera Rice.jpg" },
                new Food { FoodId = 29, Name = "Pulao(vegetable, biryani)", CategoryId = "rice", Price = 4.00, Description = "Rice cooked with Indian spices, green peas and onions.", ImageUrl = "/Assets/Product/Pulao.jpg" },
                new Food { FoodId = 30, Name = "Lemon Rice", CategoryId = "rice", Price = 7.00, Description = "Cooked rice mixed with turmeric and lemon.", ImageUrl = "/Assets/Product/Lemon Rice.jpg" },
                new Food { FoodId = 31, Name = "Coconut Rice", CategoryId = "rice", Price = 8.00, Description = "White rice cooked in a base of coconut milk and combined with shredded coconut.", ImageUrl = "/Assets/Product/Coconut Rice.jpg" },

                new Food { FoodId = 32, Name = "Raita", CategoryId = "sidedishes", Price = 10.00, Description = "Condiment dip made up of onions and cucumbers that is served as a side.", ImageUrl = "/Assets/Product/Raita.jpg" },
                new Food { FoodId = 33, Name = "Pickles(mango, lime, mixed)", CategoryId = "sidedishes", Price = 18.00, Description = "Flavorful condiment made from fresh green mangoes/lemons.", ImageUrl = "/Assets/Product/Pickles.jpg" },
                new Food { FoodId = 34, Name = "Papadum", CategoryId = "sidedishes", Price = 24.00, Description = "Indian crisps made from lentil flour", ImageUrl = "/Assets/Product/Papadum.jpg" },
                new Food { FoodId = 35, Name = "Chutney(mint, tamarind, coconut)", CategoryId = "sidedishes", Price = 5.00, Description = "Savory condiment made from slow-cooked fruits or vegetables, vinegar, and spices.", ImageUrl = "/Assets/Product/Chutney.jpg" },

                new Food { FoodId = 36, Name = "Gulab Jamun", CategoryId = "desserts", Price = 6.00, Description = "Spongy milk balls soaked in a light sugar syrup.", ImageUrl = "/Assets/Product/Gulab Jamun.jpg" },
                new Food { FoodId = 37, Name = "Jalebi", CategoryId = "desserts", Price = 16.00, Description = "Deep-fried wheat/maida flour batter in pretzel or circular shapes, which are then soaked in sugar syrup.", ImageUrl = "/Assets/Product/Jalebi.jpg" },
                new Food { FoodId = 38, Name = "Rasgulla", CategoryId = "desserts", Price = 8.00, Description = "Syrupy dessert made from ball-shaped dumplings of chhena dough, cooked in light sugar syrup.", ImageUrl = "/Assets/Product/Rasgulla.jpg" },
                new Food { FoodId = 39, Name = "Kheer(rice pudding)", CategoryId = "desserts", Price = 4.00, Description = "Sweet pudding made by boiling milk, sugar or jaggery, and rice.", ImageUrl = "/Assets/Product/Kheer.jpg" },
                new Food { FoodId = 40, Name = "Gajar Halwa(carrot halwa)", CategoryId = "desserts", Price = 7.00, Description = "Combination of nuts, milk, sugar, khoya and ghee with grated carrots.", ImageUrl = "/Assets/Product/Gajar Halwa.jpg" },
                new Food { FoodId = 41, Name = "Malai Kulfi", CategoryId = "desserts", Price = 8.00, Description = "Frozen dairy dessert made as ice-cream.", ImageUrl = "/Assets/Product/Malai Kulfi.jpg" },
                new Food { FoodId = 42, Name = "Rasmalai", CategoryId = "desserts", Price = 10.00, Description = "Made of white cream, sugar, milk, and cardamom-flavored paneer cheese.", ImageUrl = "/Assets/Product/Rasmalai.jpg" },
                new Food { FoodId = 43, Name = "Barfi(various flavors)", CategoryId = "desserts", Price = 18.00, Description = "Sweet confectionery made from condensed milk and sugar, flavored with nuts and spices.", ImageUrl = "/Assets/Product/Barfi.jpg" },

                new Food { FoodId = 44, Name = "Chai(Indian tea)", CategoryId = "beverages", Price = 24.00, Description = "Aromatic beverage that blends black tea with various herbs and spices.", ImageUrl = "/Assets/Product/Chai.jpg" },
                new Food { FoodId = 45, Name = "Lassi(sweet, salted, mango)", CategoryId = "beverages", Price = 5.00, Description = "Creamy, frothy yogurt-based drink, blended with water and various fruits or seasonings.", ImageUrl = "/Assets/Product/Lassi.jpg" },
                new Food { FoodId = 46, Name = "Masala Chai", CategoryId = "beverages", Price = 6.00, Description = "Milky, sweet, spiced-filled black tea.", ImageUrl = "/Assets/Product/Masala Chai.jpg" },
                new Food { FoodId = 47, Name = "Nimbu Pani(lemonade)", CategoryId = "beverages", Price = 16.00, Description = "Spiced lemonade.", ImageUrl = "/Assets/Product/Nimbu Pani.jpg" },
                new Food { FoodId = 48, Name = "Thandai", CategoryId = "beverages", Price = 8.00, Description = "Drink made with fennel seeds, melon seeds and almonds.", ImageUrl = "/Assets/Product/Thandai.jpg" }

                );
        }
    }

}
