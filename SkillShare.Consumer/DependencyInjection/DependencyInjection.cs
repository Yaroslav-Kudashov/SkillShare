using Microsoft.Extensions.DependencyInjection;

namespace SkillShare.Consumer.DependencyInjection;

/// <summary>
/// Регистрация 
/// </summary>
public static class DependencyInjection
{
    public static void AddConsumer(this IServiceCollection services)
    {
        services.AddHostedService<RabbitMqListener>();
    }
}
