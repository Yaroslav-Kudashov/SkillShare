namespace SkillShare.Domain.Interfaces.Databases;

/// <summary>
/// Создание метода для сохранения изменений 
/// </summary>
public interface IStateSaveChanges
{
    Task<int> SaveChangesAsync();
}
