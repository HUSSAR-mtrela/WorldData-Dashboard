namespace System
{
    public static class DoubleEx
    {

        public const double Kilo = 1000;
        public const double Mega = 1000000;
        public const double Giga = 1000000000;
        public const double Tera = 1000000000000;
     
        /// <summary>
        /// Converts number to short string with K, M, B, T multipliers
        /// <param name="value"></param>
        /// <param name="precision">.##</param>
        /// <remarks>https://msdn.microsoft.com/en-us/library/0c899ak8.aspx</remarks>
        /// </summary> 
        public static string ToStringShort(this double value, string precision = ".##", bool useSign = false)
        {
            var format = "";
            if (value >= Tera || value <= -Tera)
                format += "0,,,," + precision + "t";

            else if (value >= Giga || value <= -Giga)
                format += "0,,," + precision + "b";

            else if (value >= Mega || value <= -Mega)
                format += "0,," + precision + "m";

            else if (value >= Kilo || value <= -Kilo)
                format += "0," + precision + "k";

            else
                format += "0" + precision;

            //var result = string.Format(format, value);
            var result = value.ToString(format);
            if (useSign && value > 0)
                result = "+" + result;

            return result;
        }
    }
}