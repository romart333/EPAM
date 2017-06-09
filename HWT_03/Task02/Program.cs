// Написать программу, которая заменяет все положительные элементы в трёхмерном массиве на нули.
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
            int count1 = 2, count2 = 3, count3 = 4, seed = 15;

            int[,,] array = new int[count1, count2, count3];
            Random rand = new Random(seed);

            Console.WriteLine("Исходный массив: ");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        array[i, j, k] = rand.Next(-seed, seed);
                        Console.Write($"{array[i, j, k]} ");
                    }
                }

                Console.WriteLine(" ");
            }

            Console.WriteLine("Обработанный массив: ");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        if (array[i, j, k] > 0)
                        {
                            array[i, j, k] = 0;
                        }

                        Console.Write($"{array[i, j, k]} ");
                    }
                }

                Console.WriteLine(" ");
            }

            Console.ReadKey();
        }
    }
}
