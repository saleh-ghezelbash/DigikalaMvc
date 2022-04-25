using Digikala.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digikala.ViewComponents
{
    public class ShowCategoryForBrandComponent:ViewComponent
    {
        ICategoryService _categoryservice;
        public ShowCategoryForBrandComponent(ICategoryService categoryService)
        {
            _categoryservice = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return await Task.FromResult(View("ShowCategoryForBrand", _categoryservice.GetCategoryByBrandID(id)));
        }
    }
}
