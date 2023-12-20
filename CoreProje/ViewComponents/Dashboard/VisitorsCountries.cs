using Microsoft.AspNetCore.Mvc;

namespace CoreProje.ViewComponents.Dashboard
{
    public class VisitorsCountries : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
