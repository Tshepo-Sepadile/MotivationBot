using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotivationBot.v2.Authorization
{
    public interface IRestsharpAuthorization
    {
        RestClient Client { get; set; }
        RestRequest Request { get; set; }
    }
}
