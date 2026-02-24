using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillShare.Domain.Settings;

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
