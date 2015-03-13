using System;
using System.Collections.Generic;
using System.Text;

namespace Development.Utilities.Statics
{
    /// <summary>
    /// Conatines so math operation that could be used in development
    /// </summary>
    public static class Math
    {
        /// <summary>
        /// Converts the relationship between to values as percentage
        /// </summary>
        /// <param name="total">the max number</param>
        /// <param name="current">the small number</param>
        /// <returns>the percentage value that represent the max and small number</returns>
        public static double ToPercentage(long total, long current)
        {
            return current / (total / 100);
        }

        /// <summary>
        /// Compute the result of mutual multiplication if the second Denominator is unkown
        /// </summary>
        /// <param name="firstNumerator">the value of the first numerator</param>
        /// <param name="firstDenominator">the value of the first denominator</param>
        /// <param name="secondNumerator">the value of the second numerator</param>
        /// <returns>the result of the multiplication</returns>
        /// <example> compute 300/500 = 500/X where X is the second Denominator</example>
        public static double FindDenominatorByMutualMultiplication(double firstNumerator, double firstDenominator, double secondNumerator)
        {
            return (firstDenominator * secondNumerator) / firstNumerator ;
        }

        /// <summary>
        /// Compute the result of mutual multiplication if the second Numerator is unkown
        /// </summary>
        /// <param name="firstNumerator">the value of the first numerator</param>
        /// <param name="firstDenominator">the value of the first denominator</param>
        /// <param name="secondDenominator">the value of the second denominator</param>
        /// <returns>the result of the multiplication</returns>
        /// <example> compute 300/500 = X/600 where X is the second Numerator</example>
        public static double FindNumeratorByMutualMultiplication(double firstNumerator, double firstDenominator, double secondDenominator)
        {
            return (secondDenominator * firstNumerator) / firstDenominator;
        }

        /// <summary>
        /// Format a double indentifier
        /// </summary>
        /// <param name="number">the double identifier</param>
        /// <param name="presition">number of digits after the dot</param>
        /// <returns>System.Double containes the formated value</returns>
        public static double FormatDouble(double number, int presition)
        {
            string num = number.ToString();//convert to string
            if (num.Substring(num.IndexOf('.') + 1).Length > presition)//if number of digits after the dot more the presition
            {
                double dnum;
                double.TryParse(num.Substring(0, num.IndexOf('.') + presition + 1), out dnum);//only take the wanted value
                return dnum;
            }
            else//if number of digits after the dot less the presition return the number
                return number;
        }

        
      
        /// <summary>
        /// Computes the median from a set of intergers
        /// </summary>
        /// <param name="set">the set of integers</param>
        /// <returns>the median value</returns>
        public static double Median(int[] set)
        {
            double median = 0.0;
            set = Statics.Collections.SortAscending<int>(set);
            if (set.Length % 2 == 0)
            {
                median = (double)(set[set.Length / 2] + set[(set.Length / 2) - 1]) / 2.0;
            }
            else
            {
                median = (double)(set[(set.Length / 2)]);
            }
            return median;
        }

         
        /// <summary>
        /// Computes the median from a set of floats
        /// </summary>
        /// <param name="set">the set of integers</param>
        /// <returns>the median value</returns>
        public static double Median(double[] set)
        {
            double median = 0.0;
            set = Statics.Collections.SortAscending<double>(set);
            if (set.Length % 2 == 0)
            {
                median = (double)(set[set.Length / 2] + set[(set.Length / 2) - 1]) / 2.0;
            }
            else
            {
                median = (double)(set[(set.Length / 2)]);
            }
            return median;
        }

        /// <summary>
        /// Computes the median from a set of floats
        /// </summary>
        /// <param name="set">the set of floats</param>
        /// <returns>the median value</returns>
        public static double Median(float [] set)
        {
            double median = 0.0;
            set = Statics.Collections.SortAscending<float>(set);
            if (set.Length % 2 == 0)
            {
                median = (double)(set[set.Length / 2] + set[(set.Length / 2) - 1]) / 2.0;
            }
            else
            {
                median = (double)(set[(set.Length / 2)]);
            }
            return median;
        }

    }
}
