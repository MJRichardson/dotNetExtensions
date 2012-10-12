using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;

namespace DotNetExtensions
{
    public static class StringFormatExtensions
    {
        /// <summary>
        /// Allows string-formatting using descriptive parameter names.
        /// The named parameters in the supplied format string will be replaced by the string representation
        /// of the corresponding named properties of the supplied source object.
        /// </summary>
        /// <example>"The {animal} goes {sound}".FormatWith(new {animal="Dog", sound="Woof"}</example>
        public static string FormatWith(this string format, object source)
        {
            return FormatWith(format, null, source);
        }


        /// <summary>
        /// Allows string-formatting using descriptive parameter names.
        /// The named parameters in the supplied format string will be replaced by the string representation
        /// of the corresponding named properties of the supplied source object.
        /// </summary>
        /// <example>"The {animal} goes {sound}".FormatWith(new {animal="Dog", sound="Woof"}</example>
        public static string FormatWith(this string format, IFormatProvider provider, object source)
        {
            if (format == null)
                throw new ArgumentNullException("format");

            var values = new List<object>();
            string rewrittenFormat = Regex.Replace(format,
                @"(?<start>\{)+(?<property>[\w\.\[\]]+)(?<format>:[^}]+)?(?<end>\})+",
                delegate(Match m)
                {
                    Group startGroup = m.Groups["start"];
                    Group propertyGroup = m.Groups["property"];
                    Group formatGroup = m.Groups["format"];
                    Group endGroup = m.Groups["end"];

                    values.Add((propertyGroup.Value == "0")
                      ? source
                      : Eval(source, propertyGroup.Value));

                    int openings = startGroup.Captures.Count;
                    int closings = endGroup.Captures.Count;

                    return openings > closings || openings % 2 == 0
                         ? m.Value
                         : new string('{', openings) + (values.Count - 1) + formatGroup.Value
                           + new string('}', closings);
                },
                RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

            return string.Format(provider, rewrittenFormat, values.ToArray());
        }

        private static object Eval(object source, string expression)
        {
            try
            {
                return DataBinder.Eval(source, expression);
            }
            catch (HttpException e)
            {
                throw new FormatException(null, e);
            }
        }
    }
}