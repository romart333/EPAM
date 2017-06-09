// Написать программу, которая определяет сумму неотрицательных элементов в одномерном массиве.
namespace Task03
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            int count = 10, seed = 15, sum = 0;

            int[] array = new int[count];
            Random rand = new Random(seed);

            Console.WriteLine("Исходный массив: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i] = rand.Next(-seed, seed)} ");
                if (array[i] >= 0)
                {
                    sum += array[i];
                }
            }

            Console.WriteLine();
            Console.WriteLine("Сумма неотрицательных элементов = {0}", sum);

            Console.ReadKey();
        }
    }
}