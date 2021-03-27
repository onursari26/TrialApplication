using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Application.Data.Entities.Concrete;

namespace Application.Core.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(c => c.OrderId).IsRequired();

            builder.HasOne(d => d.Store)
                   .WithMany(p => p.Orders)
                   .HasForeignKey(d => d.StoreId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
