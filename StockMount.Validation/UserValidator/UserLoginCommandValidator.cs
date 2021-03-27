using FluentValidation;
using FluentValidation.Results;
using Application.Dto.Response;
using Application.Service.AuthService.Commands.Command;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Validation.UserValidator
{
    public class UserLoginCommandValidator : AbstractValidator<UserLoginCommand>
    {
        public UserLoginCommandValidator()
        {
            RuleFor(u => u.Username).NotEmpty().WithMessage("Kullanıcı adı boş olamaz.");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Şifre boş olamaz.");
        }

        //public override ValidationResult Validate(ValidationContext<UserLoginCommand> context)
        //{
        //    var result = base.Validate(context);

        //    if (!result.IsValid)
        //    {
        //        var errorResult = new ResponseInfo<UserLoginCommand>();
        //        //foreach (var error in result.Errors)
        //        //{
        //        //    if (string.IsNullOrWhiteSpace(errorResult.ErrorMessage))
        //        //    {
        //        //        errorResult.ErrorMessage = error.PropertyName + " " + error.ErrorMessage;
        //        //        errorResult.ErrorCode = error.ErrorCode;
        //        //    }
        //        //    else
        //        //    {
        //        //        errorResult.ErrorMessage = errorResult.ErrorMessage + Environment.NewLine + error.ErrorMessage;
        //        //    }
        //        //}

        //    }

        //    return result;

        //}
    }
}
