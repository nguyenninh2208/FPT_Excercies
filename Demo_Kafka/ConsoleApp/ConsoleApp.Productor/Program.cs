using System;
using System.Threading.Tasks;

namespace ConsoleApp.Productor
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Productor start...");
            await KafkaProductor.SendMessage();

            Console.ReadKey();
        }
    }
}
