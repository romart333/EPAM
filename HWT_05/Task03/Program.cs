// Написать класс User, описывающий человека (Фамилия, Имя, Отчество, Дата рождения, Возраст). Написать программу, демонстрирующую использование этого класса. 
namespace Task03
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

            char choose;
            string inputError = "Неверный ввод";
            string input = string.Empty;
            User user = new User();
            Console.WriteLine("Введите имя:");
            user.FirstName = Console.ReadLine();
            Console.WriteLine("Введите фаилию:");
            user.SecondName = Console.ReadLine();
            Console.WriteLine("Введите отчество:");
            user.MiddleName = Console.ReadLine();
            DateTime birth;
            for (;;)
            {
                Console.WriteLine("Введите дату рождения в формате дд.мм.гггг :");
                input = Console.ReadLine();
                if (DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out birth))
                {
                    break;
                }

                Console.WriteLine(inputError);
            }

            user.BirthDate = birth;

            for (;;)
            {
                Console.WriteLine("Выберите необходимую информацию о человеке:");
                Console.WriteLine("1 - ФИО\n2 - Дата рождения, возраст\n0 - Выход");
                choose = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (choose)
                {
                    case '1':
                        {
                            Console.WriteLine($"ФИО: {user.SecondName} {user.FirstName} {user.MiddleName}");
                            break;
                        }

                    case '2':
                        {
                            Console.WriteLine($"Дата рождения: {user.BirthDate: dd.MM.yyyy}, Возраст: {user.Age}");
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
    }
}
