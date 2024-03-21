using System.Threading.Tasks;

namespace MotivationBot.Twitter
{
    public interface ITwitterClient
    {
        Task PostAsync(string url, string text);
    }
}
