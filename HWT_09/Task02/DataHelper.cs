namespace Task02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class DataHelper
    {
        public static bool IsNumber(this string param)
        {
            for (int i = 0; i < param.Length; i++)
            {
                if (!char.IsDigit(param[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
