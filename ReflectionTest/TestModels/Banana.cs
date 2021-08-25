using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReflectionTest.Attributes;

namespace ReflectionTest.TestModels
{
    [Name("banana")]
    public class Banana : BaseModel
    {
        public override void DoSomething()
        {
            Console.WriteLine("I'm a banana");
        }
    }
}
