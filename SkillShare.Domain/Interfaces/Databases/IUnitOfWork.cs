using Microsoft.EntityFrameworkCore.Storage;
using SkillShare.Domain.Entities;
using SkillShare.Domain.Interfaces.Repositories;

namespace SkillShare.Domain.Interfaces.Databases;

/// <summary>
/// Интерфейс класса общего репозитория для сущностей и методов
/// </summary>
public interface IUnitOfWork : IStateSaveChanges
{
    /// <summary>
    /// Создание метода для начала транзакции
    /// </summary>
    /// <returns></returns>
    Task<IDbContextTransaction> BeginTransactionAsync();


    /// <summary>
    /// Создание репозиториев
    /// </summary>
    IBaseRepository<User> Users { get; set; }

    IBaseRepository<Role> Roles { get; set; }

    IBaseRepository<UserRole> UserRoles { get; set; }

    IBaseRepository<Course> Courses { get; set; }

    IBaseRepository<Lesson> Lessons { get; set; }

    IBaseRepository<Question> Questions { get; set; }

    IBaseRepository<StudentAnswer> StudentAnswers { get; set; }

    IBaseRepository<UserCourseGrade> UserCourseGrades { get; set; }

    IBaseRepository<UserToken> UserTokens { get; set; }
}
