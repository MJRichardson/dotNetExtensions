using System.Collections.Generic;

namespace DotNetExtensions.Linq
{
    public static class IntExtensions
    {
        /// <summary>
        /// Treats an integer as the inclusive limit of the sequence of integers, optionally including zero. 
        /// </summary>
        /// <param name="zeroBased">Should zero be included in the sequence?</param>
        /// <returns>The sequence of natural numbers, starting at 0 if <paramref name="zeroBased"/>, else starting at 1. </returns>
        public static IEnumerable<int> N(this int n, bool zeroBased)
        {
           for (int i = zeroBased ? 0 : 1; i<=n; i++)
           {
               yield return i;
           }
        }
    }
}