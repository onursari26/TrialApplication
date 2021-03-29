using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Application.Data.Entities.Concrete;

namespace Application.Core.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.Username).IsRequired();
            builder.Property(c => c.PasswordHash).IsRequired();
            builder.Property(c => c.PasswordSalt).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Surname).IsRequired();
        }
    }
}
