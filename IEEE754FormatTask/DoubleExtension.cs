using System;

namespace IEEE754FormatTask
{
    public static class DoubleExtension
    {
        //TODO: See your solution of this task https://gitlab.com/epam-autocode-tasks/ieee754
        
        /// <summary>
        /// Returns a string representation of a double type number
        /// in the IEEE754 (see https://en.wikipedia.org/wiki/IEEE_754) format.
        /// </summary>
        /// <param name="number">Input number.</param>
        /// <returns>A string representation of a double type number in the IEEE754 format.</returns>
        public static string GetIEEE754Format(this double number)
        {
            var str = BitConverter.ToInt64(BitConverter.GetBytes(number), 0);
            var sign = str >> 63 & 0x01;
            var exponent = str >> 52 & 0x7FF;
            var mantissa = str & 0x1FFFFFFFFFFFFF;

            return Convert.ToString(str, 2).PadLeft(64, '0');
        }
    }
}