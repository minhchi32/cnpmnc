using cnpmnc.backend.DTOs.AssignmentDTOs;
using cnpmnc.backend.Validators;
using cnpmnc.shared.Constants;
using FluentValidation;

namespace cnpmnc.backend.Validators
{
    public class AssignmentGradeResponseDTOValidator : BaseValidator<AssignmentGradeResponseDTO>
    {
        public AssignmentGradeResponseDTOValidator()
        {
            RuleFor(m => m.AssignmentGradeID)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.AssignmentGradeID)))
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.AssignmentGradeID)));

            RuleFor(m => m.Response)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Response)));
        }
    }
}

