using Microsoft.EntityFrameworkCore;

namespace TaksiPro.Models
{
	public class AppDbContext : DbContext
	{
		private readonly IConfiguration configuration;

		public AppDbContext(IConfiguration configuration)
		{
			this.configuration = configuration;
			Database.Migrate();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			string connection =
				this.configuration.GetConnectionString("DefaultConnection");

			optionsBuilder.UseSqlServer(connection);
		}

		public DbSet<Contact> Contactlar { get; set; }
		public DbSet<Buyurtma> Buyurtmalar { get; set; }
		public DbSet<Tariff> Tarifflar { get; set; }
		public DbSet<Moshina> Moshinaalar { get; set; }

	}
}
