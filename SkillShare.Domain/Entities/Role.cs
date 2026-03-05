using SkillShare.Domain.Interfaces;

namespace SkillShare.Domain.Entities;

/// <summary>
/// Сущность для определения ролей у пользователей
/// </summary>
public class Role : IEntityId<int>
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<User> Users { get; set; }

}
