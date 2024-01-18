using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace IndainCuisine.Models
{
    public class Validate
    {
        private const string CategoryKey = "validCategory";
        private const string EmailKey = "validEmail";

        private ITempDataDictionary tempData { get; set; }
        public Validate(ITempDataDictionary temp) => tempData = temp;

        public bool IsValid { get; private set; }
        public string ErrorMessage { get; private set; }

        public void CheckCategory(string categoryId, Repository<Category> data)
        {
            Category entity = data.Get(categoryId);
            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" : 
                $"Category id {categoryId} is already in the database.";
        }
        public void ClearCategory() => tempData.Remove(CategoryKey);
        public bool IsCategoryChecked => tempData.Keys.Contains(CategoryKey);

    }
}
