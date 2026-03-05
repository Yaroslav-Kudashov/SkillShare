namespace SkillShare.Domain.Interfaces;

/// <summary>
/// Интерфейс для проставления даты и времени у сущностей
/// </summary>
public interface IAuditable
{
    public DateTime CreatedAt { get; set; }

    public DateTime UpdateAt { get; set; }


}
