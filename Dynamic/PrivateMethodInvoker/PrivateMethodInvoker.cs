using System.Dynamic;
using System;

namespace CoolSharp.Dynamic.PrivateMethodInvoker
{
    public class PrivateMethodInvoker<T> : DynamicObject where T : class
    {
        private readonly T @object = default;

        public PrivateMethodInvoker(T @object)
        {
            this.@object = @object;
        }

        public override bool TryInvokeMember(InvokeMemberBinder invoker, object[] args, out object result)
        {
            var method = @object.GetType().GetMethod(invoker.Name, BindingFlags.NonPublic | BindingFlags.Instance);
            try
            {
                result = method?.Invoke(@object, args);
                return true;
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    throw e.InnerException;
                }
                throw e;
            }
        }
    }
}