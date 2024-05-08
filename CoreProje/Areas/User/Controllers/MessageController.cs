using System;
using System.Net.Mail;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/[controller]")]
    public class MessageController : Controller
    {
        private WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());

        private readonly UserManager<DefaultUser> _userManager;

        public MessageController(UserManager<DefaultUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("")]
        [Route("ReceiverMessage")]
        public async Task<IActionResult> ReceiverMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.UserName;
            var messageList = writerMessageManager.GetListReceiverMessage(p);
            return View(messageList);
        }

        [Route("")]
        [Route("SenderMessage")]
        public async Task<IActionResult> SenderMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.UserName;
            var messageList = writerMessageManager.GetListSenderMessage(p);
            return View(messageList);
        }

        [Route("MessageDetails/{id}")]
        public IActionResult MessageDetails(int id)
        {
            WriterMessage message = writerMessageManager.TGetById(id);
            return View(message);
        }

        [Route("ReceiverMessageDetails/{id}")]
        public IActionResult ReceiverMessageDetails(int id)
        {
            WriterMessage message = writerMessageManager.TGetById(id);
            return View(message);
        }

        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(WriterMessage p)
        {
            var receiver = await _userManager.FindByNameAsync(p.Receiver);
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Sender = values.UserName;
            p.SenderName = values.Name + " " + values.Surname;
            p.ReceiverName = receiver.Name + " " + receiver.Surname;
            writerMessageManager.TAdd(p);
            return RedirectToAction("SenderMessage");
        }
    }
}
