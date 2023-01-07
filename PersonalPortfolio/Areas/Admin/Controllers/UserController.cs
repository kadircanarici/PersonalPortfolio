using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalPortfolio.Data;
using PersonalPortfolio.Models;
using System.Data;
using System.Security.Claims;

namespace PersonalPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller

    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        
        public async Task<IActionResult> Login (User user)
        {
            User usr =_db.users.FirstOrDefault(u=> u.UserName == user.UserName && u.Password == user.Password );
            if (usr != null)
            {
                List<Claim> userClaims = new List<Claim>();
                userClaims.Add(new Claim(ClaimTypes.Name,usr.UserName));  
                userClaims.Add(new Claim(ClaimTypes.NameIdentifier,usr.Id.ToString()));
                userClaims.Add(new Claim(ClaimTypes.Role,"Admin"));

                var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return Json(usr);

            }
            else
            {
                return Json(user);
            }
           
        }
    }
}
