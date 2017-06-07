// Проведите сравнительный анализ скорости работы классов String и StringBuilder для операции сложения строк.
namespace Task11
{
    using System;
    using System.Diagnostics;
    using System.Text;
 
    public class Program
    {
        public static void Main(string[] args)//todo pn копипаст кода вижу, исследовательской работы - нет
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            string str = "";
            StringBuilder sb = new StringBuilder();
            Stopwatch sw = new Stopwatch();
            int n = 100;
            sw.Start();
            for (int i = 0; i < n; i++)
            {
                str += "*";
            }

            sw.Stop();

            Console.WriteLine("Время, затраченное на преобразование string в секундах={0}", sw.Elapsed);

            sw.Start();
            for (int i = 0; i < n; i++)
            {
                sb.Append("*");
            }

            sw.Stop();
            Console.WriteLine("Время, затраченное на преобразование stringBuilder в секундах={0}", sw.Elapsed);

            Console.ReadKey();
        }  
    }
}
