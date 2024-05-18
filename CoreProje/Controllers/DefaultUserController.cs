using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProje.Controllers
{
    public class DefaultUserController : Controller
    {
        private DefaultUserManager _manager = new DefaultUserManager(new EfDefaultUserDal());

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListDefaultUser()
        {
            var values = JsonConvert.SerializeObject(_manager.TGetList());
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddDefaultUser(DefaultUser defaultUser)
        {
            _manager.TAdd(defaultUser);
            var values = JsonConvert.SerializeObject(defaultUser);
            return Json(values);
        }
    }
}
