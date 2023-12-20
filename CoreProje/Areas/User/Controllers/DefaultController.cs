using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class DefaultController : Controller
    {
        private readonly AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());

        public IActionResult Index()
        {
            var values = announcementManager.TGetList();
            return View(values);
        }
    }
}
