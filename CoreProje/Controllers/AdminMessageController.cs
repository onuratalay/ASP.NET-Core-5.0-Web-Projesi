using System;
using System.Linq;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace CoreProje.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdminMessageController : Controller
    {
        private WriterMessageManager _writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());

        public IActionResult ReceiverMessageList()
        {
            string username = "admin";
            var messages = _writerMessageManager.GetListReceiverMessage(username);
            return View(messages);
        }

        public IActionResult SenderMessageList()
        {
            string username = "admin";
            var messages = _writerMessageManager.GetListSenderMessage(username);
            return View(messages);
        }

        public IActionResult MessageDetails(int id)
        {
            var messages = _writerMessageManager.TGetById(id);
            ViewData["Receiver"] = messages.Receiver;
            return View(messages);
        }

        public IActionResult DeleteAdminMessage(int id)
        {
            var message = _writerMessageManager.TGetById(id);
            _writerMessageManager.TDelete(message);

            if (message.Receiver == "admin")
            {
                return RedirectToAction("ReceiverMessageList");
            }
            else
            {
                return RedirectToAction("SenderMessageList");
            }

        }

        [HttpGet]
        public IActionResult AddAdminMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAdminMessage(WriterMessage writerMessage)
        {
            writerMessage.Sender = "admin";
            writerMessage.SenderName = "Administrator";
            writerMessage.Date = DateTime.Now;

            Context c = new Context();
            var fullname = c.Users.Where(x => x.UserName == writerMessage.Receiver).Select(y => y.Name + " " + y.Surname)
                .FirstOrDefault();
            writerMessage.ReceiverName = fullname;

            _writerMessageManager.TAdd(writerMessage);
            return RedirectToAction("SenderMessageList");
        }
    }
}
