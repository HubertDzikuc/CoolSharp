using System;

namespace CoolSharp.Dynamic.PrivateMethodInvoker
{
    public class PrivateMethodInvokerUsage
    {
        public class TestClass
        {
            private void ExampleMethod()
            {
                Console.WriteLine("Run");
            }
        }

        public PrivateMethodInvokerUsage()
        {
            new TestClass().InvokeMethod().ExampleMethod();
        }
    }
}