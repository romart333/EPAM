// Написать программу, которая запрашивает с клавиатуры число N и выводит на экран следующее «изображение», состоящее из N треугольников
namespace Task04
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

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
            char sw = ' ', star = '*';

            for (int i = 0; i < count; i++)
            {
                Console.Write(sw);
            }

            Console.WriteLine(star);

            for (int l = 1; l <= count; l++)
            {
                for (int i = 1; i <= l + 1; i++)
                {
                    for (int j = 0; j < count - i + 1; j++)
                    {
                        Console.Write(sw);
                    }

                    for (int k = 0; k < ((i - 1) * 2) + 1; k++)
                    {
                        Console.Write(star);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
