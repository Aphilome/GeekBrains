﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Threading.Channels;

namespace Messaging;

public class Consumer : IDisposable
{
    private readonly string _queueName; //название очереди

    private readonly IConnection _connection;
    private readonly IModel _channel;

    public Consumer(string queueName)
    {
        var factory = new ConnectionFactory()
        {
            HostName = RabbitMqConnectionSettings.HostName,
            Port = RabbitMqConnectionSettings.Port,
            UserName = RabbitMqConnectionSettings.UserAndVHost,
            Password = RabbitMqConnectionSettings.Password,
            VirtualHost = RabbitMqConnectionSettings.UserAndVHost
        };
        _connection = factory.CreateConnection(); //создаем подключение
        _channel = _connection.CreateModel();
        _queueName = _channel.QueueDeclare().QueueName;
    }

    public void Receive(EventHandler<BasicDeliverEventArgs> receiveCallback)
    {
        _channel.ExchangeDeclare(
            exchange: RabbitMqConnectionSettings.DidrectExchengeName,
            type: ExchangeType.Fanout); // объявляем обменник

        //_channel.QueueDeclare(queue: _queueName,
        //    durable: false,
        //    exclusive: false,
        //    autoDelete: false,
        //    arguments: null); //объявляем очередь

        _channel.QueueBind(
            queue: _queueName,
            exchange: RabbitMqConnectionSettings.DidrectExchengeName,
            routingKey: string.Empty); //биндим

        var consumer = new EventingBasicConsumer(_channel); // создаем consumer для канала
        consumer.Received += receiveCallback; // добавляем обработчик события приема сообщения

        _channel.BasicConsume(
            queue: _queueName, 
            autoAck: true, 
            consumer: consumer); //стартуем!
    }

    public void Dispose()
    {
        _connection?.Dispose();
        _channel?.Dispose();
    }
}