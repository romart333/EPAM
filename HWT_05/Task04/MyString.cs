namespace Task04
{
    using System;

    public class MyString
    {
        private char[] str;

        public static implicit operator string(MyString obj)
        {
            return new string(obj.str);
        }

        public char this[int index]
        {
            get
            {
                if (index >= 0 && index < this.str.Length)
                {
                    return this.str[index];
                }

                return this.str[0];
            }

            set
            {
                if (index >= 0 && index < this.str.Length)
                {
                    this.str[index] = value;
                }
            }
        }

        public MyString()
        {
            this.str = new char[1];
        }

        public MyString(int count)
        {
            this.str = new char[count];
        }

         public MyString(char[] str)
        {
            this.str = new char[str.Length];
            this.str = str;
        }

        public static MyString operator +(MyString obj1, MyString obj2)
        {
            int count = obj1.str.Length + obj2.str.Length;
            char[] buf = new char[count];
            for (int i = 0; i < obj1.str.Length; i++)
            {
                buf[i] = obj1.str[i];
            }

            for (int i = 0; i < obj2.str.Length; i++)
            {
                buf[i + obj1.str.Length] = obj2.str[i];
            }

            return new MyString(buf);
        }

        public static bool operator ==(MyString obj1, MyString obj2)
        {
            if (obj1.str.Length != obj2.str.Length)
            {
                return false;
            }

            for (int i = 0; i < obj1.str.Length; i++)
            {
                if (obj1.str[i] != obj2.str[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator !=(MyString obj1, MyString obj2)
        {
            if (obj1.str.Length != obj2.str.Length)
            {
                return true;
            }

            for (int i = 0; i < obj1.str.Length; i++)
            {
                if (obj1.str[i] != obj2.str[i])
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator <(MyString obj1, MyString obj2)
        {
            if (obj1.str.Length < obj2.str.Length)
            {
                return true;
            }

            if (obj1.str.Length > obj2.str.Length)
            {
                return false;
            }

            if (obj1.str[0] < obj2.str[0])
            {
                return true;
            }

            return false;
        }

        public static bool operator >(MyString obj1, MyString obj2)
        {
            if (obj1.str.Length > obj2.str.Length)
            {
                return true;
            }

            if (obj1.str.Length < obj2.str.Length)
            {
                return false;
            }

            if (obj1.str[0] > obj2.str[0])
            {
                return true;
            }

            return false;
        }
    }
}
