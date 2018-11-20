using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simr.Common
{
    public static class Extensions
    {
        public static TResult[] SelectArray<T, TResult>(this IEnumerable<T> collection, Func<T, TResult> func)
        {
            return collection.Select(func).ToArray();
        }
    }
}
