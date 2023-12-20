using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.ViewComponents.Dashboard
{
    public class ToDoListPanel : ViewComponent
    {
        private ToDoListManager toDoListManager = new ToDoListManager(new EfToDoListDal());

        public IViewComponentResult Invoke()
        {
            var values = toDoListManager.TGetList();
            return View(values);
        }
    }
}
