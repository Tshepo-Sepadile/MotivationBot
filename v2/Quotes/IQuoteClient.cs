using System.Threading.Tasks;

namespace MotivationBot.v2.Quotes
{
    public interface IQuoteClient
    {
        Task<string> GetQuotesAsync();
    }
}
