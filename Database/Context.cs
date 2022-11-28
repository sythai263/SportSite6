using Microsoft.EntityFrameworkCore;
namespace SportSite.Database
{
	public class DBContext : DbContext
	{
		protected readonly IConfiguration configuration;
		public DBContext(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			// connect to mysql with connection string from app settings
			var connectionString = configuration.GetConnectionString("WebAppDatabase");
			options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
		}
	}

}