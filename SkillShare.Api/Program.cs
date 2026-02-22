using Microsoft.EntityFrameworkCore;
using Serilog;
using SkillShare.Api.Middlewares;
using SkillShare.Application.DependencyInjection;
using SkillShare.DAL;
using SkillShare.DAL.DependencyInjection;
using SkillShare.Domain.Settings;
namespace SkillShare.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.DefaultSection));

        builder.Services.AddDataAccessLayer(builder.Configuration);

        builder.Services.AddControllers();

        builder.Services.AddAuthenticationAndAuthorization(builder);

        builder.Services.AddSwagger();

        builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

        
        builder.Services.AddApplication();

        var app = builder.Build();

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SkillShare Swagger v 1.0");
                c.RoutePrefix = string.Empty;
            });
        }

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}
