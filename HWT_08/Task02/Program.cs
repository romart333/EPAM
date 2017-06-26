namespace Task02
{
    using System;
    using System.Text;

    public delegate void GreetingMessage(Person person, Time time);

    public delegate void PartingMessage(Person person);

    public class Program
    {

        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Person Ivan = new Person("Иван");
            Person Petr = new Person("Петр");
            Person Alexander = new Person("Александр");
                        
            Ivan.Enter();
            GreetingMessage Greet = new GreetingMessage(Ivan.Greeting);

            Petr.OnCame += Greet;
            Petr.Enter();
            Greet += Petr.Greeting;

            Alexander.OnCame += Greet;
            Alexander.Enter();

            PartingMessage Parting = Ivan.Parting;
            // если написать PartingMessage Parting = Ivan.Parting + Petr.Parting -
            // - ругается: "+" невозможно применить к операнду типа "группа методов".
            // Почему так пишет?
            Parting += Petr.Parting;
            Alexander.OnLeave += Parting;
            Alexander.Exit();

            Parting -= Petr.Parting;
            Petr.OnLeave += Parting;
            Petr.Exit();

            Ivan.Exit();

            Console.ReadLine();
        }
    }
}
