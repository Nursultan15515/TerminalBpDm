using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TerminalBpDm.ServiceReference1;

namespace TerminalBpDm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            RequestCard requestCard = new RequestCard
            {
                RequestInfo = new RequestInfo
                {
                    MessageID = Guid.NewGuid().ToString(),
                    Sender = new Sender
                    {
                        User = "Terminal4k1t",
                        Password = "Ter2minaL",
                    },
                },
                RequestData = new RequestCardData
                {
                    DocumentNumber = "930114350812"
                },
            };

            ServiceReference1.TerminalService1SoapClient client = new ServiceReference1.TerminalService1SoapClient();

            var resp = client.GetVisitor(requestCard);

            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Ind()
        {
            ViewBag.Message = "Your Keyboard page.";

            return View();
        }

        public ActionResult SetLanguage(string lang)
        {
            HttpCookie langCookie = new HttpCookie("lang", lang);
            langCookie.Expires = DateTime.Now.AddYears(2);
            Response.Cookies.Add(langCookie);

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}