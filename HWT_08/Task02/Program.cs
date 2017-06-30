namespace Task02
{
    using System;
    using System.Text;

    public delegate void GreetingMessage(Person person, Time time);

    public delegate void PartingMessage(Person person);

    public class Program//вынес логику в класс office, оставив только функции входа, выхода
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Person Ivan = new Person("Иван");
            Person Petr = new Person("Петр");
            Person Alexander = new Person("Александр");

            Office office = new Office();
            Ivan.Enter();

            office.InitGreeting(Ivan, Petr);
            Petr.Enter();

            office.InitGreeting(Petr, Alexander);
            Alexander.Enter();

            office.InitBye(Ivan, Petr);
            office.AddEveningBye(Alexander);
            Alexander.Exit();

            office.RemoveBye(Petr);
            office.AddEveningBye(Petr);
            Petr.Exit();

            Ivan.Exit();

            Console.ReadLine();
        }
    }
}
