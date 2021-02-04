using Internal;
using System;
using System.Collections.Generic;

namespace CoolSharp.Generics.SafeEvent
{
    public class SafeEventExample
    {
        SafeEvent<Action<string>> safeEvent = new SafeEvent<Action<string>>();

        public SafeEventExample()
        {
       	    safeEvent += TestMethod;
	        safeEvent += TestMethod2;
	        safeEvent.Invoke("Test");
        }

        private void TestMethod(string msg)
        {
        	Console.WriteLine(msg + " Should Run");
        	safeEvent -= TestMethod2;
        }

        private void TestMethod2(string msg)
        {
            Console.WriteLine(msg + " Shouldn't Run");
        }
    }
}