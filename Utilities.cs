using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MotivationBot
{
    public static class Utilities
    {
        private static readonly string _logFolder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build()["LogFolder"];
        public static void MessageLog(string message)
        {
            DateTime currentDate = DateTime.Now;
            string directoryPath = @$"{_logFolder}\{currentDate.Year}\{currentDate:MMMM}";
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            string filePath = Path.Combine(directoryPath, $"Log_{currentDate:dd-MM-yyyy}.txt");
            Console.WriteLine(filePath);
            using StreamWriter sw = new(filePath, true);
            sw.WriteLine($"{currentDate}: {message}");
            sw.Flush();
        }

        public static string ExceptionMessage(Exception ex)
        {
            return $"Oops! Something went wrong...\n\nError: {ex.Message}\n\nInnerException: {ex.InnerException}\n\nStackTrace: {ex.StackTrace}";
        }

        public static string BuildString(char symbol, IEnumerable<string> items)
        {
            return string.Join(symbol, items);
        }
    }
}
