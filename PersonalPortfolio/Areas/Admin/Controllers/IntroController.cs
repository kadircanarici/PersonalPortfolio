using Microsoft.AspNetCore.Mvc;
using PersonalPortfolio.Data;
using PersonalPortfolio.Models;

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
        public IActionResult GetAll()
        {
            List<Intro> intros = _db.Intros.Where(i => i.IsActive == true && i.IsDeleted == false).ToList<Intro>();
            return Json(new { data = intros });
        }
        public IActionResult GetByID(Guid id)
        {
            Intro intro = _db.Intros.Find(id);
            return Json(intro);
        }
        [HttpPost]
        public IResult Edit(Intro intro)
        {
            Intro asil = _db.Intros.Find(intro.Id);
            asil.TitleStart = intro.TitleStart;
            asil.TitleMidLine = intro.TitleMidLine;
            asil.TitleEnd = intro.TitleEnd;
            asil.Content = intro.Content;

            _db.Intros.Update(asil);
            _db.SaveChanges();

            return Results.Ok("basarılı");

        }
    }
}
