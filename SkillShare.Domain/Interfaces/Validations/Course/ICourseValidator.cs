using SkillShare.Domain.Entities;
using SkillShare.Domain.Result;

namespace SkillShare.Domain.Interfaces.Validations;

public interface ICourseValidator : IBaseValidator<Course>
{
    /// <summary>
    /// Проверяется наличие курса, если курс с таким названием есть в БД, создать такой же нельзя
    /// Проверяет пользователя, если с UserId пользователь не найден, то такого пользователя нет
    /// </summary>
    /// <param name="course"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    BaseResult ValidatorCreate(Course course, User user);
}
