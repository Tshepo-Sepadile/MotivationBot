using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MotivationBot.v2.Quotes
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
            try
            {
                var response = await _httpClient.GetAsync(_url);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Utilities.MessageLog(Utilities.ExceptionMessage(ex));
                return string.Empty;
            }
        }
    }
}
