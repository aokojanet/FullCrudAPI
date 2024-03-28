using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace WebApplication2.Models
{
	public class WebDb : DbContext
	{
		public WebDb(DbContextOptions<WebDb> options) : base(options)
		{ }
		public DbSet<User> Users { get; set; }
		public DbSet<Vehicles> Vehicles { get; set; }

	}




}

