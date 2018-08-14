using System;
using RabbitMQ.Client;
using MicroServices.Functions;
using MicroServices.Models;

namespace MicroServices
{
    class Program
    {
        private static ConnectionFactory _factory;
        private static IConnection _connection;
        private static IModel _model;
        private static QueueingBasicConsumer _consumer;

        private const string ExchangeName = "MessagingDirect_Exchange";
        private const string FatherQueueName = "Father_Queue";
        private const string SonQueueName = "Son_Queue";
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            IPerson son = new Son(name, "Son");

            CreateConnection();

            SendMessage(son);
            fatherResponse();

            Console.ReadLine();
        }

        private static void CreateConnection()
        {
            _factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest" };
            _connection = _factory.CreateConnection();
            _model = _connection.CreateModel();
            _model.ExchangeDeclare(ExchangeName, "direct");                             //Create Exchange (which is a direct exchange)
            _model.QueueDeclare(SonQueueName, true, false, false, null);          //Create Queue
            _model.QueueBind(SonQueueName, ExchangeName, "Son");            //Bind Queue to Exchange created above
        }

        private static void SendMessage(IPerson person)
        {
            _model.BasicPublish(ExchangeName, "Son", null, person.Serialize());   //Send message
        } 
        
        private static void fatherResponse()
        {
            var channel = _connection.CreateModel();
            channel.ExchangeDeclare(ExchangeName, "direct");
            channel.QueueDeclare(FatherQueueName, true, false, false, null);
            channel.QueueBind(FatherQueueName, ExchangeName, "Father");
            channel.BasicQos(0, 1, false);

            _consumer = new QueueingBasicConsumer(channel);
            channel.BasicConsume(FatherQueueName, true, _consumer);
            var ea = _consumer.Queue.Dequeue();
            IPerson messenger = (Father)ea.Body.DeSerialize(typeof(Father));
            Console.WriteLine(messenger.GreetingMessage());
        }
    }
}
