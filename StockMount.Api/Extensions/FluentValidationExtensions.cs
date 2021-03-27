using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Application.Validation.OrderValidator;
using Application.Validation.UserValidator;

namespace Application.Api.Extensions
{
    public static class FluentValidationExtensions
    {
        public static void AddFluentValidation(this IMvcBuilder mvcBuilder)
        {
            mvcBuilder.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserLoginCommandValidator>());
            mvcBuilder.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GetOrdersQueryValidator>());
        }
    }
}
