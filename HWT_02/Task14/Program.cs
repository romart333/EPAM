// Определить сумму элементов массива, стоящих на чётных позициях.
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
            int count1 = 5, count2 = 4, seed = 15, sumEven = 0;

            int[,] array = new int[count1, count2];
            Random rand = new Random(seed);

            Console.WriteLine("Исходный массив: ");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                        array[i, j] = rand.Next(seed);
                        Console.Write($"{array[i, j]} ");
                }

                Console.WriteLine();
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                { 
                        if ((i + j) % 2 == 0)
                        {
                            sumEven += array[i, j];
                        }
                }
            }

            Console.WriteLine($"Сумма элементов на четных позициях = {sumEven}");

            Console.ReadKey();
        }
    }
}
