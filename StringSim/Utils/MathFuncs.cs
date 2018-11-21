using System;

namespace Helpers.StringSim.Utils
{
    /// <summary>
    /// Number of handy maths functions.
    /// </summary>
    public static class MathFuncs
    {
        /// <summary>
        /// Returns the max of three numbers.
        /// </summary>
        /// <param name="firstNumber">first number to test</param>
        /// <param name="secondNumber">second number to test</param>
        /// <param name="thirdNumber">third number to test</param>
        /// <returns>the max of three numbers</returns>
        public static double MaxOf3(double firstNumber, double secondNumber, double thirdNumber)
        {
            return Math.Max(firstNumber, Math.Max(secondNumber, thirdNumber));
        }

        /// <summary>
        /// Returns the max of three numbers.
        /// </summary>
        /// <param name="firstNumber">first number to test</param>
        /// <param name="secondNumber">second number to test</param>
        /// <param name="thirdNumber">third number to test</param>
        /// <returns>the max of three numbers</returns>
        public static int MaxOf3(int firstNumber, int secondNumber, int thirdNumber)
        {
            return Math.Max(firstNumber, Math.Max(secondNumber, thirdNumber));
        }

        /// <summary>
        /// Returns the max of four numbers.
        /// </summary>
        /// <param name="firstNumber">first number to test</param>
        /// <param name="secondNumber">second number to test</param>
        /// <param name="thirdNumber">third number to test</param>
        /// <param name="fourthNumber">fourth number to test</param>
        /// <returns>the max of four numbers</returns>
        public static double MaxOf4(double firstNumber, double secondNumber, double thirdNumber, double fourthNumber)
        {
            return Math.Max(Math.Max(firstNumber, secondNumber), Math.Max(thirdNumber, fourthNumber));
        }

        /// <summary>
        /// Returns the min of three numbers.
        /// </summary>
        /// <param name="firstNumber">first number to test</param>
        /// <param name="secondNumber">second number to test</param>
        /// <param name="thirdNumber">third number to test</param>
        /// <returns>the min of three numbers</returns>
        public static double MinOf3(double firstNumber, double secondNumber, double thirdNumber)
        {
            return Math.Min(firstNumber, Math.Min(secondNumber, thirdNumber));
        }

        /// <summary>
        /// Returns the min of three numbers.
        /// </summary>
        /// <param name="firstNumber">first number to test</param>
        /// <param name="secondNumber">second number to test</param>
        /// <param name="thirdNumber">third number to test</param>
        /// <returns>the min of three numbers</returns>
        public static int MinOf3(int firstNumber, int secondNumber, int thirdNumber)
        {
            return Math.Min(firstNumber, Math.Min(secondNumber, thirdNumber));
        }
    }
}