using Newtonsoft.Json;

namespace Application.Service.Abstract
{
    public class BaseCQ
    {
        [JsonProperty("apiCode")]
        public string ApiCode { get; set; }

        private int page;
        [JsonProperty("page")]
        public int Page
        {
            get
            {
                if (page == 0)
                    page = 1;

                return page;
            }
            set
            {
                page = value;
            }
        }

        private int pageSize;
        [JsonProperty("pageSize")]
        public int PageSize
        {
            get
            {
                if (pageSize == 0)
                    pageSize = 50;

                return pageSize;
            }
            set
            {
                pageSize = value;
            }
        }
    }
}
