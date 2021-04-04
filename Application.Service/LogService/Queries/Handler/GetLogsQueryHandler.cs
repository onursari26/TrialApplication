using MediatR;
using Newtonsoft.Json;
using Application.Dto.Concrete;
using Application.Dto.Response;
using Application.Service.LogService.Queries.Query;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Service.LogService.Queries.Handler
{
    public class GetLogsQueryHandler : IRequestHandler<GetLogsQuery, ResponseInfo<List<LogDto>>>
    {
        public async Task<ResponseInfo<List<LogDto>>> Handle(GetLogsQuery request, CancellationToken cancellationToken)
        {
            string path = request.FilePath + "\\Logs\\log" + request.Level + request.Date.ToString("yyyyMMdd") + ".txt";

            ResponseInfo<List<LogDto>> result = new ResponseInfo<List<LogDto>>
            {
                Data = new List<LogDto>()
            };

            if (!File.Exists(path))
            {
                result.ErrorMessage = path + " log dosyası bulunamadı.";
                return result;
            }

            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8, false))
                {
                    string row = await streamReader.ReadLineAsync();

                    while (row != null)
                    {
                        result.Data.Add(JsonConvert.DeserializeObject<LogDto>(row));

                        row = await streamReader.ReadLineAsync();
                    }
                }
            }

            if (result.Data.Count == 0)
                return result;

            result.TotalCount = result.Data.Count;

            if (request.Page != 0 && request.PageSize != 0)
                result.Data = result.Data.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();

            return result;
        }
    }
}
