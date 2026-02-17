using SkillShare.Domain.Interfaces;

namespace SkillShare.Domain.Entities;

public class Course : IEntityId<int>, IAuditable
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public long ?ParentId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdateAt { get; set; }

    public long AuthorId { get; set; }

    public User Author { get; set; }  

    public List<Lesson> Lessons { get; set; }   
}
