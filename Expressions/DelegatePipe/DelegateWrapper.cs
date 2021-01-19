using System;

namespace CoolSharp.Expressions.DelegateWrapper
{
    public abstract class DelegateWrapper<T> where T : Delegate
    {
        public readonly T Invoke;
        private readonly T action;

        protected DelegateWrapper(T action)
        {
            this.action = action;

            Invoke = ExpressionsUtils.GenerateDelegateFromInvoker<T>(this, LocalInvoke);
        }

        protected abstract LocalInvoke(params object[] arguments);

        protected void InvokeAction(params object[] arguments)
        {
            action?.DynamicInvoke(arguments);
        }
    }
}