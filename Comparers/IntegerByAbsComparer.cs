using System;
using System.Collections.Generic;

namespace Comparers
{
    public class IntegerByAbsComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (Math.Abs(x) > Math.Abs(y))
            {
                return 1;
            }
            if (Math.Abs(x) < Math.Abs(y))
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