using Microsoft.AspNetCore.Mvc;

namespace ECommercePro.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
