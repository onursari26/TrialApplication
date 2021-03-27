using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Application.Data.Entities.Concrete;

namespace Application.Core.Mappings
{
    public class OrderLineMap : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.Property(c => c.OrderDetailId).IsRequired();

            builder.HasOne(d => d.Order)
                   .WithMany(p => p.OrderDetails)
                   .HasForeignKey(d => d.OrderId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
