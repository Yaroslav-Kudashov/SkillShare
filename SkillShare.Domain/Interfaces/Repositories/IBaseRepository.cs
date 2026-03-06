using System.Linq.Expressions;
using SkillShare.Domain.Interfaces.Databases;

namespace SkillShare.Domain.Interfaces.Repositories;

/// <summary>
/// Интерфейс базового репозитория для работы с сущностями
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IBaseRepository<TEntity> : IStateSaveChanges
{
    /// <summary>
    /// получение всех сущностей
    /// </summary>
    /// <returns></returns>
    IQueryable<TEntity> GetAll();

    /// <summary>
    /// Создание
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<TEntity> CreateAsync(TEntity entity);

    /// <summary>
    /// Обновление
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    TEntity Update(TEntity entity);

    /// <summary>
    /// Удаление
    /// </summary>
    /// <param name="entity"></param>
    void Remove(TEntity entity);

    /// <summary>
    /// Проверить есть ли сущность с условием из <see cref="predicate" />
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default);

    /// <summary>
    /// Массовое добавление сущностей
    /// </summary>
    Task CreateRangeAsync(IEnumerable<TEntity> entities, CancellationToken ct = default);
}
