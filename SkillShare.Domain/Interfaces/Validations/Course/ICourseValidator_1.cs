using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillShare.Domain.Entities;
using SkillShare.Domain.Result;

namespace SkillShare.Domain.Interfaces.Validations;

public interface ICourseValidator<in T> where T : class
{
    /// <summary>
    /// Проверяется наличие курса, если курс с таким названием есть в БД, создать такой же нельзя
    /// Проверяет пользователя, если с UserId пользователь не найден, то такого пользователя нет
    /// </summary>
    /// <param name="course"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    BaseResult ValidatorCreate(Course course, User user);
    BaseResult ValidateOnNull(T model);
    
}
