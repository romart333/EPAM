using System.Text;

namespace Task02
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
	        Console.InputEncoding = Encoding.Unicode;
	        Console.OutputEncoding = Encoding.Unicode;

			double a = 0, b = 0, c = 0, h = 0, discr = 0, x1 = 0, x2 = 0;
            while (true)
            {
                Console.WriteLine("Введите h: ");
                try
                {
                    h = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                break;
            }

            a = (Math.Sqrt(Math.Abs(Math.Sin(8 * h))) + 17) / (1 - Math.Sin(4 * h)) * Math.Cos(Math.Pow(Math.Pow(h, 2) + 18, 2));
            Console.WriteLine($"Коэффициент а = {a}");

            b = 1 - Math.Sqrt(3 / (3 + Math.Abs(Math.Tan(a * Math.Pow(h, 2)) - Math.Sin(a * h))));
            Console.WriteLine($"Коэффициент b = {b}");

            c = (a * Math.Pow(h, 2) * Math.Sin(b * h)) + (b * Math.Pow(h, 3) * Math.Cos(a * h));
            Console.WriteLine($"Коэффициент c = {c}");

            discr = Math.Pow(b, 2) - (4 * a * c);
            Console.WriteLine($"D = {discr}");
            if (discr < 0)
            {
                Console.WriteLine("Действительных корней нет.");
            }
            else
            {
                x1 = (-b + Math.Sqrt(discr)) / (2 * a);
                x2 = (-b - Math.Sqrt(discr)) / (2 * a);
                Console.WriteLine($"Корни уравнения: x1 = {x1}, x2 = {x2}");
            }

            Console.ReadKey();
        }
    }
}
