using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp.Consumer
{
  public  class KafkaConsumer
    {
        public const String HOST = "kafka.haipv.com:9092";
        public const String KAFKA_TOPIC_NAME = "su10_new_member";
        public const String CONSUMER_GROUP_ID = "test-consumer-group";

        public void ReciveMessage()
        {
            Console.WriteLine("Waiting...");

            ConsumerConfig conf = new ConsumerConfig
            {
                GroupId = CONSUMER_GROUP_ID,
                BootstrapServers = HOST,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var Consumer = new ConsumerBuilder<Null, string>(conf).Build();
            {

                Consumer.Subscribe(KAFKA_TOPIC_NAME);

                CancellationTokenSource Cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) => {
                    e.Cancel = true;
                    Cts.Cancel();
                };

                try
                {
                    while (true)
                    {
                        try
                        {
                            var Message = Consumer.Consume(Cts.Token);
                            Console.WriteLine($"Recieve  {Message.Message.Value}");
                        }
                        catch (ConsumeException e)
                        {
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    Consumer.Close();
                }
            }
        }
    }
}
