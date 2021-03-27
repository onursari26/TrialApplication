using System.Collections.Generic;

namespace Application.Dto.Concrete
{
    public class StoreDto
    {
        public StoreDto()
        {
            Orders = new HashSet<OrderDto>();
        }
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<OrderDto> Orders { get; set; }
    }
}
