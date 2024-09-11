using Microsoft.AspNetCore.Mvc;

namespace ProductService.Api.Controllers.V1
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
