namespace Task02
{
    using System;

    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
        }

        public event GreetingMessage OnCame;

        public event PartingMessage OnLeave;

        public string Name { get; set; }

        public void Enter()
        {
            Console.WriteLine("\n[{0} пришел на работу.]", this.Name);
            if (this.OnCame != null)
            {
                this.OnCame(this, new Time());
            }
        }

        public void Exit()
        {
            Console.WriteLine("\n[{0} ушел домой.]", this.Name);
            if (this.OnLeave != null)
            {
                this.OnLeave(this);
            }
        }

        public void Greeting(Person person, Time time)
        {
            if (time.Timing.Hour < 12)
            {
                Console.WriteLine("\'{0}, Доброе утро\', - сказал {1}.", person.Name, this.Name);
                return;
            }

            if (time.Timing.Hour >= 17)
            {
                Console.WriteLine("\'{0}, Добрый вечер\', - сказал {1}.", person.Name, this.Name);
                return;
            }

            if (time.Timing.Hour >= 12)
            {
                Console.WriteLine("\'{0}, Добрый день\', - сказал {1}.", person.Name, this.Name);
                return;
            }
        }

        public void Parting(Person person)
        {
            Console.WriteLine("\'{0}, До свидания\', - сказал {1}", person.Name, this.Name);
        }
    }
}
