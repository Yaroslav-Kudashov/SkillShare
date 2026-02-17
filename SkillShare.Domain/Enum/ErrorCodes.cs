using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillShare.Domain.Enum;

public enum ErrorCodes
{
    UserNotFound = 1001,
    UserAlreadyExists = 1002,

    CourseNotFound = 2001,
    CourseAlreadyExists = 2002,

    PasswordNotEqualsPasswordConfirm = 3001

}
