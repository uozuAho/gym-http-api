using System;
using System.Threading.Tasks;
using AiGym.Client;
using AiGym.Client.Http;

namespace DemoAgent
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var client = CreateClient();

            var environmentName = "CartPole-v0";
            var environmentId = await client.CreateEnvironment(environmentName);

            Console.WriteLine($"Created environment '{environmentName}' with id: {environmentId}");

            var actionSpace = await client.GetActionSpaceInfo(environmentId);

            Console.WriteLine("Action space:");
            Console.WriteLine(actionSpace);

            var observationSpace = await client.GetObservationSpaceInfo(environmentId);

            Console.WriteLine("Observation space:");
            Console.WriteLine(observationSpace);

            // todo: monitor (see example python agent)

//            var episode_count = 1;
//            var max_steps = 1;
//            var reward = 0;
//
//            for (int i = 0; i < episode_count; i++)
//            {
//                var observation = await client.ResetEnvironment(environmentId);

//                for (int j = 0; j < max_steps; j++)
//                {
//                    var action = client.SampleActionSpace(environmentId);
//                    // todo: fix render
//                    // ob, reward, done, _
//                    var stepResult = client.Step(environmentId, action, render: false);
//
//                    if (stepResult.Done) break;
//                }
//            }
        }

        private static IAiGymClient CreateClient()
        {
            return new HttpAiGymClient("http://127.0.0.1:5000");
        }
    }
}
