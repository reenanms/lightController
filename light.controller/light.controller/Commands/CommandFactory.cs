using System;
using System.Collections.Generic;
using System.Linq;

namespace Light.Controller
{
    public static class CommandFactory
    {
        private static Dictionary<string, Func<string[], ICommand>> commands =
            new Dictionary<string, Func<string[], ICommand>>(StringComparer.OrdinalIgnoreCase)
        {
            { "help",    p => new HelpCommand()     },
            { "turnOn",  p => new TurnOnCommand(p)  },
            { "turnOff", p => new TurnOffCommand(p) },
            { "get",     p => new GetCommand(p)     },
            { "getAll",  p => new GetAllCommand(p)  }
        };

        public static IEnumerable<string> getListOfCommands() => commands.Select(c => c.Key);

        public static ICommand Create(string[] args)
        {
            if (args.Length < 1)
                throw new InvalidCommandException();

            var command = args[0];
            if (!commands.TryGetValue(command.Trim(), out var cmd))
                throw new InvalidCommandException();
            
            var parameters = args.Skip(1).ToArray();
            return cmd(parameters);
        }
    }
}