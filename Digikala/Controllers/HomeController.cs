using Digikala.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Digikala.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;

        public HomeController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public IActionResult Index()
        {
            return View(_sliderService.GetSliderForMain());
        }
    }
}
