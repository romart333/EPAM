// Написать класс Round, задающий круг с указанными координатами центра, радиусом, а также свойствами, позволяющими узнать длину описанной окружности и площадь круга.
// Обеспечить нахождение объекта в заведомо корректном состоянии.Написать программу, демонстрирующую использование данного круга.
namespace Task01
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
            Round round = new Round();
            round.Radius = InputDouble("Введите радиус окружности", inputError);
            round.XCenter = InputDouble("Введите координату x для центра окружности", inputError);
            round.YCenter = InputDouble("Введите координату y для центра окружности", inputError);

            for (;;)
            {
                Console.WriteLine("Введите для получения информации об окружности:");
                Console.WriteLine("1 - Радиус\n2 - Координаты центра\n3 - Площадь\n4 - Длина окружности\n0 - Выход");
                choose = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (choose)
                {
                    case '1':
                        {
                            Console.WriteLine($"Радиус окружности = {round.Radius}");
                            break;
                        }

                    case '2':
                        {
                            Console.WriteLine($"Координаты окружности: ({round.XCenter}; {round.YCenter})");
                            break;
                        }

                    case '3':
                        {
                            Console.WriteLine($"Площадь окружности = {round.Area}");
                            break;
                        }

                    case '4':
                        {
                            Console.WriteLine($"Длина окружности = {round.Length}");
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
