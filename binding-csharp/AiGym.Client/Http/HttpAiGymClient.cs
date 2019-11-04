using System.Threading.Tasks;
using AiGym.Client.Http.Messages;

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
            var response = await _client.PostAsync<CreateEnvironmentResponse>($"{_baseUrl}/v1/envs", new { env_id = environmentName });
            return response.instance_id;
        }
    }
}
