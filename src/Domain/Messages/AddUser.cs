namespace Domain.Messages
{
	public class AddUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public byte Age { get; set; }
		public string Location { get; set; }
	}
}