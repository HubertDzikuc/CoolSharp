using System;

namespace CoolSharp.Expressions.LambdaWrapper
{
    public abstract class LambdaWrapper<T> where T : Delegate
    {
        public readonly T Invoke;
        private readonly T action;

        protected LambdaWrapper(T action)
        {
            this.action = action;

            Invoke = ExpressionsUtils.GenerateLambdaFromInvoker<T>(this, LocalInvoke);
        }

        protected abstract LocalInvoke(params object[] arguments);

        protected void InvokeAction(params object[] arguments)
        {
            action?.DynamicInvoke(arguments);
        }
    }
}