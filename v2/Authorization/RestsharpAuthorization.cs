using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotivationBot.v2.Authorization
{
    public class RestsharpAuthorization : IRestsharpAuthorization
    {
        private readonly RestClientOptions _options;
        public RestsharpAuthorization(RestClientOptions options)
        {
            _options = options;
            Client = new RestClient(_options);
            Request = new RestRequest();
        }

        public RestClient Client { get; set; }

        public RestRequest Request { get; set; }
    }
}
