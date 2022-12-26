using Microsoft.AspNetCore.Mvc;
using PersonalPortfolio.Data;
using PersonalPortfolio.Models;

namespace PersonalPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class IntroPhotoController : Controller
    {

        private readonly ApplicationDbContext _db;
        public IntroPhotoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Get()
        {
           IntroPhoto introphotos = _db.introPhotos.FirstOrDefault(i => i.IsActive == true && i.IsDeleted == false);
            return Json(introphotos);
        }
        //public IResult Edit(VehicleColor vehicleColor)
        //{
        //    VehicleColor asil = _db.VehicleColors.Find(vehicleColor.Id);

        //    asil.Name = vehicleColor.Name;

        //    _db.VehicleColors.Update(asil);
        //    _db.SaveChanges();

        //    return Results.Ok("başarılı");
        //}
    }
}