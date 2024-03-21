using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MotivationBot
{
    public static class Utilities
    {
        public static void MessageLog(string message)
        {
            string directoryPath = @$"{AppDomain.CurrentDomain.BaseDirectory}\Files\{DateTime.Now.Year}\{DateTime.Now:MMMM}";
               
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            string filePath = Path.Combine(directoryPath, $"Log_{ DateTime.Now:dd-MM-yyyy}.txt");
            Console.WriteLine(filePath);
            using StreamWriter sw = new(filePath, true);
            sw.WriteLine($"{DateTime.Now}: {message}");
            sw.Flush();
        }

        public static string ExceptionMessage(Exception ex)
        {
            return $"Oops! Something went wrong...\n\nError: {ex.Message}\n\nInnerException: {ex.InnerException}\n\nStackTrace: {ex.StackTrace}";
        }

        public static string BuildString(char symbol, List<string> items)
        {
            return string.Join(symbol, items);
        }
    }
}
