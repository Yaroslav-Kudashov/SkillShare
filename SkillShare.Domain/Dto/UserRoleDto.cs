using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillShare.Domain.Dto
{
    public record UserRoleDto(int RoleId, int UserId, int login, string RoleName);
}
