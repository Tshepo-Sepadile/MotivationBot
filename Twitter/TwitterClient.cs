﻿using RestSharp;
using System.Threading.Tasks;

namespace MotivationBot.Twitter
{
    public class TwitterClient(RestClient client) : ITwitterClient
    {
        private readonly RestClient _client = client;

        public async Task PostAsync(string url, string text)
        {
            var request = new RestRequest(url, Method.Post).AddJsonBody(new { text });
            var response = await _client.PostAsync(request);
            if (!response.IsSuccessful)
                Utilities.MessageLog(response.Content);
        }
    }
}
