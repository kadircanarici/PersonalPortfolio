using Microsoft.AspNetCore.Mvc;

namespace PersonalPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class IntroPhotoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
