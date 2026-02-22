using System.Security.Cryptography;
using System.Text;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SkillShare.Application.Resources;
using SkillShare.Domain.Dto;
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
    private readonly IBaseRepository<Role> _roleRepository;
    private readonly IBaseRepository<UserToken> _userTokenRepository;
    private readonly IBaseRepository<UserRole> _userRoleRepository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;

    public AuthService(
        ITokenService tokenService,
        IBaseRepository<User> userRepozitory,
        ILogger logger,
        IMapper mapper,
        IBaseRepository<UserToken> userTokenRepository,
        IBaseRepository<Role> roleRepository,
        IBaseRepository<UserRole> userRoleRepository)
    {
        _userRepository = userRepozitory;
        _tokenService = tokenService;
        _logger = logger;
        _mapper = mapper;
        _userTokenRepository = userTokenRepository;
        _roleRepository = roleRepository;
        _userRoleRepository = userRoleRepository;
    }

    public async Task<DataResult<TokenDto>> Login(LoginUserDto dto, CancellationToken ct = default)
    {
        var user = await _userRepository.GetAll()
            .Include(x => x.UserToken)
            .Include(x => x.Roles)
            .FirstOrDefaultAsync(x => x.Login == dto.Login, ct);
        if (user == null)
        {
            return DataResult<TokenDto>.Failure((int)ErrorCodes.UserNotFound, ErrorMessage.UserNotFound);
        }

        if (!IsVerifyPassword(user.Password, dto.Password))
        {
            return DataResult<TokenDto>.Failure((int)ErrorCodes.PasswordIsWrong, ErrorMessage.PasswordIsWrong);
        }

        var claimsResult = _tokenService.GetClaimsFromUser(user);
        if (!claimsResult.IsSuccess)
        {
            return DataResult<TokenDto>.Failure(claimsResult.Error);
        }


        var accessToken = _tokenService.GenerateAccessToken(claimsResult.Data);
        var refreshToken = _tokenService.GenerateRefreshToken();

        if (user.UserToken == null)
        {
            var userToken = new UserToken()
            {
                UserId = user.Id,
                RefreshToken = refreshToken,
                RefreshTokenExpireTime = DateTime.UtcNow.AddDays(7),

            };
            await _userTokenRepository.CreateAsync(userToken);
        }
        else
        {
            user.UserToken.RefreshToken = refreshToken;
            user.UserToken.RefreshTokenExpireTime = DateTime.UtcNow.AddDays(7);
            await _userTokenRepository.UpdateAsync(user.UserToken);
        }

        var data = new TokenDto()
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };

        return DataResult<TokenDto>.Success(data);
    }


    public async Task<DataResult<UserDto>> Register(RegisterUserDto dto, CancellationToken ct = default)
    {
        var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Login == dto.Login, ct);
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

        var role = await _roleRepository.GetAll()
       .FirstOrDefaultAsync(x => x.Name == "Student", ct);

        if (role == null)
        {
            return DataResult<UserDto>.Failure((int)ErrorCodes.RoleNotFound, ErrorMessage.RoleNotFound);
        }

        var userRole = new UserRole
        {
            UserId = user.Id,
            RoleId = role.Id,
        };

        await _userRoleRepository.CreateAsync(userRole);

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

    private bool IsVerifyPassword(string PasswordHash, string userPassword)
    {
        var hash = HashPassword(userPassword);
        return PasswordHash == hash;
    }
}

