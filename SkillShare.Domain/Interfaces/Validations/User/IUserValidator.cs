using SkillShare.Domain.Entities;
using SkillShare.Domain.Result;

namespace SkillShare.Domain.Interfaces.Validations;

public interface IUserValidator : IBaseUserValidator<User>
{
    /// <summary>
    /// Проверяется наличие юзера, если юзер с таким логином существует, зарегистрировать такого же нельзя
    /// Проверяет совпадаю ли пароли
    /// </summary>
    /// <param name="course"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    BaseResult ValidatorRegister(User user);
}


