using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp.Productor
{

    public class KafkaProductor
    {
        public const String HOST = "kafka.haipv.com:9092";
        public const String KAFKA_TOPIC_NAME = "su10_new_member";
        public const int TIME_DELAY = 1000;

        public static async Task SendMessage()
        {
            var Conf = new ProducerConfig { BootstrapServers = HOST };

            using var Producer = new ProducerBuilder<Null, string>(Conf).Build();
            {
                try
                {
                    var random = new Random();
                    string[] arr = new[] { "Have you heard the phrase", "Its originator is American labor", "Dolores Huerta", "Want to discover random articles from Wikipedia everyday" };
                    while (true)
                    {
                        string mes = arr[random.Next(0, arr.Length)];
                        var Message = await Producer.ProduceAsync(KAFKA_TOPIC_NAME,
                            new Message<Null, string> { Value = $"{mes}"});
                        Console.WriteLine($"Send {mes}");
                        Thread.Sleep(TIME_DELAY);
                    }
                }
                catch (ProduceException<Null, string> e)
                {
                  
                }
            }
        }
    }
}
