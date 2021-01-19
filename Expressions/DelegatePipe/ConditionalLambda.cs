using System;

namespace CoolSharp.Expressions.LambdaWrapper
{
    public class ConditionalLambda<T> : LambdaWrapper<T> where T : Delegate
    {
        private readonly Func<bool> condition;

        public ConditionalLambda(T action, Func<bool> condition) : base(action)
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