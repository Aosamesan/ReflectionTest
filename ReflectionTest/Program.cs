using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReflectionTest.Context;
using ReflectionTest.TestModels;

namespace ReflectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = Context<BaseModel>.CreateContext("ReflectionTest.TestModels");

            var apple = context.Get("apple");
            apple.DoSomething();
            var banana = context.Get("banana");
            banana.DoSomething();
            
            // error
            var cat = context.Get("cat");
            cat.DoSomething();
        }
    }
}
