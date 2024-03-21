using System.Net.Http;
using System.Threading.Tasks;

namespace MotivationBot.Quotes
{
    public class QuoteClient : IQuoteClient
    {
        private readonly string _url;
        private readonly HttpClient _httpClient;

        public QuoteClient(HttpClient httpClient, string url)
        {
            _httpClient = httpClient;
            _url = url;
        }
        public async Task<string> GetQuotesAsync()
        {
            var response = await _httpClient.GetAsync(_url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
