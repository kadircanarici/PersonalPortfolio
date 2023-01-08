using Microsoft.AspNetCore.Mvc;
using PersonalPortfolio.Data;
using PersonalPortfolio.Models;
using System.Diagnostics;

namespace PersonalPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult GetIntros()
        {
            List<Intro> Intros = _db.Intros.ToList();
            return Json(Intros);
        }
        
        public IActionResult GetAboutMe()
        {
            List<AboutMe> ab = _db.AboutMe.ToList();
            return Json(ab);
        }
        public IActionResult GetSkills()
        {
            List<Skill> list=_db.skills.ToList();
            return Json(list);
        }








        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}