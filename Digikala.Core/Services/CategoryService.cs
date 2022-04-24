using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Digikala.Core.Interfaces;
using Digikala.Core.ViewModels.Category;
using Digikala.DataLayer.Context;
using Digikala.DataLayer.Entities.Category;

namespace Digikala.Core.Services
{
    public class CategoryService : ICategoryService
    {
        DigikalaContext _context;
        public CategoryService(DigikalaContext context)
        {
            _context = context;
        }


        public Category GetCategoryByName(string catname)
        {
            return _context.Categories.FirstOrDefault(c => c.EnTitle == catname);
        }

        public List<Category> GetSubCategoryById(int parentid)
        {
            List<Category> categories = (from c in _context.Categories
                                         join s in _context.SubCategories
                                         on c.CategoryId equals s.SubId
                                         where s.ParentId == parentid
                                         select c).ToList();
            return categories;
        }

        public ShowCategoriesForUserViewModel GetSubCategoryByName(string catname)
        {
            Category category = GetCategoryByName(catname);
            if (category == null)
                return null;

            ShowCategoriesForUserViewModel showCategoriesvm = new ShowCategoriesForUserViewModel
            {
                FaTitle = category.FaTitle,
                categories = GetSubCategoryById(category.CategoryId)
            };
            return showCategoriesvm;
        }


    }
}
