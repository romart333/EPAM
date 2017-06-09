// Написать программу, которая удваивает в первой введенной строки все символы, принадлежащие второй введенной строке. 
namespace Task02
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            string string1, string2;
            StringBuilder resultSB = new StringBuilder();

            Console.WriteLine("Введите первую строку: ");
            string1 = Console.ReadLine();

            Console.WriteLine("Введите вторую строку: ");
            string2 = Console.ReadLine();

            for (int i = 0; i < string1.Length; i++)
            {
                if (string2.IndexOf(string1[i]) >= 0)
                {
                    resultSB.Append(string1[i]);
                }

                resultSB.Append(string1[i]);
            }

            Console.WriteLine($"Результирующая строка: {resultSB}");
            Console.ReadKey();
        }
    }
}
