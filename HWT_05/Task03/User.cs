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

            set // Вычисление возраста сравнением лет,месяцев,дней
            {
                this.birthDate = value;
           
                DateTime now = DateTime.Now;
                this.Age = now.Year - this.birthDate.Year;
                if (this.birthDate.Month >= now.Month && this.birthDate.Day >= now.Day)
                {
                    this.Age--;
                }
			}
        }
    }
}
