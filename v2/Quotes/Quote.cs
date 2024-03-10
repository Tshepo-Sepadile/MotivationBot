using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MotivationBot.v2.Quotes
{
    public class Quote
    {
        public string Author { get; set; }
        public string Text { get; set; }
        public override string ToString() =>
            $"\"{Text}\" - {Author}";
    }
}
