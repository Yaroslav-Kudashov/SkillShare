namespace SkillShare.Domain.Entities;

/// <summary>
/// Сущность для работы с оценками пользователей за курс
/// </summary>
public class UserCourseGrade
{
    public long Id { get; set; }

    public int CourseId { get; set; }

    public float Grade { get; set; }

    public long UserId { get; set; }

    public User User { get; set; }

    public Course Course { get; set; }
}

