using System.Threading.Tasks;

namespace MotivationBot.v2.Twitter
{
    public interface ITwitterClient
    {
        Task PostAsync(string url, string text);
    }
}
