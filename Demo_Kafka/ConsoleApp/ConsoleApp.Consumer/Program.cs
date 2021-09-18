using System;

namespace ConsoleApp.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Consumer start...");

            KafkaConsumer Consumer = new KafkaConsumer();

            Consumer.ReciveMessage();
        }
    }
}
