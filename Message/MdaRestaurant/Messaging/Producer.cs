using System.Text;
using RabbitMQ.Client;

namespace Messaging;

public class Producer
{
    private readonly string _queueName;

    public Producer(string queueName)
    {
        _queueName = queueName;
    }

    public void Send(string message)
    {
        var factory = new ConnectionFactory()
        {
            HostName = RabbitMqConnectionSettings.HostName,
            Port = RabbitMqConnectionSettings.Port,
            UserName = RabbitMqConnectionSettings.UserAndVHost,
            Password = RabbitMqConnectionSettings.Password,
            VirtualHost = RabbitMqConnectionSettings.UserAndVHost
        };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.ExchangeDeclare(
            RabbitMqConnectionSettings.DidrectExchengeName,
            ExchangeType.Direct,
            false,
            false,
            null
        );

        var body = Encoding.UTF8.GetBytes(message); // формируем тело сообщения для отправки

        channel.BasicPublish(
            exchange: RabbitMqConnectionSettings.DidrectExchengeName,
            routingKey: _queueName,
            basicProperties: null,
            body: body); //отправляем сообщение
    }
}