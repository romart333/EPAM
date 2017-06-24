// В кругу стоят N человек, пронумерованных от 1 до N. При ведении счета по кругу вычёркивается каждый второй человек, пока не останется один
namespace Task01
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Console.WriteLine("Введите количество людей: ");
            int countPeople = ReadInt();
            List<int> people = new List<int>(countPeople);
            for (int i = 1; i < countPeople + 1; i++)
            {
                people.Add(i);
            }

            int j = 1;
            while (people.Count > 1)
            {
                Console.WriteLine("Вычеркиваем №{0}", people[j]);
                people.RemoveAt(j);
                Console.WriteLine("Оставшиеся люди:");
                foreach (int item in people)
                {
                    Console.Write($"{item} ");
                }
                
                Console.WriteLine();
                j = (j + 1) % people.Count;
            }

            Console.WriteLine("Остался человек №{0}", people[0]);

            Console.ReadLine();
        }

        private static int ReadInt()
        {
            int result;
            for (;;)
            {
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    return result;
                }

                Console.WriteLine("Неверны ввод. Попробуйте еще раз.");
                continue;
            }
        }
    }
}
