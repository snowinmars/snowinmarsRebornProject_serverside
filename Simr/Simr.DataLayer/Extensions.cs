using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simr.DataLayer
{
    internal static class Extensions
    {
        public static T[] Fetch<T>(this IQueryable<T> query)
        {
            return query.ToArray();
        }
    }
}
