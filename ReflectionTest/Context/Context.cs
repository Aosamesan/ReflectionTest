using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ReflectionTest.Attributes;

namespace ReflectionTest.Context
{
    public class Context<T> where T : class
    {
        private static readonly Dictionary<string, Type> TypeDictionary = new Dictionary<string, Type>(); 
        public string TargetNamespace { get; }

        private Context(string targetNamespace)
        {
            TargetNamespace = targetNamespace;
        }

        public static Context<T> CreateContext(string targetNamespace)
        {
            var context = new Context<T>(targetNamespace);
            context.Init();
            return context;
        }

        private void Init()
        {
            var targetTypes = from Type targetType in Assembly.GetExecutingAssembly().GetTypes()
                where targetType.Namespace == TargetNamespace
                select targetType;
            
            foreach (var type in targetTypes)
            {
                var attributes = type.GetCustomAttributes<NameAttribute>();
                if (attributes.Any())
                {
                    TypeDictionary[attributes.First().Name] = type;
                }
            }
        }

        public T Get(string name)
        {
            return TypeDictionary[name]?.GetConstructor(Type.EmptyTypes)?.Invoke(new object[0]) as T ??
                throw new Exception("No such class");
        }
    }
}
