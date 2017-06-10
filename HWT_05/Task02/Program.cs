// Написать класс, описывающий треугольник со сторонами a, b, c, и позволяющий осуществить расчёт его площади и периметра. 
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

            char choose;
            string inputError = "Неверный ввод";
            Triangle triangle = new Triangle();
            triangle.A = InputDouble("Введите сторону a", inputError);
            triangle.B = InputDouble("Введите сторону b", inputError);
            triangle.C = InputDouble("Введите сторону c", inputError);

            for (;;)
            {
                Console.WriteLine("Введите для получения информации о треугольнике:");
                Console.WriteLine("1 - Сторона a\n2 - Сторона b\n3 - Сторона c\n4 - Площадь\n5 - Периметр\n0 - Выход");
                choose = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (choose)
                {
                    case '1':
                        {
                            Console.WriteLine($"Сторона a = {triangle.A}");
                            break;
                        }

                    case '2':
                        {
                            Console.WriteLine($"Сторона b =  {triangle.B}");
                            break;
                        }

                    case '3':
                        {
                            Console.WriteLine($"Сторона c = {triangle.C}");
                            break;
                        }

                    case '4':
                        {
                            Console.WriteLine($"Площадь треугольника = {triangle.Area}");
                            break;
                        }

                    case '5':
                        {
                            Console.WriteLine($"Периметр треугольника = {triangle.Perimeter}");
                            break;
                        }

                    case '0':
                        {
                            return;
                        }

                    default:
                        {
                            Console.WriteLine(inputError);
                            break;
                        }
                }
            }
        }

        public static double InputDouble(string message, string errMessage)
        {
            string str = string.Empty;
            double value;

            for (;;)
            {
                Console.WriteLine(message);
                str = Console.ReadLine();
                if (!double.TryParse(str, out value))
                {
                    Console.WriteLine(errMessage);
                    continue;
                }

                return value;
            }
        }
    }
}
