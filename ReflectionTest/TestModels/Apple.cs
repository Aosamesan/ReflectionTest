using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReflectionTest.Attributes;

namespace ReflectionTest.TestModels
{
    [Name("apple")]
    public class Apple : BaseModel
    {
        public override void DoSomething()
        {
            Console.WriteLine("I'm an apple.");
        }
    }
}
