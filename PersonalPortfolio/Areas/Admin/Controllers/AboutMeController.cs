using Microsoft.AspNetCore.Mvc;
using PersonalPortfolio.Data;
using PersonalPortfolio.Models;

namespace PersonalPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutMeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AboutMeController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            List<AboutMe> aboutMes=_db.AboutMe.Where(a=>a.IsActive==true && a.IsDeleted == false).ToList<AboutMe>();
            return Json(new { data = aboutMes });
        }
        [HttpPost]
        public IResult Edit(AboutMe aboutMe)
        {
            AboutMe asil = _db.AboutMe.Find(aboutMe.Id);
            asil.Title = aboutMe.Title;
            asil.CurvedText = aboutMe.CurvedText;
            asil.Description = aboutMe.Description;
            asil.ImagePath = aboutMe.ImagePath;
            _db.AboutMe.Update(asil);
            _db.SaveChanges();
            return Results.Ok("basarılı");
        }
        public IActionResult GetById(Guid id)
        {
            AboutMe aboutMe = _db.AboutMe.Find(id);
            return Json(aboutMe);
        }
    }
}
