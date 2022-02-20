using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;

namespace MotivationBot
{
    public class Twitter
    {
        private readonly string _apiKey = ConfigurationManager.AppSettings["TwitterApiKey"];
        private readonly string _apiKeySecret = ConfigurationManager.AppSettings["TwitterApiKeySecret"];
        private readonly string _accessToken = ConfigurationManager.AppSettings["TwitterAccessToken"];
        private readonly string _accessTokenSecret = ConfigurationManager.AppSettings["TwitterAccessTokenSecret"];

        public async Task PostTweet()
        {
            Utilities.MessageLog("Posting tweet...");

            try
            {
                Quote quote = new Quote();
                string message = quote.GetQuote();

                TwitterClient _client = new TwitterClient(_apiKey, _apiKeySecret, _accessToken, _accessTokenSecret);

                if (!string.IsNullOrEmpty(message))
                {
                    ITweet tweet = await _client.Tweets.PublishTweetAsync(message);
                    Utilities.MessageLog("Tweet posted successfully!");
                    Utilities.MessageLog($"Quote: {message}\nTweet ID: {tweet.Id}\nTweet URL: {tweet.Url}");
                }
                else
                    Utilities.MessageLog("Tweet not posted. Message is null or empty.");

            }
            catch(Exception ex)
            {
                Utilities.MessageLog(Utilities.ExceptionMessage(ex));
            }
        }
    }
}
