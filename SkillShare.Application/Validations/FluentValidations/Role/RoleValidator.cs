using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SkillShare.Domain.Dto.Role;

namespace SkillShare.Application.Validations.FluentValidations.Role;

public class RoleValidator : AbstractValidator<RoleDto>
{
    public RoleValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50);

        RuleFor(x => x.Id)
            .GreaterThan(0);
    }
}
