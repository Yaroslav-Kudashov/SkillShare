using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillShare.Domain.Dto.Course;

public class CourseNodeDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? ParentId { get; set; }

    public List<CourseNodeDto> Children { get; set; } = new();
}