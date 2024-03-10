#define VERSION_2

using MotivationBot.v2.Authorization;
using System;
using System.Configuration;
using System.Threading.Tasks;
using RestSharp.Authenticators;
using RestSharp;
using MotivationBot.v2;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using MotivationBot.v2.Twitter;
using MotivationBot.v2.Quotes;

namespace MotivationBot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                string oauthConsumerKey = ConfigurationManager.AppSettings["TwitterApiKey"];
                string consumerSecret = ConfigurationManager.AppSettings["TwitterApiKeySecret"];
                string oauthToken = ConfigurationManager.AppSettings["TwitterAccessToken"];
                string tokenSecret = ConfigurationManager.AppSettings["TwitterAccessTokenSecret"];
                string twitterUrl = ConfigurationManager.AppSettings["TwitterUrl"];
                List<string> hashTags = ConfigurationManager.AppSettings["Hashtags"].Split('@').ToList();
                string quotesUrl = ConfigurationManager.AppSettings["QuotesApiUrl"];

#if VERSION_1
            //Utilities.MessageLog("Running version 1...");
            Twitter twitter = new Twitter();
            await twitter.PostTweet();
#elif VERSION_2
                Utilities.MessageLog("Running version 2...");
                RestsharpAuthorization authorization = new(new RestClientOptions(new Uri(twitterUrl))
                {
                    Authenticator = OAuth1Authenticator.ForAccessToken(oauthConsumerKey,
                                consumerSecret, oauthToken, tokenSecret)
                });

                Application application = new(new QuoteClient(new HttpClient(), quotesUrl),
                new TwitterClient(authorization.Client, authorization.Request), twitterUrl, hashTags);
                await application.Run();
#endif
                Utilities.MessageLog("Application Exiting...");
            }
            catch (Exception ex)
            {
                Utilities.MessageLog(Utilities.ExceptionMessage(ex));
            }
            Environment.Exit(0);

        }
    }
}
