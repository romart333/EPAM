// Написать программу, которая определяет площадь прямоугольника со сторонами a и b.
// Если пользователь вводит некорректные значения (отрицательные, или 0), должно выдаваться сообщение об ошибке.
// Возможность ввода пользователем строки вида «абвгд», или нецелых чисел игнорировать.
namespace Task01 //todo pn заданий было 2, поэтому и солюшенов должно быть 2.
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            int heigth = 0, width = 0;//todo pn инициализировать переменные значениями по умолчанию бессмысленно.
            bool result = false;//todo pn инициализировать переменные значениями по умолчанию бессмысленно.

			do
            {
                Console.WriteLine("Введите высоту прямоугольника: ");
                result = int.TryParse(Console.ReadLine(), out heigth);
                if (!result || heigth <= 0)
                {
                    Console.WriteLine("Неверный ввод.");
                    continue;
                }

                break;
            }
            while (true);

            do
            {
                Console.WriteLine("Введите ширину прямоугольника: ");
                result = int.TryParse(Console.ReadLine(), out width);
                if (!result || width <= 0)
                {
                    Console.WriteLine("Неверный ввод.");
                    continue;
                }

                break;
            }
            while (true);

            int areaRectangle = heigth * width;
            Console.WriteLine($"Площадь прямоугольника = {areaRectangle}");
            Console.ReadKey();
        }
    }
}
