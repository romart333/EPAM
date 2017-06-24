// Задан английский текст.Выделить отдельные слова и для каждого посчитать частоту встречаемости.Слова, отличающиеся регистром, считать одинаковыми.
namespace Task02
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            string inputString;
            int i = 0;
            List<Words> words = new List<Words>();

            Console.WriteLine("Введите строку, для подсчета средней длины слова:");
            inputString = Console.ReadLine();

            FindPosLetter(inputString, ref i);
            int begin = i;
            while (i < inputString.Length)
            {
                if (char.IsPunctuation(inputString[i]) || char.IsSeparator(inputString[i]))
                {
                    CountWords(words, inputString, begin, i);
                    if (!FindPosLetter(inputString, ref i))
                    {
                        break;
                    }

                    begin = i;
                }

                if (i == inputString.Length - 1)
                {
                    CountWords(words, inputString, begin, i + 1);
                    break;
                }

                i++;
            }

            foreach (var word in words)
            {
                Console.WriteLine("Слово: \"{0}\", частота = {1}", word.Str, word.Сount);
            }

            Console.ReadKey();
        }

         public static bool FindPosLetter(string str, ref int i)
        {
            while (i < str.Length)
            {
                if (!char.IsPunctuation(str[i]) && !char.IsSeparator(str[i]))
                {
                    return true;
                }

                i++;
            }

            return false;
        }

        public static void CountWords(List<Words> words, string source, int begin, int current)
        {
            int length = current - begin;
            bool concidence = false;
            string word = source.Substring(begin, length);

            for (int j = 0; j < words.Count; j++)
            {
                if (string.Compare(word, words[j].Str, true) == 0)
                {
                    words[j].Сount++;
                    return;
                }
            }

            if (!concidence)
            {
                words.Add(new Words(word));
            }
        }
    }
}
