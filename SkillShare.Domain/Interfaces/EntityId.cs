namespace SkillShare.Domain.Interfaces;

/// <summary>
/// Автоинкремент
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IEntityId<T> where T : struct
{
   public T Id { get; set; }
}
