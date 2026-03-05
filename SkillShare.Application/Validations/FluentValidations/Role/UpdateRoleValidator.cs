using FluentValidation;
using SkillShare.Domain.Dto.Role;

namespace SkillShare.Application.Validations.FluentValidations.Role;

/// <summary>
/// Валидация обновления роли 
/// </summary>
public class UpdateRoleValidator : AbstractValidator<UpdateRoleDto>
{
    public UpdateRoleValidator()
    {
        RuleFor(x => x.Id)
        .NotEmpty()
        .GreaterThan(0);

        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50);
    }
}
