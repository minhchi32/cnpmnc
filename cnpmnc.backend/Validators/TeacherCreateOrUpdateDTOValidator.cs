using cnpmnc.backend.DTOs.TeacherDTOs;
using cnpmnc.backend.Validators;
using cnpmnc.shared.Constants;
using FluentValidation;

namespace cnpmnc.backend.Validators
{
    public class TeacherCreateOrUpdateDTOValidator : BaseValidator<TeacherCreateOrUpdateDTO>
    {
        public TeacherCreateOrUpdateDTOValidator()
        {

            RuleFor(m => m.Name)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Name)))
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Name)));
            RuleFor(m => m.IdCard)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.IdCard)))
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.IdCard)));
            RuleFor(m => m.Address)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Address)))
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Address)));
            RuleFor(m => m.PhoneNumber)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.PhoneNumber)))
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.PhoneNumber)));
            RuleFor(m => m.LiteracyId)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.LiteracyId)))
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.LiteracyId)));
        }
    }
}

