using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.ViewComponents.AdminNavBar
{
    public class NotificationList : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
