using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillShare.Application.Queries;
using SkillShare.Domain.Dto.CourseDto;
using SkillShare.Domain.Enum;
using SkillShare.Domain.Interfaces.Services;
using SkillShare.Domain.Result;

namespace SkillShare.Api.Controllers;

/// <summary>
/// Контроллер по работе с курсами
/// </summary>
[Authorize(Roles = "Admin")]
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/courses")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    /// <summary>
    /// Получить курс по id учителя
    /// </summary>
    /// <param name="AuthorId"></param>
    /// <returns></returns>
    [HttpGet("User/{AuthorId}")]
    public async Task<ActionResult<CollectionResult<CourseDto>>> GetByIdAuthorCourse(long AuthorId)
    {
        var response = await _courseService.GetByAuthorIdAsync(AuthorId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }

    /// <summary>
    /// Получить курс по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<CourseDto>> GetCourse(int id)
    {
        var user = User;
        var response = await _courseService.GetByIdAsync(id);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }

    /// <summary>
    /// Получить все курсы в виде дерева
    /// </summary>
    /// <returns></returns>
    [HttpGet("tree")]
    public async Task<IActionResult> GetTree()
    {
        var response = await _courseService.GetCourseTreeAsync();
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }

    /// <summary>
    /// Удаление курса
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<ActionResult<DataResult<CourseDto>>> DeleteCourseById(int id)
    {
        var response = await _courseService.DeleteAsync(id);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }

    /// <summary>
    /// Создание курса
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="dto"></param>
    /// <remarks>
    /// Some info
    /// </remarks>
    [HttpPost]
    public async Task<ActionResult<DataResult<CourseDto>>> CreateCourse(long userId, CreateCourseDto dto)
    {
        var response = await _courseService.CreateAsync(userId, dto);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }

    /// <summary>
    /// Обновление курса
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<ActionResult<DataResult<CourseDto>>> UpdateCourse(UpdateCourseDto dto)
    {
        var response = await _courseService.UpdateAsync(dto);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }
}
