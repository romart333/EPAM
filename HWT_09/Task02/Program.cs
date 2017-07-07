namespace Task02
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите строку: ");
            string str = Console.ReadLine();
            Console.WriteLine("Строка{0}является числом.", str.IsNumber() ? " " : " не ");//todo pn где проверка на положительность числа?

            Console.ReadLine();
        }
    }
}
