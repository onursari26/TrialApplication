using MediatR;
using Newtonsoft.Json;
using Application.Dto.Concrete;
using Application.Dto.Response;
using Application.Service.Abstract;
using System;
using System.Collections.Generic;

namespace Application.Service.LogService.Queries.Query
{
    public class GetLogsQuery : BaseCQ, IRequest<ResponseInfo<List<LogDto>>>
    {
        [JsonIgnore]
        public string FilePath { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

    }
}
