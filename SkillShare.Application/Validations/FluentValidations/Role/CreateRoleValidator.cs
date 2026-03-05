using FluentValidation;
using SkillShare.Domain.Dto.Role;

namespace SkillShare.Application.Validations.FluentValidations.Role;

/// <summary>
/// Валидация создания роли
/// </summary>
public class CreateRoleValidator : AbstractValidator<CreateRoleDto>
{
    public CreateRoleValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50);
    }
}
