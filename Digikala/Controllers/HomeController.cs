using Digikala.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Digikala.Controllers
{
    public class HomeController : Controller
    {
        ICategoryService _categoryService;
        public HomeController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("main/{catname}")]
        public IActionResult Category(string catname)
        {
            var categories = _categoryService.GetSubCategoryByName(catname);
            if (categories == null || categories.categories.Count <= 0)
                return View("~/views/error/PageNotFound.cshtml");

            return View(categories);
        }
    }
}
