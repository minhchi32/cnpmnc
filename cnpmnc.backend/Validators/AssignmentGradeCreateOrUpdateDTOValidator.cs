using cnpmnc.backend.DTOs.AssignmentGradeDTOs;
using cnpmnc.backend.Validators;
using cnpmnc.shared.Constants;
using FluentValidation;

namespace Rookie.AssetManagement.Validators
{
    public class AssignmentGradeCreateOrUpdateDTOValidator : BaseValidator<AssignmentGradeCreateOrUpdateDTO>
    {
        public AssignmentGradeCreateOrUpdateDTOValidator()
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
        }
    }
}

