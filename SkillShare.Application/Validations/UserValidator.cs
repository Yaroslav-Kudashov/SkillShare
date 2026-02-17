using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillShare.Domain.Entities;
using SkillShare.Domain.Interfaces.Validations;
using SkillShare.Domain.Result;

namespace SkillShare.Application.Validations;

public class UserValidator : IUserValidator
{
    public BaseResult ValidateRegister(User model)
    {
        throw new NotImplementedException();
    }

    public BaseResult ValidatorPassword(User user)
    {
        throw new NotImplementedException();
    }
}
