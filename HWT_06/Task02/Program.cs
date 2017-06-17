// Написать класс ring, задающий круг с указанными координатами центра, радиусом, а также свойствами, позволяющими узнать длину описанной окружности и площадь круга.
// Обеспечить нахождение объекта в заведомо корректном состоянии.Написать программу, демонстрирующую использование данного круга.
namespace Task02
{
    using System;
    using System.Text;
    using Task02;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            char choose;
            Ring ring = new Ring();
            ring.OuterRadius = InputDouble("Введите внешний радиус кольца");
            ring.InnerRadius = InputDouble("Введите внутренний радиус кольца");
            ring.XCenter = InputDouble("Введите координату x для центра кольца");
            ring.YCenter = InputDouble("Введите координату y для центра кольца");

            for (;;)
            {
                Console.WriteLine("Введите для получения информации о кольце:");
                Console.WriteLine("1 - Радиусы\n2 - Координаты центра\n3 - Площадь\n4 - Сумма длин окружностей\n0 - Выход");
                choose = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (choose)
                {
                    case '1':
                        {
                            Console.WriteLine($"Радиус внешнего кольца = {ring.OuterRadius}\nРадиус внутреннего кольца = {ring.InnerRadius}");
                            break;
                        }

                    case '2':
                        {
                            Console.WriteLine($"Координаты кольца: ({ring.XCenter}; {ring.YCenter})");
                            break;
                        }

                    case '3':
                        {
                            Console.WriteLine($"Площадь кольца = {ring.Area}");
                            break;
                        }

                    case '4':
                        {
                            Console.WriteLine($"Сумма длин окружностей = {ring.Length}");
                            break;
                        }

                    case '0':
                        {
                            return;
                        }

                    default:
                        {
                            Console.WriteLine(Recs.errInput);
                            break;
                        }
                }
            }
        }

        public static double InputDouble(string message)
        {
            string str = string.Empty;
            double value;

            for (;;)
            {
                Console.WriteLine(message);
                str = Console.ReadLine();
                if (!double.TryParse(str, out value))
                {
                    Console.WriteLine(Recs.errInput);
                    continue;
                }

                return value;
            }
        }
    }
}
