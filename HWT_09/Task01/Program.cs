namespace Task01
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            const int Length = 10;
            const int SeedRandom = 100;
            int[] array = new int[Length];
            Random rand = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(SeedRandom);
            }

            int sum = array.Summa();
            Console.WriteLine("Сумма массива элементов массива = {0}", array.Summa());

            Console.ReadLine();
        }
    }
}
