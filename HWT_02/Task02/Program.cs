// Написать программу, которая запрашивает с клавиатуры число N и выводит на экран следующее «изображение», состоящее из N строк:
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
