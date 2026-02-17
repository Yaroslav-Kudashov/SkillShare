using SkillShare.Application.Resources;
using SkillShare.Domain.Dto.User;
using SkillShare.Domain.Entities;
using SkillShare.Domain.Enum;
using SkillShare.Domain.Interfaces.Validations;
using SkillShare.Domain.Result;

namespace SkillShare.Application.Validations;

public class CourseValidator : ICourseValidator
{
    public BaseResult ValidatorCreate(Course course, User user)
    {
        if (course != null)
        {
            return BaseResult.Failure((int)ErrorCodes.CourseAlreadyExists, ErrorMessage.CourseAlreadyExists);
        }

        if (user == null)
        {
            return DataResult<UserDto>.Failure((int)ErrorCodes.UserNotFound, ErrorMessage.UserNotFound);
        }
        return BaseResult.Success();
    }


    public BaseResult ValidateOnNull(Course model)
    {
        if (model == null)
        {
            return BaseResult.Failure((int)ErrorCodes.CourseNotFound, ErrorMessage.CourseNotFound);
        }
        return BaseResult.Success();
    }
}
