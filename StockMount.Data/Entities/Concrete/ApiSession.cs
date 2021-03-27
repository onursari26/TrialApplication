using Application.Data.Entities.Abstract;
using System;

namespace Application.Data.Entities.Concrete
{
    public class ApiSession : Entity
    {
        public int Id { get; set; }
        public DateTime PackageEndDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
