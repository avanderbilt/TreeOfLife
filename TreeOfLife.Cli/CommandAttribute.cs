using System;

namespace TreeOfLife.Cli
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    internal class CommandAttribute : Attribute
    {
        public string CommandName { get; set; }

        public CommandAttribute(string commandName)
        {
            CommandName = commandName;
        }
    }
}