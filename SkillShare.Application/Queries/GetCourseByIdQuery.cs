using MediatR;
using SkillShare.Domain.Dto.CourseDto;

namespace SkillShare.Application.Queries;

/// <summary>
/// Получение курса по id
/// </summary>
/// <param name="courseId"></param>
public class GetCourseQuery(int courseId) : IRequest<CourseDto?>
{
    public int CourseId { get; set; } = courseId;
}

