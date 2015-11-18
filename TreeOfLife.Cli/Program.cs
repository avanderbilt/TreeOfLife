using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Ninject;
using TreeOfLife.ExtensionMethods;
using TreeOfLife.Logic;
using TreeOfLife.Model.Interfaces;

namespace TreeOfLife.Cli
{
    internal class Program
    {
        private static readonly ITree Tree;
        private static readonly List<MethodInfo> CommandMethods;

        static Program()
        {
            RecreateDatabase();

            //return;

            IKernel kernel = new StandardKernel(new LogicModule(), new DataModule());

            var elementRepository = kernel.Get<IElementRepository>();
            var elements = elementRepository.ReadAll().ToList();

            return;

            Tree = kernel.Get<ITree>();

            CommandMethods =
                typeof (Program).GetMethods(BindingFlags.Static | BindingFlags.NonPublic)
                    .Where(m => m.GetCustomAttributes(typeof (CommandAttribute), false).Length > 0)
                    .ToList();

            Console.OutputEncoding = Encoding.UTF8;
        }

        private static void Main(string[] args)
        {
            var commands = ParseArguments(args.ToList());

            if (commands.Count == 0)
            {
                PrintHelpMessage();
                return;
            }

            foreach (var command in commands)
                command.Methods.ForEach(m => m.Invoke(null, new object[] {command.Options}));
        }

        private static List<Command> ParseArguments(IEnumerable<string> arguments)
        {
            var commands = new List<Command>();
            var parsingErrors = new List<string>();

            Command command = null;

            var options = new List<string>();

            foreach (var argument in arguments)
            {
                if (argument.ArgumentIsOption())
                {
                    if (command == null)
                    {
                        parsingErrors.Add(
                            $"An argument, \"{argument}\", was found with no command to associate it with.");
                        continue;
                    }

                    options.Add(argument.OptionWithoutDelimiter());
                }
                else
                {
                    if (command != null)
                    {
                        command.Options = options.ToArray();
                        options.Clear();
                        commands.Add(command);
                    }

                    var matchingCommandMethods = (from m in CommandMethods
                        where (from a in m.GetCustomAttributes<CommandAttribute>()
                            where string.Equals(a.CommandName, argument, StringComparison.CurrentCultureIgnoreCase)
                            select a).Any()
                        select m).ToList();

                    if (matchingCommandMethods.Count == 0)
                    {
                        parsingErrors.Add($"The command \"{argument}\" is unrecognized.");
                        continue;
                    }

                    command = new Command(matchingCommandMethods);
                }
            }

            if (parsingErrors.Count != 0)
            {
                parsingErrors.ForEach(e => Console.Out.WriteLine(e));
                Console.Out.Write(Environment.NewLine);
            }

            if (command == null)
                return commands;

            command.Options = options.ToArray();
            commands.Add(command);

            return commands;
        }

        private static void PrintHelpMessage()
        {
            Console.Out.WriteLine($"The Tree of Life{Environment.NewLine}");
            Console.Out.WriteLine($"Things you can do:{Environment.NewLine}");
            Console.Out.WriteLine("* \"planets\"");
            Console.Out.WriteLine("* \"zodiac\" or \"signs\"");
            Console.Out.WriteLine("* \"sephiroth\"");
            Console.Out.WriteLine("* \"paths\"");
        }

        [Command("planets")]
        private static void PrintPlanets(params string[] options)
        {
            Console.WriteLine($"The planets:{Environment.NewLine}");

            var showPath = false;

            if (options != null)
            {
                foreach (var option in options)
                {
                    showPath = (option.ToLower() == "path" || option.ToLower() == "paths");

                    if (showPath)
                        break;
                }
            }

            if (showPath)
            {
                Tree.Planets.ToList().ForEach(p => Console.Out.WriteLine(p.GetPlanetWithPath()));
            }
            else
            {
                Tree.Planets.ToList().ForEach(p => Console.Out.WriteLine(p));
            }

            Console.Write(Environment.NewLine);
        }

        [Command("zodiac")]
        [Command("signs")]
        private static void PrintZodiacSigns(params string[] options)
        {
            Console.WriteLine($"The signs of the zodiac:{Environment.NewLine}");

            var showPath = false;

            if (options != null)
            {
                foreach (var option in options)
                {
                    showPath = (option.ToLower() == "path" || option.ToLower() == "paths");

                    if (showPath)
                        break;
                }
            }

            if (showPath)
            {
                Tree.ZodiacSigns.ToList().ForEach(s => Console.Out.WriteLine(s.GetZodiacSignWithPath()));
            }
            else
            {
                Tree.ZodiacSigns.ToList().ForEach(s => Console.Out.WriteLine(s));
            }

            Console.Write(Environment.NewLine);
        }

        [Command("sephiroth")]
        private static void PrintSephiroth(params string[] options)
        {
            Console.WriteLine($"Sephiroth:{Environment.NewLine}");

            Tree.Sephiroth.ToList().ForEach(s => Console.Out.WriteLine(s));

            Console.Write(Environment.NewLine);
        }

        [Command("paths")]
        private static void PrintPaths(params string[] options)
        {
            Console.WriteLine($"Paths:{Environment.NewLine}");

            Tree.Paths.ToList().ForEach(p => Console.Out.WriteLine(p.GetPathWithHebrewLetter()));

            Console.Write(Environment.NewLine);
        }

        private static void RecreateDatabase()
        {
            IKernel kernel = new StandardKernel(new LogicModule(), new DataModule());

            var db = kernel.Get<ITreeOfLifeDatabase>();
            db.HardDeletDatabase();

            var elementRepository = kernel.Get<IElementRepository>();
            elementRepository.StoreData();

            var hebrewLetterRepository = kernel.Get<IHebrewLetterRepository>();
            hebrewLetterRepository.StoreData();

            var pathRepository = kernel.Get<IPathRepository>();
            pathRepository.StoreData();

            var sephiraReposirory = kernel.Get<ISephiraRepository>();
            sephiraReposirory.StoreData();

            var zodiacSignRepository = kernel.Get<IZodiacSignRepository>();
            zodiacSignRepository.StoreData();
        }
    }
}