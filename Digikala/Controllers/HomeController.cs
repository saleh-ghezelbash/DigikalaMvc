using Digikala.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Digikala.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
