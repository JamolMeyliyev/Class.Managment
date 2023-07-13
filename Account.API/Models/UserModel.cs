using Account.API.Entities;


namespace Account.API.Models
{
	public class UserModel
	{
		public UserModel(User user)
		{
			Id = user.Id;
			Name = user.Name;
			UserName = user.UserName;
		}

		public Guid Id { get; set; }
		public string? Name { get; set; }
		public string UserName { get; set; }

	}
}
