using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalPortfolio.Data;
using PersonalPortfolio.Models;

namespace PersonalPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EducationController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EducationController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles ="Admin")]
        public IActionResult GetAll()
        {
            return Json(new {data= _db.Education.Where(e=>e.IsActive==true && e.IsDeleted==false).ToList() });
        }
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public IActionResult Add(Education education)
        {
            _db.Education.Add(education);
            _db.SaveChanges();
            return Json(education);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult GetById(Guid id)
        {
            Education education = _db.Education.Find(id);
            return Json(education);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IResult Edit(Education education)
        {
            Education asil = _db.Education.Find(education.Id);
            asil.Year = education.Year;
            asil.Name = education.Name;
            asil.Description = education.Description;
            _db.Education.Update(asil);
            _db.SaveChanges();
            return Results.Ok("basarılı");

        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            Education education = _db.Education.Find(id);
            if(education!=null)
            {
                education.IsDeleted=true;
                _db.SaveChanges();

            }
            return Json(education);
        }


    }
}
