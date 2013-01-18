using System.ComponentModel.DataAnnotations;

namespace Customers.Models
{
	// TODO: vlad - add validation
	public class User
	{
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Display(Name = "Email")]
		public string EmailAddress { get; set; }

		[Display(Name = "Age")]
		public byte Age { get; set; }

		[Display(Name = "Location")]
		public string Location { get; set; }
	}
}