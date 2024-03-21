using System.Threading.Tasks;

namespace MotivationBot.Quotes
{
    public interface IQuoteClient
    {
        Task<string> GetQuotesAsync();
    }
}
