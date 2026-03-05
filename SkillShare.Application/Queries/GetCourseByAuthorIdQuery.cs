using MediatR;
using SkillShare.Domain.Dto.CourseDto;

namespace SkillShare.Application.Queries;

/// <summary>
/// Получение курса по id учителя
/// </summary>
/// <param name="authorId"></param>
public class GetCourseByAuthorIdQuery(long authorId) : IRequest<IEnumerable<CourseDto>>
{
    public long AuthorId { get; set; } = authorId;
}; 
