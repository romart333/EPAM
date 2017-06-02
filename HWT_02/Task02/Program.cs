// Написать программу, которая запрашивает с клавиатуры число N и выводит на экран следующее «изображение», состоящее из N строк:
namespace Task02
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

            ShowPyramid(count);
            Console.ReadKey();
        }

        private static void ShowPyramid(int count)
        {
            char a = '*';
            for (int i = 1; i <= count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(a);
                }

                Console.WriteLine();
            }
        }
    }
}
