namespace Task02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Office
    {
        private GreetingMessage greeting;
        private PartingMessage parting;


        public void InitGreeting(Person active, Person passive)
        {
            this.greeting += active.Greeting;
            passive.OnCame += this.greeting;
        }

        public void InitBye(params Person[] persons)
        {
            foreach (Person person in persons)
            {
                parting += person.Parting;
            }
        }

        public void AddEveningBye(Person personOut)
        {
            if (this.parting != null)
            {
                personOut.OnLeave += this.parting;
            }
        }

        public void RemoveBye(Person person)
        {
            if (this.parting != null)
            {
                this.parting -= person.Parting;
            }
        }
    }
}
