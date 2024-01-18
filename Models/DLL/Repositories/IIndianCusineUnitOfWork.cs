using IndainCuisine.Models.DomainModels;

namespace IndainCuisine.Models
{
    public interface IIndianCusineUnitOfWork
    {
        Repository<Food> foods { get; }
        Repository<Category> categories { get; }
        Repository<UserDetails> userdetails { get; }

		void Save();
    }
}
