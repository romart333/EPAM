namespace Task02
{
    using System;

    public class Time : EventArgs
    {
        public DateTime Timing
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
