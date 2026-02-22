using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SkillShare.Domain.Dto.CourseDto;
using SkillShare.Domain.Dto.User;

namespace SkillShare.Application.Validations.FluentValidations.User;

public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Login).NotEmpty().MaximumLength(30);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(20); ;
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Email).NotEmpty().MaximumLength(30);
        RuleFor(x => x.Age).NotEmpty();
        RuleFor(x => x.PasswordConfirm)
            .NotEmpty()
            .Equal(x => x.Password);
    }
}
