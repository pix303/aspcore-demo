using Microsoft.EntityFrameworkCore;
using RestApiApp.Models;

namespace RestApiApp.Services
{
	public class AppDBContext : DbContext
	{

		public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
		{

		}

		public virtual DbSet<Message>? Messages { get; set; }
		public virtual DbSet<Priority>? Priority { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Message>()
			.HasKey(rm => rm.Id);

			modelBuilder.Entity<Message>()
			.HasOne<Priority>(rm => rm.Priority)
			.WithMany(p => p.Messages)
			.HasForeignKey(p => p.PriorityId);

			modelBuilder.Entity<Priority>()
			.HasKey(priority => new { priority.Id });

			modelBuilder.Entity<Priority>()
			.HasMany<Message>(p => p.Messages)
			.WithOne(rm => rm.Priority);


		}
	}


}
