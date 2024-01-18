using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using IndainCuisine.Models.DomainModels;

namespace IndainCuisine.Models
{
    public class IndianCusineContext : IdentityDbContext<User>
    {
        public IndianCusineContext(DbContextOptions<IndianCusineContext> options)
            : base(options)
        { }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }

		public DbSet<UserDetails> UserDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new SeedCategory());
            modelBuilder.ApplyConfiguration(new SeedFoods());


			modelBuilder.Entity<UserDetails>(entity =>
			{
				entity.ToTable("UserDetails");

				entity.Property(e => e.FirstName)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.LastName)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.Email)
					.IsRequired()
					.HasMaxLength(100);

				entity.Property(e => e.UserName)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.Address)
					.IsRequired()
					.HasMaxLength(200);

				entity.Property(e => e.Country)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.CardName)
					.IsRequired()
					.HasMaxLength(100);

				entity.Property(e => e.CardNumber)
					.IsRequired()
					.HasMaxLength(16);

				entity.Property(e => e.SecurityNumber)
					.IsRequired()
					.HasMaxLength(3);

				entity.Property(e => e.ExpireDate)
					.IsRequired()
					.HasMaxLength(100);
			});
		}

        public static async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string adminUsername = "admin";
            string adminPassword = "Admin";
            string adminRoleName = "Admin";

            if (await roleManager.FindByNameAsync(adminRoleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(adminRoleName));
            }
            if (await userManager.FindByNameAsync(adminUsername) == null)
            {
                User adminUser = new User { UserName = adminUsername };
                var creationResult = await userManager.CreateAsync(adminUser, adminPassword);
                if (creationResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, adminRoleName);
                }
            }
        }

    }
}