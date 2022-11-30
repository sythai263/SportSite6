using Microsoft.EntityFrameworkCore;
using SportSite6.Models;
namespace SportSite6.Database
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


		public DbSet<User>? Users { get; set; }
		public DbSet<Media>? Medias { get; set; }
		public DbSet<Category>? Categories { get; set; }
		public DbSet<Evaluation>? Evaluations { get; set; }
		public DbSet<Content>? Contents { get; set; }
		public DbSet<Page>? Pages { get; set; }
	}

}