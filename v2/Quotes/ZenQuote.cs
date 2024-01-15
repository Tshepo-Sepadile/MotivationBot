using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MotivationBot.v2.Quotes
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
