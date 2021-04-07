using System;
using System.Collections.Generic;

namespace Comparers
{
    public class StringByLengthComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x != null && y != null)
			{
                if (x.Length > y.Length)
                {
                    return 1;
                }
                if (x.Length < y.Length)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            if (x == null)
			{
                return -1;
			}
			else
			{
                return 0;
			}


        }
    }
}