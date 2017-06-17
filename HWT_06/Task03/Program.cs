// Напишите заготовку для векторного графического редактора.
// Полная версия редактора должна позволять создавать и выводить на экран такие фигуры как: Линия, Окружность, Прямоугольник, Круг, Кольцо.
namespace Task03
{
    using System;
    using System.Text;
    using Task03;

    public class Program
    {
        private static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            char choose;
            double radius;
            Point point;
            bool exit;
            for (;;)
            {
                Console.WriteLine("Выберите фигуру:");
                Console.WriteLine("1.Линия\n2.Прямоугольник\n3.Окружность\n4.Круг\n5.Кольцо\n0.Выход");
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
                                Console.WriteLine(Resource1.chooseAction);
                                Console.WriteLine("1.Ввести точки\n2.Вычислить длину\n0.Назад");
                                choose = Console.ReadKey().KeyChar;
                                Console.WriteLine();
                                switch (choose)
                                {
                                    case '1':
                                        {
                                            line.BeginPoint.CoordX = Parse("x1");
                                            line.BeginPoint.CoordY = Parse("y1");
                                            line.EndPoint.CoordX = Parse("x2");
                                            line.EndPoint.CoordY = Parse("y2");
                                            break;
                                        }

                                    case '2':
                                        {
                                            Console.WriteLine(line.GetLength());
                                            break;
                                        }

                                    case '0':
                                        {
                                            exit = true;
                                            break;
                                        }

                                    default:
                                        {
                                            Console.WriteLine(Resource1.errValue);
                                            break;
                                        }
                                }
                            }

                            break;
                        }

