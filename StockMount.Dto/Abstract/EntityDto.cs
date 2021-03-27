using Newtonsoft.Json;
using System;

namespace Application.Dto.Abstract
{
    public class EntityDto
    {
        [JsonProperty("apiCode")]
        public string ApiCode { get; set; }
    }
}
