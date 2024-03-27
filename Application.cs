using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using MotivationBot.Quotes;
using MotivationBot.Twitter;

namespace MotivationBot
{
    public class Application(IQuoteClient quoteRequest, ITwitterClient twitterClient,
        string twitterUrl, IEnumerable<string> hashTags)
    {
        private readonly IQuoteClient _quoteRequest = quoteRequest;
        private readonly ITwitterClient _twitterClient = twitterClient;
        private readonly string _twitterUrl = twitterUrl;
        private readonly IEnumerable<string> _hashTags = hashTags;

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
