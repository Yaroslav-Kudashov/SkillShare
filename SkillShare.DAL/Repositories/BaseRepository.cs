using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SkillShare.Domain.Interfaces.Repositories;

namespace SkillShare.DAL.Repositories;

/// <summary>
/// <Базовый репозиторий для работы с сущностями 
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _DbContex;
    private readonly DbSet<TEntity> _dbSet;

    public BaseRepository(ApplicationDbContext dbContex)
    {
        _DbContex = dbContex;
        _dbSet = dbContex.Set<TEntity>();
    }

    /// <summary>
    /// Получение
    /// </summary>
    /// <returns></returns>
    public IQueryable<TEntity> GetAll()
    {
        return _DbContex.Set<TEntity>();
    }

    /// <summary>
    /// Создание
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException("Entity is null");

          await _DbContex.AddAsync(entity);

        return entity;
    }

    /// <summary>
    /// Удаление
    /// </summary>
    /// <param name="entity"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void Remove(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException("Entity is null");

        _DbContex.Remove(entity);
    }

    /// <summary>
    /// Обновление
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public  TEntity Update(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException("Entity is null");

        _DbContex.Update(entity);

        return entity;
    }

    /// <summary>
    /// Сохранение
    /// </summary>
    /// <returns></returns>
    public async Task<int> SaveChangesAsync()
    {
        return await _DbContex.SaveChangesAsync();
    }

    /// <summary>
    /// Удобное получение
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default)
    {
        return await _dbSet.AnyAsync(predicate, ct);
    }

    /// <summary>
    /// Создание в цикле
    /// </summary>
    /// <param name="entities"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public async Task CreateRangeAsync(IEnumerable<TEntity> entities, CancellationToken ct = default)
    {
        await _dbSet.AddRangeAsync(entities, ct);
    }
}
