using System.Web.Mvc;
using Customers.Models;
using Domain.Messages;
using MassTransit;

namespace Customers.Controllers
{
    public class HomeController : Controller
    {
		[HttpGet]
        public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Index(User user)
		{
			Bus.Instance.Publish(new AddUser
				{
					FirstName = user.FirstName,
					LastName = user.LastName,
					EmailAddress = user.EmailAddress,
					Age = user.Age,
					Location = user.Location
				});

			return View(user);
		}
    }
}