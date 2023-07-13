namespace Account.API.Models
{
	public class LoginUserModel
	{
		public required string Password { get; set; }
		public required string UserName { get; set; }
	}
}
