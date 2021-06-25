using System;
using System.Collections.Generic;
using System.Linq;

namespace DealerTrack.ExtensionMethod
{
    /// <summary>
    /// Public class for Extension methods
    /// </summary>
    public static class Extensions
    {

        /// <summary>
        /// It sorts the given source based on given sortExpression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="sortExpression"></param>
        /// <returns></returns>
        public static List<T> SortSource<T>(this List<T> source, string sortExpression)
        {
            if (source == null || sortExpression == null)
            {
                throw new ArgumentNullException();
            }


            var list = sortExpression.Split(',');

            string finalSortExpression = string.Empty;

            foreach (string column in list)
            {
                if (column.StartsWith("-"))
                {
                    finalSortExpression = finalSortExpression + column.Remove(0, 1) + " desc,";
                }
                else
                {
                    finalSortExpression = finalSortExpression + column + ",";
                }
            }

            if (string.IsNullOrEmpty(finalSortExpression) == false)
            {
                source = source.OrderBy(x => finalSortExpression.Remove(finalSortExpression.Count() - 1)).ToList<T>();
            }

            return source;
        }
    }
}
