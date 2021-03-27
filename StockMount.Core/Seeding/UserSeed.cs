using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Application.Data.Entities.Concrete;
using Application.Utility.Hashing;

namespace Application.Core.Seeding
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            string password = "11223344!";
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            builder.HasData(new User
            {
                Name = "yazilim",
                Surname = "stockmount",
                Email = "yazilim@Application.com",
                Username = "yazilim@Application.com",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Avatar = "/assets/images/avatar/avatarset01/avatarset01_01.png",
            });
        }
    }
}
