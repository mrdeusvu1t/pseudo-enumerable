using ContainsDigitPredicate;
using PseudoEnumerableTask.Interfaces;

namespace Adapters
{
    public class ContainsDigitContainsDigitValidatorAdapter : IPredicate<int>
    {
        public int Validator { get; set; }
        public ContainsDigitContainsDigitValidatorAdapter(ContainsDigitValidator validator)
        {
            Validator = validator.Digit;
        }
        public bool Verify(int obj)
        {
            if ((obj == int.MinValue || obj == int.MaxValue) && Validator == 0)
            {
                return false;
            }

            if (obj == int.MinValue && Validator != 5)
            {
                return true;
            }

            var temp = System.Math.Abs(obj);
            do
            {
                if (temp % 10 == Validator)
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