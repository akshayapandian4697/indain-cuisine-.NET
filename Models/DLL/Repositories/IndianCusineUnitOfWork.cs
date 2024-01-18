using IndainCuisine.Models.DomainModels;
using System.Linq;

namespace IndainCuisine.Models
{
    public class IndianCusineUnitOfWork : IIndianCusineUnitOfWork
    {
        private IndianCusineContext _context { get; set; }
        // Initializing an instance of IndianCusineUnitOfWork by assigning the provided IndianCusineContext (ctx) to the context field.
        public IndianCusineUnitOfWork(IndianCusineContext context)
        {
            _context = context;
        }

        private Repository<Food> foodList;
        //return a list of food items 
        public Repository<Food> foods {
            get {
                if (foodList == null)
                    foodList = new Repository<Food>(_context);
                return foodList;
            }
        }
        private Repository<Category> categoryList;
        public Repository<Category> categories
        {
            get {
                if (categoryList == null)
                    categoryList = new Repository<Category>(_context);
                return categoryList;
            }
        }
		private Repository<UserDetails> userDetailList;
		public Repository<UserDetails> userdetails
		{
			get
			{
				if (userDetailList == null)
					userDetailList = new Repository<UserDetails>(_context);
				return userDetailList;
			}
		}
		public void Save()
        {
            _context.SaveChanges();
        } 
    }
}