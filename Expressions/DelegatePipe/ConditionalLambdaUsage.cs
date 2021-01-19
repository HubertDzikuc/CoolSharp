using System;

namespace CoolSharp.Expressions.LambdaWrapper
{
    public class ConditionalLambdaUsage
    {
        private ConditionalLambda<Action<string>> action;

        private bool condition = true;

        public ConditionalLambdaUsage()
        {
            action = new ConditionalLambda<Action<string>>(ExampleMethod, () => condition);

            action.Invoke("This Should Run");

            condition = false;

            action.Invoke("This Shouldn't Run");
        }

        private void ExampleMethod(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}