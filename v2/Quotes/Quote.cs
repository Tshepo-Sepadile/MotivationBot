using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MotivationBot.v2.Quotes
{
    public class Quote
    {
        public string Author { get; set; }
        public string Text { get; set; }

        //public Quote(string author, string text)
        //{
        //    if (string.IsNullOrEmpty(author))
        //        throw new ArgumentNullException(nameof(author));
        //    if (string.IsNullOrEmpty(text))
        //        throw new ArgumentNullException(nameof(text));
        //    Author = author;
        //    Text = text;
        //}

        public override string ToString() =>
            $"\"{Text}\" - {Author}";
    }
}
