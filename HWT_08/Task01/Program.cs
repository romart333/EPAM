namespace Task01
{
    using System;
    using System.Text;

    public class Program
    {
        public delegate void Comparing(ref string first, ref string second);

        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Console.WriteLine("Введите слова через пробел для составления массива строк");
            string input = Console.ReadLine();
            string[] strings = input.Split(' ');
            Comparing del = new Comparing(Compare);

            Sort(strings, del);
            foreach (string word in strings)
            {
                Console.Write(word + " ");
            }

            Console.ReadLine();
        }
            
        public static void Sort(string[] strings, Comparing del)
        {
            if (strings == null || del == null)
            {
                return;
            }

            for (int i = 0; i < strings.Length - 1; i++)
            {
                for (int j = i + 1; j < strings.Length; j++)
                {
                    Compare(ref strings[i], ref strings[j]);
                }
            }
        }

        public static void Compare(ref string first, ref string second)
        {
            if (first.Length == second.Length)
            {
                if (string.Compare(first, second) < 0)
                {
                    Swap(ref first, ref second);
                }
            }

            if (first.Length < second.Length)
            {
                Swap(ref first, ref second);
            }
        }

        public static void Swap(ref string first, ref string second)
        {
            string buf = first;
            first = second;
            second = buf;
        }
    }
}
