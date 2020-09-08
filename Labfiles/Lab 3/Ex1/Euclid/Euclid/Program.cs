namespace Euclid
{
    /// <summary>
    /// Class calculates the Greatest Common Divisor by using Euclid’s Algorithm
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point
        /// </summary>
        public static void Main()
        {

        }
        /// <summary>
        /// Method calculates the result
        /// </summary>
        /// <param name="firstParam">First parameter</param>
        /// <param name="secondParam">Second parameter</param>
        /// <returns>Result</returns>
        public static int Gcd(int firstParam, int secondParam)
        {
            int remainder;
            while ((remainder = firstParam % secondParam) != 0)
            {
                firstParam = secondParam;
                secondParam = remainder;
            }

            return secondParam;
        }
        /// <summary>
        /// Method calculates the result
        /// </summary>
        /// <param name="ints">Array of Integers</param>
        /// <returns>Result</returns>
        public static int Gcd(params int[] ints)
        {
            if ((ints is null) || (ints.Length == 0))
            {
                return 0;
            }
            if (ints.Length == 1)
            {
                return ints[0];
            }
            var returnValue = Gcd(ints[0], ints[1]);
            for (int i = 2; i < ints.Length; i++)
            {
                returnValue = Gcd(ints[i], returnValue);
            }

            return returnValue;
        }
    }
}
