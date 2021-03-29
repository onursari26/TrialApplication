using Application.Data.Entities.Abstract;
using System.Collections.Generic;

namespace Application.Data.Entities.Concrete
{
    public class User : Entity
    {
        public User()
        {
            ApiSessions = new HashSet<ApiSession>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Avatar { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public ICollection<ApiSession> ApiSessions { get; set; }
    }
}
