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
            var options = new KafkaOptions(new Uri("http://192.168.0.1:9092/"), new Uri("http://192.168.0.1:9093/"), new Uri("http://192.168.0.1:9094/"));

            using (var router = new BrokerRouter(options))
            {
                using (var client = new Producer(router))
                {
                    client.SendMessageAsync("test-topic", new[] { new Message("Hello World!") }).Wait();
                    Console.WriteLine("Message has been sent.");
                }
            }
        }
    }
}
