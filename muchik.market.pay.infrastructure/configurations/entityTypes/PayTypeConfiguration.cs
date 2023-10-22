using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using muchik.market.pay.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muchik.market.pay.infrastructure.configurations.entityTypes 
{
    public class PayTypeConfiguration : IEntityTypeConfiguration<Pay>
    {
        public void Configure(EntityTypeBuilder<Pay> builder)
        {
            builder.ToTable("pay");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");

            builder.Property(e => e.InvoiceId)
                .HasColumnType("varchar(250)")
                .HasColumnName("invoice_id");

            builder.Property(e => e.Total)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total");
        }
    }
}
