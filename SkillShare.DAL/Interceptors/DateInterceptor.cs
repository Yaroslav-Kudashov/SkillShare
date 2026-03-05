using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SkillShare.Domain.Interfaces;

namespace SkillShare.DAL.Interceptors;

/// <summary>
/// Интерсептор для автоматической проставлении даты и времени при создании и обновлении сущностей
/// </summary>
public class DateInterceptor : SaveChangesInterceptor
{
    // Синхронный метод (для SaveChanges)
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        UpdateAuditableEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    // Асинхронный метод (для SaveChangesAsync) 
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        UpdateAuditableEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }


    /// <summary>
    /// Для обновления
    /// </summary>
    /// <param name="context"></param>
    private void UpdateAuditableEntities(DbContext? context)
    {
        if (context == null) return;

        var entries = context.ChangeTracker
            .Entries<IAuditable>()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(x => x.CreatedAt).CurrentValue = DateTime.UtcNow;
                entry.Property(x => x.UpdateAt).CurrentValue = DateTime.UtcNow;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property(x => x.UpdateAt).CurrentValue = DateTime.UtcNow;
                entry.Property(x => x.CreatedAt).IsModified = false;
            }
        }
    }
}


