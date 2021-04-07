namespace ContainsDigitPredicate
{
    //TODO: See your solution of this task https://gitlab.com/epam-autocode-tasks/int-array-filter
    public class ContainsDigitValidator
    {
        private int digit;
        public int Digit
        {
            get => digit;
            set => digit = value;
        }

        public bool Verify(int value)
        {
            if ((value == int.MinValue || value == int.MaxValue) && Digit == 0)
            {
                return false;
            }

            if (value == int.MinValue && Digit != 5)
            {
                return true;
            }

            var temp = System.Math.Abs(value);
            do
            {
                if (temp % 10 == Digit)
                {
                    return true;
                }

                temp /= 10;
            }
            while (temp != 0);

            return false;
        }
    }
}