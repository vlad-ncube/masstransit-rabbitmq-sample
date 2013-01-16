using System.Web.Mvc;
using Domain.Messages;
using MassTransit;

namespace Customers.Controllers
{
    public class PublishController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Send(string message)
        {
            Bus.Instance.Publish(new ParseCvMessage { S3Key = message });
            return RedirectToAction("Index");
        }
    }
}