namespace SkillShare.Domain.Settings;

/// <summary>
/// Класс для настройки RabbitMq
/// </summary>
public class RabbitMqSettings
{
    public string HostName { get; set; }

    public int Port { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; } 

    public string QueueName { get; set; } 

    public string RoutingKey { get; set; }

    public string ExchangeName { get; set; } 
}
