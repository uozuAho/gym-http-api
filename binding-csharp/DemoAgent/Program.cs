using System;
using System.Threading.Tasks;
using AiGym.Client;

namespace DemoAgent
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var client = CreateClient();

            var environmentName = "CartPole-v0";
            var environmentId = await client.CreateEnvironment(environmentName);

            Console.WriteLine($"Created environment with id: {environmentId}");
        }

        private static IAiGymClient CreateClient()
        {
            return new HttpAiGymClient("http://127.0.0.1:5000");
        }
    }
}
