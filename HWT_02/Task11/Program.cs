// Написать программу, которая генерирует случайным образом элементы массива(число элементов в массиве и их тип определяются разработчиком), определяет для него максимальное и минимальное значения, сортирует массив и выводит полученный результат на экран.
namespace Task11
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            int count = 10, choose = 0, arrayMax = 0, arrayMin = 0;
            int[] array = new int[count];
            bool result = false;

            for (;;)
            {
                for (;;)
                {
                    Console.WriteLine("Выберите действие:\n\t1.Заполнение массива\n\t2.Найти максимум\n\t" +
                "3.Найти минимум\n\t4.Сортировка массива\n\t5.Вывод массива");
                    result = int.TryParse(Console.ReadKey().KeyChar.ToString(), out choose);
                    Console.WriteLine();
                    if (!result || choose < 1 || choose > 6)
                    {
                        Console.WriteLine("Неверный ввод.");
                        continue;
                    }

                    break;
                }

                switch (choose)
                {
                    case 1:
                        {
                            SetArrayRandom(array);
                            break;
                        }

                    case 2:
                        {
                            arrayMax = FindArrayMax(array);
                            Console.WriteLine("Максимальный элемент = {0}", arrayMax);
                            break;
                        }

                    case 3:
                        {
                            arrayMin = FindArrayMin(array);
                            Console.WriteLine("Минимальный элемент = {0}", arrayMin);
                            break;
                        }

                    case 4:
                        {
                            SortArray(array);
                            break;
                        }

                    case 5:
                        {
                            ShowArray(array);
                            break;
                        }
                }
            }
        }

        public static void SetArrayRandom(params int[] array)
        {
            int seed = 100;
            Random rand = new Random(seed);

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(seed);
            }
        }

        public static int FindArrayMax(params int[] array)
        {
            int max = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            return max;
        }

        public static int FindArrayMin(params int[] array)
        {
            int min = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            return min;
        }

        public static void SortArray(params int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        array[j] ^= array[j + 1];
                        array[j + 1] ^= array[j];
                        array[j] ^= array[j + 1];
                    }
                }
            }
        }

        public static void ShowArray(params int[] array)
        {
            Console.Write("Массив: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }

            Console.WriteLine();
        }
    }
}