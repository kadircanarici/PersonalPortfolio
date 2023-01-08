using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalPortfolio.Data;
using PersonalPortfolio.Data.Migrations;
using PersonalPortfolio.Models;
using System.Data;
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
        [Authorize(Roles = "Admin")]

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]

        public IActionResult GetAll()
        {
            return Json(new { data = _db.skills.Where(s => s.IsActive == true && s.IsDeleted == false).ToList() }); ;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(Skill skill)
        {
            _db.skills.Add(skill);
            _db.SaveChanges();
            return Json(skill);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult GetById(Guid id)
        {
            Skill skill = _db.skills.Find(id);
            return Json(skill);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IResult Edit(Skill skill)
        {
            Skill asil = _db.skills.Find(skill.Id);
            asil.Column = skill.Column;
            asil.Name = skill.Name;
            _db.skills.Update(asil);
            _db.SaveChanges();

            return Results.Ok("basarılı");
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
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
