using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IndainCuisine.Migrations
{
    /// <inheritdoc />
    public partial class Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CardName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    ExpireDate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SecurityNumber = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.FoodId);
                    table.ForeignKey(
                        name: "FK_Foods_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { "appetizers", "Discover a tantalizing array of bite-sized wonders that ignite your appetite and elevate your dining experience with our diverse collection of appetizers.", "/Assets/Category/appetizers.jpg", "Appetizers" },
                    { "beverages", "Quench your thirst and tantalize your taste buds with our diverse selection of beverages, ranging from refreshing classics to innovative and exotic concoctions.", "/Assets/Category/beverages.jpg", "Beverages" },
                    { "breads", "Indulge in the comforting world of freshly baked breads, where aroma, flavor, and texture unite to create a symphony of wholesome goodness", "/Assets/Category/breads.jpg", "Breads" },
                    { "desserts", "Satisfy your sweet cravings and conclude your meal on a delightful note with our array of irresistible and beautifully crafted side desserts.", "/Assets/Category/appetizers.jpg", "Desserts" },
                    { "main", "Savor the heart of every meal with our exquisite selection of main courses, where culinary mastery transforms the finest ingredients into unforgettable dining moments.", "/Assets/Category/maincourses.jpg", "Main Courses" },
                    { "rice", "Explore the global tapestry of flavors woven through our rice dishes, offering a diverse palette of grains transformed into delectable culinary art.", "/Assets/Category/rice.jpg", "Rice" },
                    { "sidedishes", "Elevate your meal with our thoughtfully curated side dishes, designed to complement and enhance the main flavors while adding a touch of culinary sophistication.", "/Assets/Category/sidedishes.jpg", "Side Dishes" }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "FoodId", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "appetizers", "Triangular fried pastry containing spiced vegetables or meat.", "/Assets/Product/Samosa.jpg", "Samosa", 8.0 },
                    { 2, "appetizers", "Indian fritter which contains deep-fried vegetables coated in batter.", "/Assets/Product/Pakora.jpg", "Pakora", 10.0 },
                    { 3, "appetizers", "Paneer marinated with cashew, chili, garlic, and tomatoes grilled.", "/Assets/Product/Paneer Tikka.jpg", "Paneer Tikka", 18.0 },
                    { 4, "appetizers", "Golden fried potato patty, stuffed with peas, chutneys.", "/Assets/Product/Aloo Tikki.jpg", "Aloo Tikki", 24.0 },
                    { 5, "appetizers", "Indian crisps made from lentil flour.", "/Assets/Product/Papadum.jpg", "Papadum", 5.0 },
                    { 6, "appetizers", "Mashed, spiced vegetable patty in Indian cuisine, dipped in batter, bread crumbs, and fried in oil.", "/Assets/Product/Vegetable Cutlet.jpg", "Vegetable Cutlet", 6.0 },
                    { 7, "appetizers", "Gujarat-based vegetarian dish, which is made with fermented gram flour batter for breakfast, main course, side dish, or snack.", "/Assets/Product/Dhokla.jpg", "Dhokla", 16.0 },
                    { 8, "appetizers", "Fritters where fresh chilies are dipped in gram flour batter and deep fried to perfection, until crispy & aromatic.", "/Assets/Product/Bhaji.jpg", "Bhaji", 8.0 },
                    { 9, "appetizers", "Kabab made with minced beef. Flavoured with chopped ginger, chili and coriander skewered in clay oven.", "/Assets/Product/Seekh Kebab.jpg", "Seekh Kebab", 4.0 },
                    { 10, "appetizers", "Fried dough with various ingredients that typically create a spicy, tangy, or salty flavour.", "/Assets/Product/Chaat.jpeg", "Chaat", 7.0 },
                    { 11, "main", "Made with Indian spices, vegetables, rice, and meat.", "/Assets/Product/Biryani.jpeg", "Biryani(chicken, mutton, vegetable)", 20.0 },
                    { 12, "main", "Composed with a gravy seasoned with a mixture of ground spices.", "/Assets/Product/Curry.jpg", "Curry(chicken, lamb, beef, vegetable)", 20.0 },
                    { 13, "main", "Curry which is rich, tomato based sauce, mixed with onions, cream, and traditional Indian spices.", "/Assets/Product/Tikka Masala.jpeg", "Tikka Masala(chicken, paneer)", 20.0 },
                    { 14, "main", "Green dish, served as a side dish, natural taste of spinach and mustard greens enhanced with ginger, hot peppers and lemon juice.", "/Assets/Product/Saag.jpg", "Saag(paneer, chicken, lamb)", 20.0 },
                    { 15, "main", "Curry with thick, flavorful red sauce and tender meat.", "/Assets/Product/Rogan Josh.jpg", "Rogan Josh(lamb)", 20.0 },
                    { 16, "main", "Exquisite blend of 15 spices to create the seasoning that goes into Chana.", "/Assets/Product/Chana Masala.jpg", "Chana Masala(chickpea curry)", 20.0 },
                    { 17, "main", "Authentic Indian dish made with black lentils and kidney beans, cooked in a rich, creamy tomato sauce.", "/Assets/Product/Dal Makhani.jpg", "Dal Makhani", 20.0 },
                    { 18, "main", "Curry made from chicken with a spiced tomato and butter (makhan) sauce.", "/Assets/Product/Butter Chicken.jpg", "Butter Chicken", 20.0 },
                    { 19, "main", "Hot, fiery and tangy dish made with meat, vegetables and plenty of spices.", "/Assets/Product/Vindaloo.jpg", "Vindaloo(chicken, pork)", 20.0 },
                    { 20, "main", "Indian dish with braised meat or vegetables cooked with spices and cream.", "/Assets/Product/Korma.jpg", "Korma(chicken, vegetable)", 20.0 },
                    { 21, "breads", "Leavened flatbread made from white flour.", "/Assets/Product/Naan.jpg", "Naan", 8.0 },
                    { 22, "breads", "Thin flatbread made from whole wheat flour and perfect carrier for curries or cooked vegetables.", "/Assets/Product/Roti.jpg", "Roti", 10.0 },
                    { 23, "breads", "Unleavened Indian wheat bread that is usually fried on a griddle.", "/Assets/Product/Paratha.jpg", "Paratha(plain, stuffed)", 18.0 },
                    { 24, "breads", "Round pieces of thin dough made from whole wheat flour.", "/Assets/Product/Chapati.jpeg", "Chapati", 24.0 },
                    { 25, "breads", "Deep-fried dough made from unleavened whole-wheat flour.", "/Assets/Product/Puri.jpg", "Puri", 5.0 },
                    { 26, "breads", "Puffy, leavened, deep-fried Indian bread.", "/Assets/Product/Bhatura.jpg", "Bhatura", 6.0 },
                    { 27, "rice", "Steamed basmati rice.", "/Assets/Product/Plain Rice.jpg", "Plain Rice", 16.0 },
                    { 28, "rice", "Indian dish consisting of rice and cumin seeds.", "/Assets/Product/Jeera Rice.jpg", "Jeera Rice", 8.0 },
                    { 29, "rice", "Rice cooked with Indian spices, green peas and onions.", "/Assets/Product/Pulao.jpg", "Pulao(vegetable, biryani)", 4.0 },
                    { 30, "rice", "Cooked rice mixed with turmeric and lemon.", "/Assets/Product/Lemon Rice.jpg", "Lemon Rice", 7.0 },
                    { 31, "rice", "White rice cooked in a base of coconut milk and combined with shredded coconut.", "/Assets/Product/Coconut Rice.jpg", "Coconut Rice", 8.0 },
                    { 32, "sidedishes", "Condiment dip made up of onions and cucumbers that is served as a side.", "/Assets/Product/Raita.jpg", "Raita", 10.0 },
                    { 33, "sidedishes", "Flavorful condiment made from fresh green mangoes/lemons.", "/Assets/Product/Pickles.jpg", "Pickles(mango, lime, mixed)", 18.0 },
                    { 34, "sidedishes", "Indian crisps made from lentil flour", "/Assets/Product/Papadum.jpg", "Papadum", 24.0 },
                    { 35, "sidedishes", "Savory condiment made from slow-cooked fruits or vegetables, vinegar, and spices.", "/Assets/Product/Chutney.jpg", "Chutney(mint, tamarind, coconut)", 5.0 },
                    { 36, "desserts", "Spongy milk balls soaked in a light sugar syrup.", "/Assets/Product/Gulab Jamun.jpg", "Gulab Jamun", 6.0 },
                    { 37, "desserts", "Deep-fried wheat/maida flour batter in pretzel or circular shapes, which are then soaked in sugar syrup.", "/Assets/Product/Jalebi.jpg", "Jalebi", 16.0 },
                    { 38, "desserts", "Syrupy dessert made from ball-shaped dumplings of chhena dough, cooked in light sugar syrup.", "/Assets/Product/Rasgulla.jpg", "Rasgulla", 8.0 },
                    { 39, "desserts", "Sweet pudding made by boiling milk, sugar or jaggery, and rice.", "/Assets/Product/Kheer.jpg", "Kheer(rice pudding)", 4.0 },
                    { 40, "desserts", "Combination of nuts, milk, sugar, khoya and ghee with grated carrots.", "/Assets/Product/Gajar Halwa.jpg", "Gajar Halwa(carrot halwa)", 7.0 },
                    { 41, "desserts", "Frozen dairy dessert made as ice-cream.", "/Assets/Product/Malai Kulfi.jpg", "Malai Kulfi", 8.0 },
                    { 42, "desserts", "Made of white cream, sugar, milk, and cardamom-flavored paneer cheese.", "/Assets/Product/Rasmalai.jpg", "Rasmalai", 10.0 },
                    { 43, "desserts", "Sweet confectionery made from condensed milk and sugar, flavored with nuts and spices.", "/Assets/Product/Barfi.jpg", "Barfi(various flavors)", 18.0 },
                    { 44, "beverages", "Aromatic beverage that blends black tea with various herbs and spices.", "/Assets/Product/Chai.jpg", "Chai(Indian tea)", 24.0 },
                    { 45, "beverages", "Creamy, frothy yogurt-based drink, blended with water and various fruits or seasonings.", "/Assets/Product/Lassi.jpg", "Lassi(sweet, salted, mango)", 5.0 },
                    { 46, "beverages", "Milky, sweet, spiced-filled black tea.", "/Assets/Product/Masala Chai.jpg", "Masala Chai", 6.0 },
                    { 47, "beverages", "Spiced lemonade.", "/Assets/Product/Nimbu Pani.jpg", "Nimbu Pani(lemonade)", 16.0 },
                    { 48, "beverages", "Drink made with fennel seeds, melon seeds and almonds.", "/Assets/Product/Thandai.jpg", "Thandai", 8.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_CategoryId",
                table: "Foods",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
