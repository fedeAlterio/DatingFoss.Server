using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Infrastructure.Extensions;
public static class DictionaryExtensions
{
    public static TResult GetValueOrCreate<TKey, TResult>(this IDictionary<TKey, TResult> @this, TKey key) 
        where TResult : new() where TKey : notnull
    {
        if (@this.TryGetValue(key, out var result))
            return result;

        result = new();
        @this.Add(key, result);
        return result;
    }
}
