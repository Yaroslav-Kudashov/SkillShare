using MediatR;
using SkillShare.Domain.Entities;

namespace SkillShare.Application.Commands;

/// <summary>
/// Данные обновления курса
/// </summary>
/// <param name="Id"></param>
/// <param name="Title"></param>
/// <param name="Description"></param>
/// <param name="Price"></param>
public record UpdateCourseCommand(int Id, string Title, string Description, decimal Price) : IRequest<Course>;
