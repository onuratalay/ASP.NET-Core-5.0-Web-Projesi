using System.Linq;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.ViewComponents.Dashboard
{
    public class StatisticsDashboard2:ViewComponent
    {
        private Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Portfolios.Count();
            ViewBag.v2 = c.Messages.Count();
            ViewBag.v3 = c.Services.Count();
            return View();
        }
    }
}
