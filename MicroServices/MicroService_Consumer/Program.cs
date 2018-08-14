using System;
using RabbitMQ.Client;
using MicroService_Consumer.Functions;
using MicroService_Consumer.Models;

namespace MicroService_Consumer
{
    class Program
    {
        private static IConnectionFactory _factory;
        private static IConnection _connection;
        private static QueueingBasicConsumer _consumer;

        private const string ExchangeName = "MessagingDirect_Exchange";
        private const string FatherQueueName = "Father_Queue";
        private const string SonQueueName = "Son_Queue";

        static void Main(string[] args)
        {
            _factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest" };
            using (_connection = _factory.CreateConnection())
            {
                using (var channel = _connection.CreateModel())
                {
                    channel.ExchangeDeclare(ExchangeName, "direct");
                    channel.QueueDeclare(SonQueueName, true, false, false, null);
                    channel.QueueBind(SonQueueName, ExchangeName, "Son");
                    channel.BasicQos(0, 1, false);

                    _consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(SonQueueName, true, _consumer);
                                       
                    var ea = _consumer.Queue.Dequeue();
                    IPerson messenger = (Son)ea.Body.DeSerialize(typeof(Son));
                    IPerson sender = new Father("James", messenger.GetName());
                    channel.BasicPublish(ExchangeName, "Father", null, sender.Serialize());

                    Console.WriteLine(messenger.GreetingMessage());                                            

                    Console.ReadLine();
                }
            }
        }       
    }
}
