using Microsoft.EntityFrameworkCore;
using muchik.market.security.domain.entities;
using muchik.market.security.infrastructure.configurations.entityTypes;

namespace muchik.market.security.infrastructure.context
{
    public class SecurityContext : DbContext
    {
        public SecurityContext(DbContextOptions<SecurityContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer("Users");
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
