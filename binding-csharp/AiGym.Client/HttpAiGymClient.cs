using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AiGym.Client
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
            var response = await _client.PostAsync<EnvCreateResponse>($"{_baseUrl}/v1/envs", new { env_id = environmentName });
            return response.instance_id;
        }
    }

    internal class EnvCreateResponse
    {
        public string instance_id { get; set; }
    }

    internal class JsonHttpClient
    {
        private readonly HttpClient _httpClient;

        public JsonHttpClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<TResponse> PostAsync<TResponse>(string uri, object body)
        {
            var bodyJson = JsonConvert.SerializeObject(body);
            var requestContent = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, requestContent);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseContent);
        }
    }
}
