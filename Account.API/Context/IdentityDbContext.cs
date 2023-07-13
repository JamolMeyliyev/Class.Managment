using Account.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Account.API.Context
{
	public class IdentityDbContext:DbContext
	{
		public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
		{

		}

		public DbSet<User> Users => Set<User>();
	}
}
