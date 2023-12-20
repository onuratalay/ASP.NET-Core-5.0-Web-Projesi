using Microsoft.AspNetCore.Mvc;

namespace CoreProje.ViewComponents.Dashboard
{
    public class Last5Projects:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
