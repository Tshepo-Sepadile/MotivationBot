﻿using System;
using RestSharp;
using System.Threading.Tasks;

namespace MotivationBot.v2.Twitter
{
    public class TwitterClient : ITwitterClient
    {
        private readonly RestRequest _request;
        private readonly RestClient _client;

        public TwitterClient(RestClient client, RestRequest request)
        {
            _client = client;
            _request = request;
        }

        public async Task PostAsync(string url, string text)
        {
            try
            {
                _request.AddUrlSegment("url", url);
                _request.Method = Method.Post;
                _request.AddJsonBody(new { text });
                var response = await _client.PostAsync(_request);
                Utilities.MessageLog(response.Content);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
