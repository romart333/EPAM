// Вам заказали разработку простого графического редактора, оперирующего векторными примитивами: линиями, прямоугольниками, окружностями
// Опишите модель классов, представляющую изображение в данном редакторе.При этом должны поддерживаться.

namespace Task01
{
    using System;
    using System.Text;

    public class Program
    {
        private static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            string chooseAction = "Выберите действие";
            string errValue = "Значение введено неверно.Введите повторно.";
            char choose;
            bool exit;
            for (;;)
            {
                Console.WriteLine("Выберите фигуру:");
                Console.WriteLine("1.Линия\n2.Квадрат\n3.Прямоугольник\n4.Треугольник\n5.Круг\n0.Выход");
                choose = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (choose)
                {
                    case '1':
                        {
                            Line line = new Line();
                            exit = false;
                            while (!exit)
                            {
                                Console.WriteLine(chooseAction);
                                Console.WriteLine("1.Ввести точки\n2.Вычислить длину\n0.Назад");
                                choose = Console.ReadKey().KeyChar;
                                Console.WriteLine();
                                switch (choose)
                                {
                                    case '1':
                                        {
                                            line.BeginPoint.CoordX = Parse(errValue, "x1");
                                            line.BeginPoint.CoordY = Parse(errValue, "y1");
                                            line.EndPoint.CoordX = Parse(errValue, "x2");
                                            line.EndPoint.CoordY = Parse(errValue, "y2");
                                            break;
                                        }

                                    case '2':
                                        {
                                            Console.WriteLine(line.Length);
                                            break;
                                        }

                                    case '0':
                                        {
                                            exit = true;
                                            break;
                                        }

                                    default:
                                        {
                                            Console.WriteLine(errValue);
                                            break;
                                        }
                                }
                            }

                            break;
                        }

                    case '2':
                        {
                            Square square = new Square();
                            exit = false;
                            while (!exit)
                            {
                                Console.WriteLine(chooseAction);
                                Console.WriteLine("1.Ввести точки\n2.Вычислить сторону\n0.Назад");
                                choose = Console.ReadKey().KeyChar;
                                Console.WriteLine();
                                switch (choose)
                                {
                                    case '1':
                                        {
                                            square.BeginPoint.CoordX = Parse(errValue, "x1");
                                            square.BeginPoint.CoordY = Parse(errValue, "y1");
                                            square.EndPoint.CoordX = Parse(errValue, "x2");
                                            square.EndPoint.CoordY = Parse(errValue, "y2");
                                            break;
                                        }

                                    case '2':
                                        {
                                            Console.WriteLine(square.Width);
                                            break;
                                        }

                                    case '0':
                                        {
                                            exit = true;
                                            break;
                                        }

                                    default:
                                        {
                                            Console.WriteLine(errValue);
                                            break;
                                        }
                                }
                            }

                            break;
                        }

                    case '3':
                        {
                            Rectangle rectangle = new Rectangle();
                            exit = false;
                            while (!exit)
                            {
                                Console.WriteLine(chooseAction);
                                Console.WriteLine("1.Ввести точки\n2.Вычислить высоту\n4.Вычислить ширину\n0.Назад");
                                choose = Console.ReadKey().KeyChar;
                                Console.WriteLine();
                                switch (choose)
                                {
                                    case '1':
                                        {
                                            rectangle.BeginPoint.CoordX = Parse(errValue, "x1");
                                            rectangle.BeginPoint.CoordY = Parse(errValue, "y1");
                                            rectangle.EndPoint.CoordX = Parse(errValue, "x2");
                                            rectangle.EndPoint.CoordY = Parse(errValue, "y2");
                                            break;
                                        }

                                    case '2':
                                        {
                                            Console.WriteLine(rectangle.Heigth);
                                            break;
                                        }

                                    case '3':
                                        {
                                            Console.WriteLine(rectangle.Width);
                                            break;
                                        }

                                    case '0':
                                        {
                                            exit = true;
                                            break;
                                        }

                                    default:
                                        {
                                            Console.WriteLine(errValue);
                                            break;
                                        }
                                }
                            }

                            break;
                        }

                    case '4':
                        {
                            Triangle triangle = new Triangle();
                            exit = false;
                            while (!exit)
                            {
                                Console.WriteLine(chooseAction);
                                Console.WriteLine("1.Ввести точки\n2.Вычислить 1-ю сторону");
                                Console.WriteLine("3.Вычслить 2-ю сторону\n4.Вычислить 3-ю сторону\n0.Назад");
                                choose = Console.ReadKey().KeyChar;
                                switch (choose)
                                {
                                    case '1':
                                        {
                                            triangle.BeginPoint.CoordX = Parse(errValue, "x1");
                                            triangle.BeginPoint.CoordY = Parse(errValue, "y1");
                                            triangle.MiddlePoint.CoordX = Parse(errValue, "x2");
                                            triangle.MiddlePoint.CoordY = Parse(errValue, "y2");
                                            triangle.EndPoint.CoordX = Parse(errValue, "x3");
                                            triangle.EndPoint.CoordY = Parse(errValue, "y3");

                                            break;
                                        }

                                    case '2':
                                        {
                                            Console.WriteLine(triangle.Distance(triangle.MiddlePoint, triangle.BeginPoint));
                                            break;
                                        }

                                    case '3':
                                        {
                                            Console.WriteLine(triangle.Distance(triangle.EndPoint, triangle.MiddlePoint));
                                            break;
                                        }

                                    case '4':
                                        {
                                            Console.WriteLine(triangle.Distance(triangle.EndPoint, triangle.BeginPoint));
                                            break;
                                        }

                                    case '0':
                                        {
                                            exit = true;
                                            break;
                                        }

                                    default:
                                        {
                                            Console.WriteLine(errValue);
                                            break;
                                        }
                                }
                            }

                            break;
                        }

                    case '5':
                        {
                            Round round = new Round();
                            exit = false;
                            while (!exit)
                            {
                                Console.WriteLine(chooseAction);
                                Console.WriteLine("1.Ввести точки\n2.Ввести радиус\n3Вывести радиус\n0.Назад");
                                choose = Console.ReadKey().KeyChar;
                                Console.WriteLine();
                                switch (choose)
                                {
                                    case '1':
                                        {
                                            round.CenterPoint.CoordX = Parse(errValue, "x");
                                            round.CenterPoint.CoordY = Parse(errValue, "y");
                                            break;
                                        }

                                    case '2':
                                        {
                                            round.Radius = Parse(errValue, "радиус");
                                            break;
                                        }

                                    case '3':
                                        {
                                            Console.WriteLine(round.Radius);
                                            break;
                                        }

                                    case '0':
                                        {
                                            exit = true;
                                            break;
                                        }

                                    default:
                                        {
                                            Console.WriteLine(errValue);
                                            break;
                                        }
                                }
                            }

                            break;
                        }

                    case '0':
                        {
                            return;
                        }

                    default:
                        {
                            Console.WriteLine(errValue);
                            break;
                        }
                }  
            }  
        }

        private static double Parse(string errMessage, string outMesage)
        {
            double result;
            string value;
            for (;;)
            {
                Console.WriteLine("Введите " + outMesage);
                value = Console.ReadLine();
                if (!double.TryParse(value, out result))
                {
                    Console.WriteLine(errMessage);
                    continue;
                }

                return result;
            }
        }
    }
}
