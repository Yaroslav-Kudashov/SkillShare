using SkillShare.Domain.Interfaces;

namespace SkillShare.Domain.Entities;

public class User : IEntityId<long>, IAuditable
{
    public long Id { get; set; }
    public string Login {  get; set; }

    public string Name { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public int Age { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdateAt { get; set; }


    public List<Role> Roles { get; set; }

    public UserToken UserToken { get; set; }

    public List<Course> Courses { get; set; }

    public UserRole UserRole { get; set; }
}
