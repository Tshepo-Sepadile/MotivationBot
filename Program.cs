using System;
using System.Threading.Tasks;

namespace MotivationBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilities.MessageLog("Application Starting...");
            Twitter twitter = new Twitter();
            Task.WaitAny(twitter.PostTweet());
            Utilities.MessageLog("Application Exiting...");
            Environment.Exit(0);
        }
    }
}
