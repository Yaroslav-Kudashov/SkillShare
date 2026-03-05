namespace SkillShare.Producer.Interfaces;

/// /// <summary>
/// Интерфейс Producer для работы с отправкой сообщений в RabbitMq
/// </summary>
public interface IMessageProducer
{
    void SendMessage<T>(T message, string routingKey, string? exchange = default);
}
