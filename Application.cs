using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using MotivationBot.Quotes;
using MotivationBot.Twitter;

namespace MotivationBot
{
    public class Application
    {
        private readonly IQuoteClient _quoteRequest;
        private readonly ITwitterClient _twitterClient;
        private readonly string _twitterUrl;
        private readonly IEnumerable<string> _hashTags;

        public Application(IQuoteClient quoteRequest, ITwitterClient twitterClient,
            string twitterUrl, IEnumerable<string> hashTags)
        {
            _quoteRequest = quoteRequest;
            _twitterClient = twitterClient;
            _twitterUrl = twitterUrl;
            _hashTags = hashTags;
        }

        public async Task Run()
        {
            Utilities.MessageLog("Getting quote...");
            string quotesAsString = await _quoteRequest.GetQuotesAsync();
            List<ZenQuote> quotes = JsonSerializer.Deserialize<List<ZenQuote>>(quotesAsString);
            Utilities.MessageLog("Posting tweet...");
            await _twitterClient.PostAsync(_twitterUrl, $"{quotes[0]} {Utilities.BuildString(' ', _hashTags)}");
        }
    }
}
