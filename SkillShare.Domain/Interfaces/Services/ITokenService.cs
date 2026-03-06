using System.Security.Claims;
using SkillShare.Domain.Dto.Token;
using SkillShare.Domain.Entities;
using SkillShare.Domain.Result;

namespace SkillShare.Domain.Interfaces.Services;

/// <summary>
/// Интерфейс сервиса 
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// Генерация access токена
    /// </summary>
    /// <param name="claims"></param>
    /// <returns></returns>
    string GenerateAccessToken(IEnumerable<Claim> claims);

    /// <summary>
    /// Генерация Refresh токена
    /// </summary>
    /// <returns></returns>
    string GenerateRefreshToken();

    /// <summary>
    /// Получение клаймов
    /// </summary>
    /// <param name="accessToken"></param>
    /// <returns></returns>
    DataResult<ClaimsPrincipal> GetPrincipalFromExpiredToken(string accessToken);

    /// <summary>
    /// Обновление токена
    /// </summary>
    /// <param name="Dto"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<DataResult<TokenDto>> RefreshToken(TokenDto Dto, CancellationToken ct = default);

    /// <summary>
    /// Получение клаймов для пользователя
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    CollectionResult<Claim> GetClaimsFromUser(User user);
}
