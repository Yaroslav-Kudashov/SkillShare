namespace SkillShare.Domain.Entities;

/// <summary>
/// Сущность для работы с ролями пользователей
/// </summary>
public class UserRole 
{
    public long UserId { get; set; }

    public int RoleId { get; set; }
}
