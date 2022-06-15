using cnpmnc.backend.DTOs.AuthorizeDTOs;
using cnpmnc.backend.Validators;
using FluentValidation;

namespace cnpmnc.backend.Validators
{
    public class UserLoginDTOValidator : BaseValidator<UserLoginDTO>
    {
        public UserLoginDTOValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("UserName is required");
            RuleFor(x => x.Password)
             .NotEmpty()
             .WithMessage("Password is required");
        }
    }
}

