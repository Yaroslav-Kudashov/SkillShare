using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillShare.Domain.Dto.User;

public record RegisterUserDto(string Login, string Password, string PasswordConfirm,string Name, string LastName, string Email, int Age);

