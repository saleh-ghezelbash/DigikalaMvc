using System.Threading.Tasks;
using Digikala.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Digikala.ViewComponents
{
    public class ShowSubCategoryComponent : ViewComponent
    {
        ICategoryService _categoryservice;
        public ShowSubCategoryComponent(ICategoryService categoryService)
        {
            _categoryservice = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return await Task.FromResult(View("ShowsubCategory", _categoryservice.GetSubCategoryById(id)));
        }
    }
}
