// Напишите программу, которая выводит на экран сумму всех чисел меньше 1000, кратных 3, или 5.
namespace Task05
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int count = 0;
            bool result = false;
            while (true)
            {
                Console.WriteLine("Введите число N: ");
                result = int.TryParse(Console.ReadLine(), out count);
                if (!result || count <= 0)
                {
                    Console.WriteLine("Неверный ввод.");
                    continue;
                }

                break;
            }

            int multipleA = 3, multipleB = 5, number = 1000, sum = 0;
            for (int i = 1; i < number; i++)
            {
                if (i % multipleA == 0 || i % multipleB == 0)
                {
                    sum += i;
                }
            }

            Console.ReadKey();
        }
    }
}