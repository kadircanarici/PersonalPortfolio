using Microsoft.AspNetCore.Mvc;
using PersonalPortfolio.Data;
using PersonalPortfolio.Models;
using System.Drawing;

namespace PersonalPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutMeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _env;
        public AboutMeController(ApplicationDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
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
            string _base64String;
            AboutMe asil = _db.AboutMe.Find(aboutMe.Id);
            if (aboutMe.ImagePath != null)
            {

                try
                {



                    using (Image image = Image.FromFile(_env.ContentRootPath + "/wwwroot" + asil.ImagePath))
                    {
                        using (MemoryStream m = new MemoryStream())
                        {
                            image.Save(m, image.RawFormat);
                            byte[] imageBytes = m.ToArray();

                            // Convert byte[] to Base64 String
                            string base64String = Convert.ToBase64String(imageBytes);
                            _base64String = base64String;
                        }
                    }
                }
                catch
                {
                    _base64String = "Dosya Bulunamadı";
                }

                if (asil.ImagePath != _base64String)
                {
                    string filename = "";
                    if (aboutMe.ImagePath.Contains("png"))
                    {
                        filename = Base64ToImageSave(aboutMe.ImagePath, aboutMe.Id  + "-aboutme.png");
                    }
                    else if (aboutMe.ImagePath.Contains("jpg") || asil.ImagePath.Contains("jpeg"))
                    {
                        filename = Base64ToImageSave(aboutMe.ImagePath, aboutMe.Id + "-aboutme.jpg");
                    }
                    asil.ImagePath = "/img/aboutme/" + filename;
                }
            }

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
        private string Base64ToImageSave(string base64String, string name)
        {
            try
            {

                // Convert Base64 String to byte[] 
                byte[] imageBytes = Convert.FromBase64String(base64String.Split(',')[1]);

                var ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

                // Convert byte[] to Image 
                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = Image.FromStream(ms, true);
                if (!Directory.Exists(_env.ContentRootPath + "/wwwroot/img/aboutMe/" + name.Split("-")[0]))
                {
                    Directory.CreateDirectory(_env.ContentRootPath + "/wwwroot/img/aboutMe/" + name.Split("-")[0]);
                }


                image.Save(_env.ContentRootPath + "/wwwroot/img/aboutMe/" + name.Split("-")[0] + "/" + name);

                return name;


            }
            catch (Exception ex)
            {
                return "0";
            }
        }
    }
}
