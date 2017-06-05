// Написать программу, которая определяет среднюю длину слова во введенной текстовой строке.
namespace Task11
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            string inputString;
            int countWords = 0, i = 0, countLetters = 0;
            double averageLength = 0;

            Console.WriteLine("Введите строку, для подсчета средней длины слова: ");
            inputString = Console.ReadLine();

            FindPosLetter(inputString, ref i);
            while (i < inputString.Length)
            { 
                if (char.IsPunctuation(inputString[i]) || char.IsSeparator(inputString[i]))
                {
                    countWords++;
                    if (!FindPosLetter(inputString, ref i))
                    {
                        break;
                    }
                }

                countLetters++;
                if (i == inputString.Length - 1)
                {
                    countWords++;
                    break;
                }

                i++;
            }

            averageLength = (double)countLetters / countWords;

            Console.WriteLine("Средняя длина слова = {0}", countWords > 0 ? averageLength : 0);
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
    }
}
