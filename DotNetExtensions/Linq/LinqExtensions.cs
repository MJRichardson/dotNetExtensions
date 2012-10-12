using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetExtensions.Linq
{
    public static class LinqExtensions
    {

        public static TSource WithMax<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> func) where TResult : IComparable<TResult>
        {
            return source.Aggregate((a, b) => func(a).CompareTo(func(b)) < 0 ? b : a);
        }
    }
}