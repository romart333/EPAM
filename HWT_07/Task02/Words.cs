// Задан английский текст. Выделить отдельные слова и для каждого посчитать частоту встречаемости. Слова, отличающиеся регистром, считать одинаковыми.
namespace Task02
{
    using System;

    public class Words
    {
        public Words()
        {
            this.Str = string.Empty;
        }

        public Words(string word)
        {
            this.Str = word;
            this.Сount++;
        }

        public string Str { get; set; }

        public int Сount { get; set; }
    }
}
