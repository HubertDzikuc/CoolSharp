using System.Dynamic;
using System;

namespace CoolSharp.Dynamic.PrivateAccess
{
    public static class PrivateExtensions
    {
        public static dynamic PrivateAccess<T>(this T @object) where T : class
        {
            return new PrivateAccessor<T>(@object) as dynamic;
        }
    }
}