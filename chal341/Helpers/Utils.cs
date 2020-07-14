using System.Net.Http;
using System.Threading.Tasks;

namespace chal341.Helpers
{
    public class Utils : IUtils
    {
        private readonly IHttpClientFactory _clientFactory;

        public Utils(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> ExecuteHttpRequestAsync(HttpMethod httpVerb, string requestUri, HttpContent requestObj = null)
        {
            var httpRequest = new HttpRequestMessage(httpVerb, requestUri)
            {
                Content = requestObj
            };

            var httpClient = _clientFactory.CreateClient();
            var httpResponse = await httpClient.SendAsync(httpRequest);

            string responseAsString = await httpResponse.Content.ReadAsStringAsync();

            return responseAsString;
        }
    }
}
