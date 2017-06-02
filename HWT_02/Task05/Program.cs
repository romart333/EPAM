// Напишите программу, которая выводит на экран сумму всех чисел меньше 1000, кратных 3, или 5.
namespace Task05
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            int multipleA = 3, multipleB = 5, number = 1000, sum = 0;
            for (int i = 1; i < number; i++)
            {
                if (i % multipleA == 0 || i % multipleB == 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine($"Сумма всех чисел меньше 1000, кратных 3, или 5 = {sum}");

            Console.ReadKey();
        }
    }
}