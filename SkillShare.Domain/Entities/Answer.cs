using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillShare.Domain.Entities;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Domain.Entities;

public class Answer : IEntityId<long>, IAuditable
{
    public long Id { get; set; }

    public long QuestionId { get; set; }

    public string Value { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdateAt { get; set; }

    public Question Question { get; set; }
}
