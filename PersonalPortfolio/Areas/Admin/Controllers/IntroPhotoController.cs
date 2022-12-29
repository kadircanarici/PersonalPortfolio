using Microsoft.AspNetCore.Mvc;
using PersonalPortfolio.Data;
using PersonalPortfolio.Models;
using System.Drawing;
using System.Security.Policy;

namespace PersonalPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class IntroPhotoController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _env;
        public IntroPhotoController(ApplicationDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Get()
        {
           List<IntroPhoto> introphotos = _db.introPhotos.Where(i => i.IsActive == true && i.IsDeleted == false).ToList<IntroPhoto>();
            return Json(new { data = introphotos });
        }
        public IActionResult GetById(IntroPhoto photo)
        {
            IntroPhoto introphoto = _db.introPhotos.FirstOrDefault(i => i.Id == photo.Id);
            return Json(introphoto);
        }

        public IActionResult Update(IntroPhoto newPhoto)
        {
            IntroPhoto asil = _db.introPhotos.Find(newPhoto.Id);
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
                asil.ImagePath = "img/profile-picture/" + filename;

            }
            asil.Title = newPhoto.Title;

            _db.introPhotos.Update(asil);
            _db.SaveChanges();

            return Json(asil);
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

                image.Save(_env.ContentRootPath + "/wwwroot/img/profile-picture/" + name);

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