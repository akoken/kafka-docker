using KafkaNet;
using KafkaNet.Model;
using System;
using System.Text;

namespace Kafka.ConsumerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new KafkaOptions(new Uri("http://localhost:9092/"));
            using (var router = new BrokerRouter(options))
            {
                using (var consumer = new Consumer(new ConsumerOptions("TestTopic", router)))
                {
                    foreach (var message in consumer.Consume())
                    {
                        Console.WriteLine("Partition Id:{0}, Offset:{1}, Message:{2}",
                            message.Meta.PartitionId, message.Meta.Offset, Encoding.UTF8.GetString(message.Value));
                    }
                    Console.ReadKey();
                }
            }
        }
    }
}
