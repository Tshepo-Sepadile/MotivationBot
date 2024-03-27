using System;
using System.Threading.Tasks;
using RestSharp.Authenticators;
using RestSharp;
using System.Net.Http;
using MotivationBot.Quotes;
using MotivationBot.Twitter;
using Microsoft.Extensions.Configuration;

namespace MotivationBot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Utilities.MessageLog("Application starting...");
            try
            {
                IConfigurationRoot configurationRoot = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                string oauthConsumerKey = configurationRoot["TwitterApiKey"];
                string consumerSecret = configurationRoot["TwitterApiKeySecret"];
                string oauthToken = configurationRoot["TwitterAccessToken"];
                string tokenSecret = configurationRoot["TwitterAccessTokenSecret"];
                string twitterUrl = configurationRoot["TwitterUrl"];
                var hashTags = configurationRoot["Hashtags"].Split('@');
                string quotesUrl = configurationRoot["QuotesApiUrl"];

                RestClient restClient = new (new RestClientOptions(new Uri(twitterUrl))
                {
                    Authenticator = OAuth1Authenticator
                    .ForAccessToken(oauthConsumerKey, consumerSecret, oauthToken, tokenSecret)
                });
                Application application = new(new QuoteClient(new HttpClient(), quotesUrl),
                new TwitterClient(restClient), twitterUrl, hashTags);
                await application.Run();
            }
            catch (Exception ex)
            {
                Utilities.MessageLog(Utilities.ExceptionMessage(ex));
            }
            Utilities.MessageLog("Application Exiting...");
            Environment.Exit(0);
        }
    }
}
