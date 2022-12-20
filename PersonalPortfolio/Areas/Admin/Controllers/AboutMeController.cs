using Microsoft.AspNetCore.Mvc;

namespace PersonalPortfolio.Areas.Admin.Controllers
{
    public class AboutMeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
