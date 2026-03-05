using SkillShare.Domain.Result;

namespace SkillShare.Domain.Interfaces.Validations;

/// <summary>
/// Проверка на null
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IBaseValidator<in T> where T : class
{
    BaseResult ValidateOnNull(T model);
}
