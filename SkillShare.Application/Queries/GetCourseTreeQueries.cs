using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SkillShare.Domain.Dto.Course;
using SkillShare.Domain.Result;

namespace SkillShare.Application.Queries;

/// <summary>
/// Получение всех курсов в виде дерева
/// </summary>
public record GetCourseTreeQuery() : IRequest<CollectionResult<CourseNodeDto>>;
