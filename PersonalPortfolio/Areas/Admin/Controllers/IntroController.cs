using Microsoft.AspNetCore.Mvc;
using PersonalPortfolio.Data;

namespace PersonalPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class IntroController : Controller
    {
        private readonly ApplicationDbContext _db;
        public IntroController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
