using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Areas.User.Controllers
{
    [Area("User")]
    public class DashboardController : Controller
    {
        private readonly UserManager<DefaultUser> _userManager;

        public DashboardController(UserManager<DefaultUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.Name + " " + values.Surname;

            // WEATHER API
            string api = "881071e58bd1e7b46dd9d7986131bcac";

            string connection =
                "https://api.openweathermap.org/data/2.5/weather?q=Sinop&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument document = XDocument.Load(connection);
            ViewBag.w = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;


            //STATISTICS
            Context c = new Context();
            ViewBag.v1 = 0;
            ViewBag.v2 = c.Announcements.Count();
            ViewBag.v3 = 0;
            ViewBag.v4 = c.Skills.Count();

            return View();
        }
    }
}
