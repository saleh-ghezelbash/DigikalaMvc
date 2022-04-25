using Digikala.Core.Interfaces;
using Digikala.DataLayer.Entities.Brand;
using Microsoft.AspNetCore.Mvc;

namespace Digikala.Controllers
{
    public class HomeController : Controller
    {
        ICategoryService _categoryService;
         IBrandService _brandService;
        public HomeController(ICategoryService categoryService, IBrandService brandService)
        {
            _categoryService = categoryService;
             _brandService = brandService;
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

        [Route("brand/{brandtitle}")]
        public IActionResult Brand(string brandtitle)
        {
           
            Brand brand = _brandService.GetBrandByName(brandtitle);
            if (brand != null)
                return View(brand);
            return View("~/views/error/PageNotFound.cshtml");
        }
    }
}
