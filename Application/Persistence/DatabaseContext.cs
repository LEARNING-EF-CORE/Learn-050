using Microsoft.EntityFrameworkCore;

namespace Persistence
{
	public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
	{
		public DatabaseContext() : base()
		{
			Database.EnsureCreated();
		}

		public Microsoft.EntityFrameworkCore.DbSet<Domain.User> Users { get; set; }

		public Microsoft.EntityFrameworkCore.DbSet<Domain.Group> Groups { get; set; }

		// به هیچ عنوان نباید از دستور ذیل استفاده کنیم
		//public Microsoft.EntityFrameworkCore.DbSet<Domain.UserProfile> UserProfiles { get; set; }

		protected override void OnConfiguring
			(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
		{
			//base.OnConfiguring(optionsBuilder);

			string connectionString =
				"Password=1234512345;Persist Security Info=True;User ID=SA;Initial Catalog=LEARNING_EF_CORE_5;Data Source=.";

			optionsBuilder
				// using Microsoft.EntityFrameworkCore;
				.UseLazyLoadingProxies()
				// using Microsoft.EntityFrameworkCore;
				.UseSqlServer(connectionString: connectionString)
				;
			;
		}

		protected override void OnModelCreating
			(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly
				(assembly: typeof(Domain.User.Configuration).Assembly);
		}
	}
}
