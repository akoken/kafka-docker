using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kafka.ConsumerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new KafkaOptions(new Uri("http://192.168.0.1:9092/"), new Uri("http://192.168.0.1:9093/"), new Uri("http://192.168.0.1:9094/"));

            using (var router = new BrokerRouter(options))
            {
                using (var consumer = new Consumer(new ConsumerOptions("test-topic", router)))
                {
                    IEnumerable<Message> messages = consumer.Consume();
                    foreach (var message in messages)
                    {
                        Console.WriteLine("Partition Id:{0}, Offset:{1}, Message:{2}",
                            message.Meta.PartitionId, message.Meta.Offset, Encoding.UTF8.GetString(message.Value));
                    }
                }
            }
        }
    }
}
