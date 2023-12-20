using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.ViewComponents.Dashboard
{
    public class MessageList : ViewComponent
    {
        private UserMessageManager userMessageManager = new UserMessageManager(new EfUserMessageDal());

        public IViewComponentResult Invoke()
        {
            var values = userMessageManager.GetUserMessagesWithUserService();
            return View(values);
        }
    }
}
