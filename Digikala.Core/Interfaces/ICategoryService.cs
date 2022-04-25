using System;
using System.Collections.Generic;
using System.Text;
using Digikala.Core.ViewModels.Category;
using Digikala.DataLayer.Entities.Category;

namespace Digikala.Core.Interfaces
{
    public interface ICategoryService
    {
        Category GetCategoryByName(string catname);
        List<Category> GetSubCategoryById(int parentid);
        ShowCategoriesForUserViewModel GetSubCategoryByName(string catname);
        List<CategoryForBrandViewModel> GetCategoryByBrandID(int brandid);

    }
}
