using Microsoft.EntityFrameworkCore;
using muchik.market.pay.domain.entities;
using muchik.market.pay.infrastructure.configurations.entityTypes;

namespace muchik.market.pay.infrastructure.context
{
    public partial class PayContext : DbContext
    {
        public PayContext(DbContextOptions<PayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pay> Pay { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PayTypeConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
