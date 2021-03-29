using Newtonsoft.Json;
using Application.Dto.Abstract;
using System;

namespace Application.Dto.Concrete
{
    public class UserDto : EntityDto
    {
        public int UserId { get; set; }

        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }
        [JsonIgnore]
        public byte[] PasswordHash { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Avatar { get; set; }

        [JsonProperty("packageEndDate")]
        public DateTime PackageEndDate { get; set; }
    }
}
