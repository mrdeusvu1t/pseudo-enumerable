using PseudoEnumerableTask.Interfaces;
using System;

namespace Adapters
{
    public class GetIEEE754FormatAdapter : ITransformer<double, string>
    {

        
        public string Transform(double obj)
        {
            var str = BitConverter.ToInt64(BitConverter.GetBytes(obj), 0);
            var sign = str >> 63 & 0x01;
            var exponent = str >> 52 & 0x7FF;
            var mantissa = str & 0x1FFFFFFFFFFFFF;

            return Convert.ToString(str, 2).PadLeft(64, '0');
        }
    }
}