using System.Dynamic;
using System;

namespace CoolSharp.Dynamic.PrivateMethodInvoker
{
    public static class InvokeExtensions
    {
        public static dynamic InvokeMethod<T>(this T @object) where T : class
        {
            return new PrivateMethodInvoker(@object) as dynamic;
        }
    }
}