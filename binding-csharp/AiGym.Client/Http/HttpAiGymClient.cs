using System.Threading.Tasks;
using AiGym.Client.Http.Messages;
using AiGym.Client.Model;

namespace AiGym.Client.Http
{
    public class HttpAiGymClient : IAiGymClient
    {
        private readonly JsonHttpClient _client;
        private readonly string _baseUrl;

        public HttpAiGymClient(string baseUrl)
        {
            _client = new JsonHttpClient();
            _baseUrl = baseUrl;
        }

        public async Task<string> CreateEnvironment(string environmentName)
        {
            var response = await _client.PostAsync<CreateEnvironmentResponse>(
                $"{_baseUrl}/v1/envs",
                new { env_id = environmentName });

            return response.instance_id;
        }

        public async Task<int> SampleActionSpace(string environmentId)
        {
            var response = await _client.GetAsync<SampleActionSpaceResponse>(
                $"{_baseUrl}/v1/envs/{environmentId}/action_space/sample");

            return response.action;
        }

        public async Task<object> Step(string environmentId, int action, bool render)
        {
            var response = await _client.PostAsync<StepResponse>(
                $"{_baseUrl}/v1/envs/{environmentId}/step",
                new {action, render});

            return response;
        }

        public async Task<object> GetActionSpaceInfo(string environmentId)
        {
            var response = await _client.GetAsync<object>(
                $"{_baseUrl}/v1/envs/{environmentId}/action_space");

            return response;
        }

        public async Task<object> GetObservationSpaceInfo(string environmentId)
        {
            var response = await _client.GetAsync<object>(
                $"{_baseUrl}/v1/envs/{environmentId}/observation_space");

            return response;
        }

        public async Task<ISpace> ResetEnvironment(string environmentId)
        {
            var response = await _client.PostAsync<ResetEnvironmentResponse>(
                $"{_baseUrl}/v1/envs/{environmentId}/reset");

            var observation = new BoxSpace {Values = response.observation};

            return observation;
        }
    }
}
