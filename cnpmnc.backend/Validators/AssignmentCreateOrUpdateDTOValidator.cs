using cnpmnc.backend.DTOs.AssignmentDTOs;
using cnpmnc.backend.Validators;
using cnpmnc.shared.Constants;
using FluentValidation;

namespace Rookie.AssetManagement.Validators
{
    public class AssignmentCreateOrUpdateDTOValidator : BaseValidator<AssignmentCreateOrUpdateDTO>
    {
        public AssignmentCreateOrUpdateDTOValidator()
        {
            RuleFor(m => m.AssignToTeacherId)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.AssignToTeacherId)))
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.AssignToTeacherId)));

            RuleFor(m => m.CourseId)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.CourseId)))
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.CourseId)));

            RuleFor(m => m.AssignDate)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.AssignDate)))
                .GreaterThanOrEqualTo(DateTime.Now.Date)
                .WithMessage(x => string.Format(ErrorTypes.Common.SelectDateGreaterThanOrEqualToday, nameof(x.AssignDate)));

            RuleFor(m => m.Note)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Note)));
        }
    }
}

