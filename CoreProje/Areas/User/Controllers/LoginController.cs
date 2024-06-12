using System.Threading.Tasks;
using CoreProje.Areas.User.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Areas.User.Controllers
{
    [AllowAnonymous]
    [Area("User")]
    [Route("User/[controller]/[action]")]
    public class LoginController : Controller
    {
        private readonly SignInManager<DefaultUser> _signInManager;
        private readonly UserManager<DefaultUser> _userManager;

        public LoginController(SignInManager<DefaultUser> signInManager, UserManager<DefaultUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, true, true);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(p.Username);

                    if (user != null)
                    {
                        var roles = await _userManager.GetRolesAsync(user);

                        if (roles.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Dashboard", new { area = "" });
                        }

                        else if (roles.Contains("User"))
                        {
                            return RedirectToAction("Index", "Dashboard", new { area = "User" });
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı kullanıcı adı veya şifre!");
                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
