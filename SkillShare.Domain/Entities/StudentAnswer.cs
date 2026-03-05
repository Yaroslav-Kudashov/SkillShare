using SkillShare.Domain.Interfaces;

namespace SkillShare.Domain.Entities;

/// <summary>
/// Сущность для работы с ответами студентов на вопросы
/// </summary>
public class StudentAnswer : IEntityId<long>, IAuditable
{
    public long Id { get; set; }

    public long? TeacherId { get; set; }

    public int QuestionId { get; set; }

    public long StudentId { get; set; }

    public float Score { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdateAt { get; set; }

    public User Teacher { get; set; }

    public User Student { get; set; }

    public Question Question { get; set; }

}
