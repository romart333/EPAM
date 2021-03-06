﻿// Написать консольное приложение, которое проверяет принадлежность точки заштрихованной области.
// Пользователь вводит координаты точки (x; y) и выбирает букву графика(a-к). В консоли должно высветиться сообщение: «Точка[(x; y)] принадлежит фигуре[г]». 

using System.Text;

namespace Task01
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            char ch;
            string comparison = "абвгдежзик";
            while (true)
            {
                Console.WriteLine("Введите букву от а до к для выбора графика:");
                ch = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (comparison.IndexOf(ch) < 0)
                {
                    Console.WriteLine("Неверный ввод.");
                    continue;
                }

                break;
            }

            double xUser, yUser;
            while (true)
            {
                Console.WriteLine("Введите координату x:");
                try
                {
                    xUser = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                break;
            }

            while (true)
            {
                Console.WriteLine("Введите координату y:");
                try
                {
                    yUser = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                break;
            }

            bool pointInside = false;
            switch (ch)
            {
                case 'a':
                    {
                        pointInside = Figure1IncludesPoint(xUser, yUser);
                        break;
                    }

                case 'б':
                    {
                        pointInside = Figure2IncludesPoint(xUser, yUser);
                        break;
                    }

                case 'в':
                    {
                        pointInside = Figure3IncludesPoint(xUser, yUser);
                        break;
                    }

                case 'г':
                    {
                        pointInside = Figure4IncludesPoint(xUser, yUser);
                        break;
                    }

                case 'д':
                    {
                        pointInside = Figure5IncludesPoint(xUser, yUser);
                        break;
                    }

                case 'е':
                    {
                        pointInside = Figure6IncludesPoint(xUser, yUser);
                        break;
                    }

                case 'ж':
                    {
                        pointInside = Figure7IncludesPoint(xUser, yUser);
                        break;
                    }

                case 'з':
                    {
                        pointInside = Figure8IncludesPoint(xUser, yUser);
                        break;
                    }

                case 'и':
                    {
                        pointInside = Figure9IncludesPoint(xUser, yUser);
                        break;
                    }

                case 'к':
                    {
                        pointInside = Figure10IncludesPoint(xUser, yUser);
                        break;
                    }
            }

            Console.WriteLine("Точка[({0};{1})]{2}принадлежит  фигуре [{3}]", xUser, yUser, pointInside ? " " : " НЕ ", ch);

            Console.ReadKey();
        }

        private static bool Figure1IncludesPoint(double x, double y) // окружность
        {
            double radius = 1;
            if (Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(radius, 2))
            {
                return true;
            }

            return false;
        }

        private static bool Figure2IncludesPoint(double x, double y) // вырезанная  часть окружности
        {
            double externalRadius = 1, internalRadius = 0.5;
            double sumSquares = Math.Pow(x, 2) + Math.Pow(y, 2);
            if (sumSquares <= Math.Pow(externalRadius, 2) && (sumSquares >= Math.Pow(internalRadius, 2)))
            {
                return true;
            }

            return false;
        }

        private static bool Figure3IncludesPoint(double x, double y) // квадрат
        {
            double lengthOfSide = 1;
            if ((Math.Abs(x) <= lengthOfSide) && (Math.Abs(y) <= lengthOfSide))
            {
                return true;
            }

            return false;
        }

        private static bool Figure4IncludesPoint(double x, double y) // ромб с одинаковыми сторонами
        {
            double maxRhomb = 1;
            if (Math.Abs(x) + Math.Abs(y) <= maxRhomb)
            {
                return true;
            }

            return false;
        }

        private static bool Figure5IncludesPoint(double x, double y) // ромб
        {
            double xMaxRhomb = 0.5, yMaxRhomb = 1;
            if (((yMaxRhomb * Math.Abs(x)) + (xMaxRhomb * Math.Abs(y))) <= xMaxRhomb * yMaxRhomb)
            {
                return true;
            }

            return false;
        }

        private static bool Figure6IncludesPoint(double x, double y) // "капля"
        {
            double leftXTriangle = -2, xMiddle = 0, radius = 1;
            if (x >= leftXTriangle && x <= xMiddle)
            {
                if (((x + 2) / 2) >= Math.Abs(y))
                {
                    return true;
                }
            }

            if ((Math.Pow(x, 2) + Math.Pow(y, 2)) <= Math.Pow(radius, 2))
            {
                return true;
            }

            return false;
        }

        private static bool Figure7IncludesPoint(double x, double y) // треугольник
        {
            double topPoint = 2, bottomPoint = -1;
            if ((y >= topPoint) || (y <= bottomPoint))
            {
                return false;
            }

            if (y <= (((-2) * Math.Abs(x)) + topPoint))
            {
                return true;
            }

            return false;
        }

        private static bool Figure8IncludesPoint(double x, double y)
        {
            double xRestriction = 1, topRestriction = 1, bottomRestriction = -2;
            if ((y < Math.Abs(x)) && (Math.Abs(x) < xRestriction) && (y < topRestriction) && (y > bottomRestriction))
            {
                return true;
            }

            return false;
        }

        private static bool Figure9IncludesPoint(double x, double y) // проверка попадания точки: 1. в нижнюю часть 2. правую верхнюю 3.x<0, y>0 правая часть 4.x<0 y>0 левая часть
        {
            if (y < (x - 1) / 3)
            {
                return false;
            }

            if ((x > 0) && (y > 0))
            {
                return false;
            }

            if (y > -x && x < 0)
            {
                return false;
            }

            if (y > (2 * x) + 3)
            {
                return false;
            }

            return true;
        }

        private static bool Figure10IncludesPoint(double x, double y) // проверка от обратного
        {
            double top = 1;
            if ((y >= Math.Abs(x)) || (y >= top))
            {
                return true;
            }

            return false;
        }
    }
}
