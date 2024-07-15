using Microsoft.EntityFrameworkCore;
using RestApiApp.Models;

namespace RestApiApp.Services
{
	public class AppDBContext : DbContext
	{

		public virtual DbSet<Message> Messages { get; set; } = null!;
		public virtual DbSet<Priority> Priorities { get; set; } = null!;

		public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Message>()
			.HasKey(m => m.Id);

			modelBuilder.Entity<Message>()
			.HasOne<Priority>(m => m.Priority)
			.WithMany(p => p.Messages)
			.HasForeignKey(m => m.PriorityId)
			.HasPrincipalKey(p => p.Id);

			modelBuilder.Entity<Priority>()
			.HasKey(m => m.Id);
		}
	}


}