                    case '2':
                        {
                            Rectangle rectangle = new Rectangle();
                            exit = false;
                            while (!exit)
                            {
                                Console.WriteLine(Resource1.chooseAction);
                                Console.WriteLine("1.Ввести точки\n2.Показать высоту\n3.Показать ширину" +
                                    "\n4.Показать периметр\n5.Показать площадь\n0.Назад");
                                choose = Console.ReadKey().KeyChar;
                                Console.WriteLine();
                                switch (choose)
                                {
                                    case '1':
                                        {
                                            rectangle.BeginPoint.CoordX = Parse("x1");
                                            rectangle.BeginPoint.CoordY = Parse("y1");
                                            rectangle.EndPoint.CoordX = Parse("x2");
                                            rectangle.EndPoint.CoordY = Parse("y2");
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

                                    case '4':
                                        {
                                            Console.WriteLine(rectangle.GetPerimeter());
                                            break;
                                        }

                                    case '5':
                                        {
                                            Console.WriteLine(rectangle.GetArea());
                                            break;
                                        }

                                    case '0':
                                        {
                                            exit = true;
                                            break;
                                        }

                                    default:
                                        {
                                            Console.WriteLine(Resource1.errValue);
                                            break;
                                        }
                                }
                            }

                            break;
                        }

                    case '3':
                        {
                            point = new Point(Parse("x"), Parse("y"));
                            InputRadius(out radius);

                            Circle circle = new Circle(point, radius);
                            exit = false;
                            while (!exit)
                            {
                                Console.WriteLine(Resource1.chooseAction);
                                Console.WriteLine("1.Ввести центральную точку\n2.Показать радиус\n3.Показать длину окружности\n0.Назад");
                                choose = Console.ReadKey().KeyChar;
                                Console.WriteLine();
                                switch (choose)
                                {
                                    case '1':
                                        {
                                            point = new Point(Parse("x"), Parse("y"));
                                            circle.BeginPoint = point;
                                            break;
                                        }

                                    case '2':
                                        {
                                            Console.WriteLine(circle.Radius);
                                            break;
                                        }

                                    case '3':
                                        {
                                            Console.WriteLine(circle.GetPerimeter());
                                            break;
                                        }

                                    case '0':
                                        {
                                            exit = true;
                                            break;
                                        }

                                    default:
                                        {
                                            Console.WriteLine(Resource1.errValue);
                                            break;
                                        }
                                }
                            }

                            break;
                        }

                    case '4':
                        {
                            point = new Point(Parse("x"), Parse("y"));
                            InputRadius(out radius);

                            Disc disc = new Disc(point, radius);
                            exit = false;
                            while (!exit)
                            {
                                Console.WriteLine(Resource1.chooseAction);
                                Console.WriteLine("1.Ввести центральную точку\n2.Показать радиус\n3.Показать длину внешней окружности\n" +
                                    "4.Показать площадь круга\n0.Назад");
                                choose = Console.ReadKey().KeyChar;
                                Console.WriteLine();
                                switch (choose)
                                {
                                    case '1':
                                        {
                                            point = new Point(Parse("x"), Parse("y"));
                                            disc.BeginPoint = point;
                                            break;
                                        }

                                    case '2':
                                        {
                                            Console.WriteLine(disc.Radius);
                                            break;
                                        }

                                    case '3':
                                        {
                                            Console.WriteLine(disc.GetPerimeter());
                                            break;
                                        }

                                    case '4':
                                        {
                                            Console.WriteLine(disc.GetArea());
                                            break;
                                        }

                                    case '0':
                                        {
                                            exit = true;
                                            break;
                                        }

                                    default:
                                        {
                                            Console.WriteLine(Resource1.errValue);
                                            break;
                                        }
                                }
                            }

                            break;
                        }

                    case '5':
                        {
                            point = new Point(Parse("x"), Parse("y"));
                            double outerRadius;
                            double innerRadius;
                            for (;;)
                            {
                                InputRadius(out innerRadius, "внутренний ");
                                InputRadius(out outerRadius, "внешний ");
                                if (outerRadius < innerRadius)
                                {
                                    Console.WriteLine(Resource1.errCmpRad);
                                    continue;
                                }

                                break;
                            }
                            

                            Ring Ring = new Ring(point, innerRadius, outerRadius);
                            exit = false;
                            while (!exit)
                            {
                                Console.WriteLine(Resource1.chooseAction);
                                Console.WriteLine("1.Ввести центральную точку\n2.Показать внешний радиус\n3.Показать внутренний радиус\n" +
                                    "4.Показать площадь кольца\n5.Показать сумму длин окружжностей\n0.Назад");
                                choose = Console.ReadKey().KeyChar;
                                Console.WriteLine();
                                switch (choose)
                                {
                                    case '1':
                                        {
                                            point = new Point(Parse("x"), Parse("y"));
                                            Ring.BeginPoint = point;
                                            break;
                                        }

                                    case '2':
                                        {
                                            Console.WriteLine(Ring.OuterRadius);
                                            break;
                                        }

                                    case '3':
                                        {
                                            Console.WriteLine(Ring.InnerRadius);
                                            break;
                                        }

                                    case '4':
                                        {
                                            Console.WriteLine(Ring.GetArea());
                                            break;
                                        }

                                    case '5':
                                        {
                                            Console.WriteLine(Ring.GetPerimeter());
                                            break;
                                        }

                                    case '0':
                                        {
                                            exit = true;
                                            break;
                                        }

                                    default:
                                        {
                                            Console.WriteLine(Resource1.errValue);
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
                            Console.WriteLine(Resource1.errValue);
                            break;
                        }
                }
            }
        }

        private static void InputRadius(out double radius, string str = "")
        {
            for (;;)
            {
                radius = Parse(str + "радиус");
                if (radius < 0)
                {
                    Console.WriteLine(Resource1.errRadNeg);
                    continue;
                }

                return;
            }
        }

        private static double Parse(string outMesage)
        {
            double result;
            string value;
            for (;;)
            {
                Console.WriteLine("Введите " + outMesage);
                value = Console.ReadLine();
                if (!double.TryParse(value, out result))
                {
                    Console.WriteLine(Resource1.errValue);
                    continue;
                }

                return result;
            }
        }
    }
}