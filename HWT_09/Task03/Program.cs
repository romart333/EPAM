namespace Task03
{
    using System;
    using System.Linq;
    using System.Diagnostics;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            const int Length = 500;
            const int MaxRandom = 100;
            const int Measurings = 30;

            long[] arrayTime = new long[Measurings];
            int[] array = new int[Length];

            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(MaxRandom);
            }

            Stopwatch stopWatch = new Stopwatch();

            
            for (int i = 0; i < Measurings; i++)
            {
                stopWatch.Start();
                int[] positiveNumbers = SumMax(array);//1
                stopWatch.Stop();
                arrayTime[i] = stopWatch.ElapsedTicks;
                stopWatch.Reset();
            }

            Array.Sort<long>(arrayTime);
            Console.WriteLine("Условие напрямую в функции, время: {0}", arrayTime[Measurings / 2]);

            for (int i = 0; i < Measurings; i++)
            {
                stopWatch.Start();
                int[] positiveNumbers = SumMax(array, IsPositive);//2
                stopWatch.Stop();
                arrayTime[i] = stopWatch.ElapsedTicks;
                stopWatch.Reset();
            }

            Array.Sort<long>(arrayTime);
            Console.WriteLine("Условие через делегат, время: {0}", arrayTime[Measurings / 2]);

            for (int i = 0; i < Measurings; i++)
            {
                stopWatch.Start();
                int[] positiveNumbers = SumMax(array, delegate (int obj)// 3
                {
                    if (obj > 0)
                    {
                        return true;
                    }

                    return false;
                });

                stopWatch.Stop();
                arrayTime[i] = stopWatch.ElapsedTicks;
                stopWatch.Reset();
            }

            Array.Sort<long>(arrayTime);
            Console.WriteLine("Условие через делегат анонимной фукции, время: {0}", arrayTime[Measurings / 2]);

            for (int i = 0; i < Measurings; i++)
            {
                stopWatch.Start();
                int[] positiveNumbers = SumMax(array, x => x > 0);//4 
                stopWatch.Stop();
                arrayTime[i] = stopWatch.ElapsedTicks;
                stopWatch.Reset();
            }

            Array.Sort<long>(arrayTime);
            Console.WriteLine("Условие через делегат лямбда-функции, время: {0}", arrayTime[Measurings / 2]);

            for (int i = 0; i < Measurings; i++)
            {
                stopWatch.Start();//5
                var list = from x in array
                           where x > 0
                           select x;
                list.ToArray();
                stopWatch.Stop();
                arrayTime[i] = stopWatch.ElapsedTicks;
                stopWatch.Reset();
            }

            Array.Sort<long>(arrayTime);
            Console.WriteLine("Поиск через Linq, время: {0}", arrayTime[Measurings / 2]);

            Console.ReadLine();
        }

        public static int[] SumMax(int[] array)
        {
            var list = new List<int>();
           for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    list.Add(array[i]);
                }
            }

            return list.ToArray();
        }

        public static int[] SumMax(int[] array, Predicate<int> condition)
        {
            var list = new List<int>();
            foreach (var item in array)
            {
                if (condition(item))
                {
                    list.Add(item);
                }
            }
            return list.ToArray();
        }

        public static bool IsPositive(int obj)
        {
            if (obj > 0)
            {
                return true;
            }

            return false;
        }
    }
}