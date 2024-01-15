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
            try
            {
                string directoryPath = @$"{AppDomain.CurrentDomain.BaseDirectory}\Files\{DateTime.Now.Year}\{DateTime.Now.ToString("MMMM")}";
               
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                string filePath = Path.Combine(directoryPath, $"Log_{ DateTime.Now.ToString("dd-MM-yyyy")}.txt");
                Console.WriteLine(filePath);
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine($"{DateTime.Now}: {message}");
                    sw.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ExceptionMessage(ex));
            }
        }

        public static string ExceptionMessage(Exception ex)
        {
            return $"Oops! Something went wrong...\n\nError: {ex.Message}\n\nInnerException: {ex.InnerException}\n\nStackTrace: {ex.StackTrace}";
        }

        public static string BuildString(char symbol, List<string> items)
        {
            try
            {
                return string.Join(symbol, items);
            }
            catch (Exception ex)
            {
                MessageLog(ExceptionMessage(ex));
                return string.Empty;
            }
        }
    }
}
