//  создать класс Employee, описывающий сотрудника фирмы. В дополнение к полям пользователя добавить поля «стаж работы» и «должность». 
namespace Task01
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

            string input = string.Empty;
            Employee employee = new Employee();
            Console.WriteLine("Введите имя:");
            employee.FirstName = Console.ReadLine();
            Console.WriteLine("Введите фаилию:");
            employee.SecondName = Console.ReadLine();
            Console.WriteLine("Введите отчество:");
            employee.MiddleName = Console.ReadLine();
            DateTime birth;
            for (;;)
            {
                Console.WriteLine("Введите дату рождения в формате дд.мм.гггг :");
                input = Console.ReadLine();
                if (DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out birth))
                {
                    break;
                }

                Console.WriteLine();
            }

            employee.BirthDate = birth;
            employee.LengthOfWork = InputInt("Введите стаж работы:", Resource1.strErrWork);
            Console.WriteLine("Введите должность:");
            employee.Position = Console.ReadLine();

            char choose;
            for (;;)
            {
                Console.WriteLine("Выберите необходимую информацию о человеке:");
                Console.WriteLine("1 - ФИО\n2 - Дата рождения, возраст\n3 - Стаж работы\n4 - Должность\n0 - Выход");
                choose = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (choose)
                {
                    case '1':
                        {
                            Console.WriteLine($"ФИО: {employee.SecondName} {employee.FirstName} {employee.MiddleName}");
                            break;
                        }

                    case '2':
                        {
                            Console.WriteLine($"Дата рождения: {employee.BirthDate: dd.MM.yyyy}, Возраст: {employee.Age}");
                            break;
                        }

                    case '3':
                        {
                            Console.WriteLine($"Стаж работы: {employee.LengthOfWork}");
                            break;
                        }

                    case '4':
                        {
                            Console.WriteLine($"Должность: {employee.Position}");
                            break;
                        }

                    case '0':
                        {
                            return;
                        }

                    default:
                        {
                            Console.WriteLine(Resource1.strErrChoose);
                            break;
                        }
                }
            }
        }

        public static int InputInt(string message, string errMessage)
        {
            string str = string.Empty;
            int value;

            for (;;)
            {
                Console.WriteLine(message);
                str = Console.ReadLine();
                if (!int.TryParse(str, out value))
                {
                    Console.WriteLine(errMessage);
                    continue;
                }

                return value;
            }
        }
    }
}
