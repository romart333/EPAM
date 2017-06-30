public static class DataHelper
{
    public static int Summa(this int[] param)
    {
        int buf = 0;

        for (int i = 0; i < param.Length; i++)
        {
            buf += param[i];
        }

        return buf;
    }
}
