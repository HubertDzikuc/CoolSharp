using System;

namespace CoolSharp.Dynamic.PrivateAccess
{
    public class PrivateAccessorExample
    {
        public class TestClass
        {
            private int testField = 5;
            private int TestProperty {get; set} = 5;

            private void ExampleMethod()
            {
                Console.WriteLine("Run");
                Console.WriteLine(testField);
                Console.WriteLine(TestProperty);
            }
        }

        public PrivateMethodInvokerUsage()
        {
            var testClass = new TestClass();

            testClass.PrivateAccess().ExampleMethod();

            testClass.PrivateAccess().testField =7;

            testClass.PrivateAccess().TestProperty = 2;

            testClass.PrivateAccess().ExampleMethod();
        }
    }
}