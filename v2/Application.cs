﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using MotivationBot.v2.Quotes;
using MotivationBot.v2.Twitter;

namespace MotivationBot.v2
{
    public class Application
    {
        private readonly IQuoteClient _quoteRequest;
        private readonly ITwitterClient _twitterClient;
        private readonly string _twitterUrl;
        private readonly List<string> _hashTags;

        public Application(IQuoteClient quoteRequest, ITwitterClient twitterClient,
            string twitterUrl, List<string> hashTags) 
        {
            _quoteRequest = quoteRequest;
            _twitterClient = twitterClient;
            _twitterUrl = twitterUrl;
            _hashTags = hashTags;
        }

        public async Task Run()
        {
            try
            {
                Utilities.MessageLog("Getting quote...");
                string quotesAsString = await _quoteRequest.GetQuotesAsync();
                Utilities.MessageLog(quotesAsString);
                List<ZenQuote> quotes = JsonSerializer.Deserialize<List<ZenQuote>>(quotesAsString);
                Utilities.MessageLog("Posting tweet...");
                await _twitterClient.PostAsync(_twitterUrl, $"{quotes[0]} {Utilities.BuildString(' ', _hashTags)}");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
