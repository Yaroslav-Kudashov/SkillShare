using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SkillShare.Domain.Interfaces;

namespace SkillShare.DAL.Interceptors;

public class DateInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        var dbcontex = eventData.Context;
        if (dbcontex == null)
        {
            return base.SavingChanges(eventData, result);
        }

        var entries = dbcontex.ChangeTracker.Entries<IAuditable>();
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(x => x.CreatedAt).CurrentValue = DateTime.UtcNow;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property(x => x.UpdateAt).CurrentValue = DateTime.UtcNow;
            }
        }


        return base.SavingChanges(eventData, result);
    }
}

