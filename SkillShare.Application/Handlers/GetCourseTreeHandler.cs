using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SkillShare.Application.Queries;
using SkillShare.Domain.Dto.Course;
using SkillShare.Domain.Interfaces.Databases;
using SkillShare.Domain.Interfaces.Services;
using SkillShare.Domain.Result;

namespace SkillShare.Application.Handlers;

/// <summary>
/// Логика получения всех курсов в виде дерева
/// </summary>
public class GetCourseTreeHandler : IRequestHandler<GetCourseTreeQuery, CollectionResult<CourseNodeDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCourseTreeHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CollectionResult<CourseNodeDto>> Handle(GetCourseTreeQuery request, CancellationToken ct)
    {
        var allCourses = await _unitOfWork.Courses.GetAll()
            .AsNoTracking()
            .Select(c => new CourseNodeDto
            {
                Id = c.Id,
                Name = c.Title,
                ParentId = c.ParentId 
            })
            .ToListAsync(ct);

        if (!allCourses.Any())
        {
            return CollectionResult<CourseNodeDto>.Success(new List<CourseNodeDto>());
        }

        var lookup = allCourses.ToDictionary(c => c.Id);
        var rootNodes = new List<CourseNodeDto>();

        foreach (var course in allCourses)
        {
            if (course.ParentId == null)
            {
                rootNodes.Add(course);
            }
            else
            {
                if (lookup.TryGetValue(course.ParentId.Value, out var parent))
                {
                    parent.Children.Add(course);
                }
            }
        }

        return CollectionResult<CourseNodeDto>.Success(rootNodes);
    }
}
