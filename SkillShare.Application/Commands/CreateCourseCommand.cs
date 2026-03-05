using MediatR;
using SkillShare.Domain.Entities;

namespace SkillShare.Application.Commands;

/// <summary>
/// Данные создания курса
/// </summary>
/// <param name="Title"></param>
/// <param name="Description"></param>
/// <param name="Price"></param>
/// <param name="ParentId"></param>
/// <param name="UserId"></param>
public record CreateCourseCommand(string Title, string Description, decimal Price, int? ParentId, long UserId) : IRequest<Course>;

