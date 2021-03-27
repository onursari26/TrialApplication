using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Application.Data.Entities.Concrete;

namespace Application.Core.Mappings
{
    public class ApiSessionMap : IEntityTypeConfiguration<ApiSession>
    {
        public void Configure(EntityTypeBuilder<ApiSession> builder)
        {
            builder.Property(c => c.Id).IsRequired();

            builder.HasOne(d => d.User)
                   .WithMany(p => p.ApiSessions)
                   .HasForeignKey(d => d.UserId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
