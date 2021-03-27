using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Serilog;
using Application.Core.Interfaces;
using Application.Data.Entities.Concrete;
using Application.Dto.Response;
using System;
using System.IO;
using System.Text;

namespace Application.Api.Attributes
{
    public class ApiCodeFilter : ActionFilterAttribute
    {
        private readonly IUnitOfWork _uow;
        public ApiCodeFilter(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var request = context.HttpContext.Request;

            request.EnableBuffering();
            if (!request.Method.ToLower().Equals("get"))
            {
                request.Body.Seek(0, SeekOrigin.Begin);

                dynamic data;
                using (var reader = new StreamReader(request.Body, Encoding.UTF8))
                {
                    data = JsonConvert.DeserializeObject(await reader.ReadToEndAsync());
                }

                ResponseInfo<object> result = new ResponseInfo<object>();

                if (data == null)
                {
                    result.ErrorMessage = "body hatalı.";

                    context.Result = new ObjectResult(context.ModelState)
                    {
                        Value = result,
                    };

                    Log.Error(JsonConvert.SerializeObject(result));

                    return;
                }

                string apiCode = data.apiCode;

                if (string.IsNullOrWhiteSpace(apiCode))
                {
                    result.ErrorMessage = "apiCode hatalı.";

                    context.Result = new ObjectResult(context.ModelState)
                    {
                        Value = result,
                    };

                    Log.Error(JsonConvert.SerializeObject(result));
                }

                var userApiSession = await _uow.Repository<ApiSession>().FindAsync(x => x.ApiCode == apiCode);
                if (userApiSession == null)
                {
                    result.ErrorMessage = "apiCode hatalı.";

                    context.Result = new ObjectResult(context.ModelState)
                    {
                        Value = result,
                    };

                    Log.Error(JsonConvert.SerializeObject(result));

                    return;
                }

                if (userApiSession.PackageEndDate < DateTime.UtcNow)
                {
                    result.ErrorMessage = "apiCode süresi dolmuş.";

                    context.Result = new ObjectResult(context.ModelState)
                    {
                        Value = result,
                    };

                    Log.Error(JsonConvert.SerializeObject(result));

                    return;
                }
            }
        }
    }
}



