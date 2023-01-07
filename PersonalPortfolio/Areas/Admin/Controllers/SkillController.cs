using Microsoft.AspNetCore.Mvc;
using PersonalPortfolio.Data;
using PersonalPortfolio.Data.Migrations;
using PersonalPortfolio.Models;
using System.Linq;

namespace PersonalPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SkillController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            return Json(new { data = _db.skills.Where(s => s.IsActive == true && s.IsDeleted == false).ToList() }); ;
        }
        public IActionResult Add(Skill skill)
        {
            _db.skills.Add(skill);
            _db.SaveChanges();
            return Json(skill);
        }
        public IActionResult GetById(Guid id)
        {
            Skill skill = _db.skills.Find(id);
            return Json(skill);
        }
        public IActionResult Delete(Guid id)
        {
            Skill skll = _db.skills.Find(id);
            if(skll!=null)
            {
                skll.IsDeleted = true;
                _db.skills.Update(skll);
                _db.SaveChanges();

            }
            return Json(skll);
        }
    }
}
