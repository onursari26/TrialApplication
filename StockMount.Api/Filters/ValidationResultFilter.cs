using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Application.Dto.Response;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Api.Filters
{
    public class ValidationResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result.GetType().Equals(typeof(BadRequestObjectResult)))
            {
                var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                    .SelectMany(v => v.Errors)
                    .Select(v => v.ErrorMessage)
                    .ToList();

                ResponseInfo<string> result = new ResponseInfo<string>();

                errors.ForEach(error =>
                {
                    if (string.IsNullOrWhiteSpace(result.ErrorMessage))
                    {
                        result.ErrorMessage = error;
                    }
                    else
                    {
                        result.ErrorMessage = result.ErrorMessage + Environment.NewLine + error;
                    }
                });

                context.Result = new ObjectResult(context.ModelState)
                {
                    Value = result,
                    StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest,
                };
            }
        }
    }
}
