using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillShare.Domain.Entities;
using SkillShare.Domain.Result;

namespace SkillShare.Domain.Interfaces.Validations;

public interface IBaseUserValidator<in T> where T : class
{
    BaseResult ValidatorPassword(User user);
    BaseResult ValidateRegister(T model);
}


