using System.Security.Cryptography;
using System.Text;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SkillShare.Application.Resources;
using SkillShare.Domain.Dto;
using SkillShare.Domain.Dto.CourseDto;
using SkillShare.Domain.Dto.User;
using SkillShare.Domain.Entities;
using SkillShare.Domain.Enum;
using SkillShare.Domain.Interfaces.Repositories;
using SkillShare.Domain.Interfaces.Services;
using SkillShare.Domain.Result;

namespace SkillShare.Application.Services;

public class AuthService : IAuthService
{
    private readonly IBaseRepository<User> _userRepository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public AuthService(IBaseRepository<User> userRepozitory, ILogger logger, IMapper mapper)
    {
        _userRepository = userRepozitory;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<DataResult<TokenDto>> Login(LoginUserDto dto, CancellationToken ct = default)
    {

    }

    public async Task<DataResult<UserDto>> Register(RegisterUserDto dto, CancellationToken ct = default)
    {
        if (dto.Password != dto.PasswordConfirm)
        {
            return DataResult<UserDto>.Failure((int)ErrorCodes.PasswordNotEqualsPasswordConfirm, ErrorMessage.PasswordNotEqualsPasswordConfirm);
        }

        var user = await _userRepository.GetAll().Where(x => x.Login == dto.Login).FirstOrDefaultAsync(ct);
        if (user != null)
        {
            return DataResult<UserDto>.Failure((int)ErrorCodes.UserAlreadyExists, ErrorMessage.UserAlreadyExists);
        };

        var passwordHash = HashPassword(dto.Password);
        user = new User()
        {
            Login = dto.Login,
            Password = passwordHash,
            Age = dto.Age,
            Email = dto.Email,
            Name = dto.Name,
            LastName = dto.LastName
        };
        await _userRepository.CreateAsync(user);

        return DataResult<UserDto>.Success(_mapper.Map<UserDto>(user));
    }


    /// <summary>
    /// Хеширование пароля
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    private string HashPassword(string password)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return BitConverter.ToString(bytes).ToLower();
    }

}

