using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AiGym.Client.Http
{
    internal class JsonHttpClient
    {
        private readonly HttpClient _httpClient;

        public JsonHttpClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<TResponse> PostAsync<TResponse>(string uri)
        {
            var response = await _httpClient.PostAsync(uri, null);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseContent);
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

        public async Task<TResponse> GetAsync<TResponse>(string uri)
        {
            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseContent);
        }
    }
}