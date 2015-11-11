using System.Collections.Generic;
using System.Reflection;

namespace TreeOfLife.Cli
{
    public class Command
    {
        public Command(IEnumerable<MethodInfo> methods)
        {
            Methods = new List<MethodInfo>();
            Methods.AddRange(methods);
        }

        public string[] Options { get; set; }

        public List<MethodInfo> Methods { get; set; }
    }
}