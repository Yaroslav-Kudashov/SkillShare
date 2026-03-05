using SkillShare.Domain.Enum;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Domain.Entities;

/// <summary>
/// Сущность для работы с вопросами к урокам 
/// </summary>
public class Question : IEntityId<int>, IAuditable
{ 
    public int Id { get; set; }

    public int LessonId { get; set; }

    public string Description { get; set; }

    public float Score { get; set; }

    public string CorrectAnswer { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdateAt { get; set; }

    public Difficult Difficult { get; set; }

    public Lesson Lesson { get; set; }

    public List<StudentAnswer> StudentAnswers { get; set; }
}
