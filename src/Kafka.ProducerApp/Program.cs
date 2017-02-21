using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;
using System;

namespace Kafka.ProducerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new KafkaOptions(new Uri("http://localhost:9092/"));
            using (var router = new BrokerRouter(options))
            {
                using (var client = new Producer(router))
                {
                    client.SendMessageAsync("TestTopic", new[] { new Message("Hello world!") }).Wait();
                    Console.WriteLine("Message has been sent..");
                }
            }
            Console.ReadKey();
        }
    }
}
