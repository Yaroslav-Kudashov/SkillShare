using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillShare.Domain.Dto.CourseDto;
using SkillShare.Domain.Result;

namespace SkillShare.Domain.Interfaces.Services;

public interface ICourseService
{
    /// <summary>
    /// Получение всех курсов
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<DataResult<CourseDto>> GetByIdAsync(long courseId, CancellationToken ct = default);

    /// <summary>
    /// Получение курса по Id учителя
    /// </summary>
    /// <param name="courseId"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<CollectionResult<CourseDto>> GetByAuthorIdAsync(long AuthorId, CancellationToken ct = default);

    /// <summary>
    /// Создание курса с базовыми параметрами
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<DataResult<CourseDto>> CreateAsync(long userId, CreateCourseDto dto, CancellationToken ct = default);


    /// <summary>
    /// Удаление курса по Id 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<DataResult<CourseDto>> DeleteAsync(long id, CancellationToken ct = default);

    /// <summary>
    /// Обновление курса
    /// </summary>
    /// <param name=""></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<DataResult<CourseDto>> UpdateAsync(UpdateCourseDto dto, CancellationToken ct = default);
}
