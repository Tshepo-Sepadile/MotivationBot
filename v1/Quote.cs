using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;

namespace MotivationBot.v1
{
    public class Quote
    {
        private readonly string quotesApiUrl = ConfigurationManager.AppSettings["QuotesApiUrl"];
        private static HttpClient _client = new HttpClient();

        public string Author { get; set; }
        public string Text { get; set; }

        public string GetQuote()
        {
            HttpResponseMessage response = _client.GetAsync(quotesApiUrl).Result;

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                var quotes = JsonConvert.DeserializeObject<List<Quote>>(json);
                var quote = quotes[RandomNumber(quotes.Count - 1)]; //The API returns a list of quotes, therefore we use a random number to get a random quote from the list.
                string message = @$"""{quote.Text}"" - {(string.IsNullOrEmpty(quote.Author) ? "Anon" : quote.Author)} {Hashtags()}";
                return message;
            }
            else
                return "";

        }

        private int RandomNumber(int maxValue)
        {
            Random random = new Random();
            return random.Next(0, maxValue);
        }

        private string Hashtags()
        {
            return string.IsNullOrEmpty(ConfigurationManager.AppSettings["Hashtags"]) ? "" : string.Join(" ", ConfigurationManager.AppSettings["Hashtags"].Split('@'));
        }
    }
}
