namespace Task03
{
    using System;

    public class User
    {
        private DateTime birthDate;

        public User()
        {
           this.SecondName = string.Empty;
           this.FirstName = string.Empty;
           this.MiddleName = string.Empty;
        }

        public string SecondName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public int Age { get; private set; }

        public DateTime BirthDate
        {
            get
            {
                return this.birthDate;
            }

            set
            {
                this.birthDate = value;
                DateTime now = DateTime.Now;
                DateTime tick = new DateTime((now - value).Ticks);
                this.Age = tick.Year - 1;
            }
        }
    }
}
