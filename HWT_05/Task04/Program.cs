// Написать свой собственный класс MyString, описывающий строку как массив символов. Перегрузить для этого класса типовые операции.
namespace Task04
{
    using System;
    using System.Globalization;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            char[] ch = "First ".ToCharArray();
            char[] ch2 = "Second".ToCharArray();
            MyString str = new MyString(ch);
            Console.WriteLine(str);
            MyString str2 = new MyString(ch2);
            Console.WriteLine(str2);
            str = str + str2;
            Console.WriteLine(str);
            if (str > str2)
            {
                Console.WriteLine("Первая строка больше");
            }

            if (str != str2)
            {
                Console.WriteLine("Строки не равны");
            }

            Console.ReadLine();
        }
    }
}
