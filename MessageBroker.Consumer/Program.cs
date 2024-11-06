
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory();
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

var queue = "hello";
channel.QueueDeclare(
    queue: queue,
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null);
    
Console.WriteLine($" [*] Aguardando mensagens...");

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    
    Console.WriteLine($" [x] Mensagem recebida: {message}");
};
channel.BasicConsume(queue: queue, autoAck: true, consumer: consumer);

Console.WriteLine(" Aperte [Enter] para sair");
Console.ReadLine();
