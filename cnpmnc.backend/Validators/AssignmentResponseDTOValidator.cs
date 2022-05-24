using cnpmnc.backend.DTOs.AssignmentDTOs;
using cnpmnc.backend.Validators;
using cnpmnc.shared.Constants;
using FluentValidation;

namespace Rookie.AssetManagement.Validators
{
    public class AssignmentResponseDTOValidator : BaseValidator<AssignmentResponseDTO>
    {
        public AssignmentResponseDTOValidator()
        {
            RuleFor(m => m.AssignmentID)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.AssignmentID)))
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.AssignmentID)));

            RuleFor(m => m.Response)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Response)));
        }
    }
}

