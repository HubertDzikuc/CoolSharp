using System;

namespace CoolSharp.Expressions.DelegateWrapper
{
    public class ConditionalDelegate<T> : DelegateWrapper<T> where T : Delegate
    {
        private readonly Func<bool> condition;

        public ConditionalDelegate(T action, Func<bool> condition) : base(action)
        {
            this.condition = condition;
        }

        protected override LocalInvoke(params object[] arguments)
        {
            if (condition())
            {
                InvokeAction(arguments);
            }
        }
    }
}