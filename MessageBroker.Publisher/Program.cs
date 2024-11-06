using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection(); 
using var channel = connection.CreateModel();

var queue = "hello";
channel.QueueDeclare(
    queue: queue, 
    durable: false, 
    exclusive: false, 
    autoDelete: false, 
    arguments: null
);

Console.WriteLine("Digite sua mensagem e aperte <ENTER>");

var student = new Student { Id = 1, Name = "John Doe"};

while (true)
{
    string messageStr = Console.ReadLine();
    if (string.IsNullOrEmpty(messageStr))
        break;
    
    var message = new Message(messageStr, student);
    var json = JsonSerializer.Serialize(message);
    var body = Encoding.UTF8.GetBytes(json);
    
    channel.BasicPublish(exchange: string.Empty, routingKey: queue, basicProperties: null, body: body);
    
    Console.WriteLine($" [x] Enviado {message}");
}

public class Message
{
    public Message(string message, Student student)
    {
        Text = message;
        Student = student;
    }

    public int Id { get; set; } = new Random().Next(1000);
    public string Text { get; set; }
    public Student Student { get; set; }

}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
}