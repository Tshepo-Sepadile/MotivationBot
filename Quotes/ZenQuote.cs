using System.Text.Json.Serialization;

namespace MotivationBot.Quotes
{
    public class ZenQuote
    {
        [JsonPropertyName("a")]
        public string Author { get; set; }

        [JsonPropertyName("q")]
        public string Text { get; set; }

        public override string ToString() =>
            $"\"{Text}\" - {Author}";
    }
}
