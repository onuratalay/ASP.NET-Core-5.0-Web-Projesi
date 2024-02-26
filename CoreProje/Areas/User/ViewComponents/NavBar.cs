using System.Threading.Tasks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Areas.User.ViewComponents
{
    public class NavBar : ViewComponent
    {
        private readonly UserManager<DefaultUser> _userManager;

        public NavBar(UserManager<DefaultUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.ImageUrl;
            return View();
        }
    }
}
