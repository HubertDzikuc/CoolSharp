using System;

namespace CoolSharp.Expressions.DelegateWrapper
{
    public class ConditionalDelegateUsage
    {
        private ConditionalDelegate<Action<string>> action;

        private bool condition = true;

        public ConditionalDelegateUsage()
        {
            action = new ConditionalDelegate<Action<string>>(ExampleMethod, () => condition); 
            
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