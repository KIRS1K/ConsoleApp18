using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;



namespace ConsoleApp18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "C:\\Users\\ilyak\\OneDrive\\Рабочий стол\\1.txt";
            StreamReader sr = new StreamReader(file);
            string beta = sr.ReadToEnd();
            var noPunctuationText = new string(beta.Where(c => !char.IsPunctuation(c)).ToArray());

            // Разбиваем текст на слова и приводим к нижнему регистру
            var words = noPunctuationText.ToLower().Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // Подсчитываем частоту слов
            var wordCounts = words.GroupBy(word => word)
                                  .Select(group => new { Word = group.Key, Count = group.Count() })
                                  .OrderByDescending(x => x.Count)
                                  .Take(10);

            // Выводим 10 наиболее частых слов
            foreach (var word in wordCounts)
            {
                Console.WriteLine($"{word.Word}: {word.Count}");
            }
        }
    }
}
