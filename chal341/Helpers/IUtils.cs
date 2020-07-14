using System.Net.Http;
using System.Threading.Tasks;

namespace chal341.Helpers
{
    public interface IUtils
    {
        Task<string> ExecuteHttpRequestAsync(HttpMethod httpVerb, string requestUri, HttpContent requestObj = null);
    }
}
