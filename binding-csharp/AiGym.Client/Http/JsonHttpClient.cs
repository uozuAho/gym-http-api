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
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            var response = await ExecuteRequest(request);
            return await DeserializeResponseContent<TResponse>(response);
        }

        public async Task<TResponse> PostAsync<TResponse>(string uri, object body)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = CreateRequestContent(body)
            };

            var response = await ExecuteRequest(request);

            return await DeserializeResponseContent<TResponse>(response);
        }

        public async Task<TResponse> GetAsync<TResponse>(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await ExecuteRequest(request);
            return await DeserializeResponseContent<TResponse>(response);
        }

        private async Task<HttpResponseMessage> ExecuteRequest(HttpRequestMessage request)
        {
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return response;
        }

        private static StringContent CreateRequestContent(object body)
        {
            var bodyJson = JsonConvert.SerializeObject(body);
            return new StringContent(bodyJson, Encoding.UTF8, "application/json");
        }

        private static async Task<TResponse> DeserializeResponseContent<TResponse>(HttpResponseMessage response)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseContent);
        }
    }
}