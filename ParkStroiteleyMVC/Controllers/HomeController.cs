using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using ParkStroiteleyMVC.Controllers.Core.Interface;
using ParkStroiteleyMVC.Services;

namespace ParkStroiteleyMVC.Controllers
{
    public class HomeController : Controller
    {
        private Action<string> Logs => Startup.Logs;
        /*private readonly ILogger<HomeController> _logger;*/

        public static IHomeDispatcher Dispatcher;

        public HomeController(/*ILogger<HomeController> logger*/)
        {
            /*if (Dispatcher == null)
                Logs.Invoke("Dispatcher was NULL! Check youre middleware.");

            _logger = logger;*/
        }
        public IActionResult AboutCookie()
        {
            return View();
        }
        public IActionResult About()
        {
            return View(Dispatcher.About);
        }
        public IActionResult Index()
        {
            return View(Dispatcher.Index);
        }
        public IActionResult Map()
        {
            return View(Dispatcher.Map);
        }
        public IActionResult News(int page = 1)
        {
            Dispatcher.PageNews = page;
            return View(Dispatcher.News);
        }
        public IActionResult CardNews(int id)
        {
            Dispatcher.CardNewsId = id;
            return View(Dispatcher.CardNews);
        }
        public void PostComment(int id, string nickname, string email, string comment)
        {
            if (comment != "" && comment != null && nickname != "" && nickname != null)
                Dispatcher.PostComment(id, nickname, email, comment);
        }
        [HttpGet]
        public JsonResult NewsLazy(int lastId)
        {
            var res = Dispatcher.GetNewsLazy(lastId);
            return new JsonResult(res);
        }

        #region [Services]
        public IActionResult SendMessage(string email, string message, string name)
        {
            EmailService service = new EmailService();
            service.SendEmailAsync("orsk.park@yandex.ru", email,$"Сообщение от {name}:{Environment.NewLine}{message}").GetAwaiter().GetResult();

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
        #endregion
    }
}
