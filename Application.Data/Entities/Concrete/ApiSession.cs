using Application.Data.Entities.Abstract;
using System;

namespace Application.Data.Entities.Concrete
{
    public class ApiSession : IEntity
    {
        public int Id { get; set; }
        public DateTime PackageEndDate { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public string ApiCode { get; set; }
    }
}
