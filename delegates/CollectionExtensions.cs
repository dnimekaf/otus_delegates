using System;
using System.Collections;

namespace delegates
{
    public static class CollectionExtensions
    {
        public static T GetMax<T>(this IEnumerable e, Func<T, float> getParameter) where T : class
        {
            T max = default(T);
            float? maxVal = null;
            
            var enumerator = e.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var res = getParameter((T)enumerator.Current);
                if (maxVal == null || res > maxVal)
                {
                    maxVal = res;
                    max = (T) enumerator.Current;
                }
            }
            return max;
        }
    }
}