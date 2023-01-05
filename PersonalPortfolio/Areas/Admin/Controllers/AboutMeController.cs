using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalPortfolio.Data;
using PersonalPortfolio.Models;
using System.Data;
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
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            List<AboutMe> aboutMes=_db.AboutMe.Where(a=>a.IsActive==true && a.IsDeleted == false).ToList<AboutMe>();
            return Json(new { data = aboutMes });
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(AboutMe newPhoto)
        {
            AboutMe asil = _db.AboutMe.Find(newPhoto.Id);
            string filename = "";
            if (newPhoto.ImagePath != null)
            {
                if (newPhoto.ImagePath.Contains("png"))
                {
                    filename = Base64ToImageSave(newPhoto.ImagePath, newPhoto.Id + RandomStringGenerator(5) + ".png");
                }
                else if (newPhoto.ImagePath.Contains("jpg") || newPhoto.ImagePath.Contains("jpeg"))
                {
                    filename = Base64ToImageSave(newPhoto.ImagePath, newPhoto.Id + RandomStringGenerator(5) + ".jpg");
                }
                asil.ImagePath = "img/aboutMe/" + filename;

            }
            asil.Title = newPhoto.Title;
            asil.Description= newPhoto.Description;
            asil.CurvedText= newPhoto.CurvedText;

            _db.AboutMe.Update(asil);
            _db.SaveChanges();

            return Json(asil);
        }
        [Authorize(Roles = "Admin")]
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

                image.Save(_env.ContentRootPath + "/wwwroot/img/aboutMe/" + name);

                return name;


            }
            catch (Exception ex)
            {
                return "0";
            }
        }
        public static string RandomStringGenerator(int length)
        {
            string randomString = "";
            char[] upperCase = "QWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray();
            char[] lowerCase = "qwertyuiopasdfghjklzxcvbnm".ToCharArray();
            char[] number = "1234567890".ToCharArray();
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                int rndChoice = rnd.Next(1, 4);
                if (rndChoice == 1)
                {
                    int upperCaseRnd = rnd.Next(0, upperCase.Length);
                    randomString += upperCase[upperCaseRnd];
                }
                else if (rndChoice == 2)
                {
                    int lowerCaseRnd = rnd.Next(0, lowerCase.Length);
                    randomString += lowerCase[lowerCaseRnd];
                }
                else
                {
                    int numberRnd = rnd.Next(0, number.Length);
                    randomString += number[numberRnd];
                }
            }
            return randomString;
        }
    }
}
