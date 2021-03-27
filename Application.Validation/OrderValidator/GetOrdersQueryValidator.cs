using FluentValidation;
using Application.Service.OrderService.Queries.Query;

namespace Application.Validation.OrderValidator
{
    public class GetOrdersQueryValidator : AbstractValidator<GetOrdersQuery>
    {
        public GetOrdersQueryValidator()
        {
            RuleFor(u => u.ApiCode).NotEmpty().WithMessage("Api Code boş olamaz.");
            RuleFor(u => u.StoreId).NotEmpty().When(x => x.StoreId <= 0).WithMessage("Store Id 0 ya da boş olamaz.");
        }
    }
}
