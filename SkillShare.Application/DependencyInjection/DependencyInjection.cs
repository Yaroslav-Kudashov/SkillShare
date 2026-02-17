using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using SkillShare.Application.Services;
using SkillShare.Application.Validations;
using SkillShare.Application.Validations.FluentValidations.Course;
using SkillShare.Domain.Dto.CourseDto;
using SkillShare.Domain.Interfaces.Services;
using SkillShare.Domain.Interfaces.Validations.Course;

namespace SkillShare.Application.DependencyInjection;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        InitMapsterMapping(services);

        initServices(services);
    }

    public static void initServices(this IServiceCollection services)
    {
        services.AddScoped<ICourseValidator, CourseValidator>();
        services.AddScoped<IValidator<CreateCourseDto>, CreateCourseValidator>();
        services.AddScoped<IValidator<UpdateCourseDto>, UpdateCourseValidator>();
        services.AddScoped<ICourseService, CourseService>();
    }

    private static void InitMapsterMapping(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
    }



}
