using System;
using System.Collections.Generic;
using System.Linq;

namespace Light.Controller
{
    public static class CommandFactory
    {
        private static Dictionary<String, Func<String[], ICommand>> commands =
            new Dictionary<string, Func<string[], ICommand>>(StringComparer.OrdinalIgnoreCase)
        {
            { "help",    p => new HelpCommand()     },
            { "turnOn",  p => new TurnOnCommand(p)  },
            { "turnOff", p => new TurnOffCommand(p) }
        };

        public static IEnumerable<String> getListOfCommands() => commands.Select(c => c.Key);

        public static ICommand Create(String rawCommand)
        {
            var commandSplited = rawCommand.Split(" ");
            if (commandSplited.Length < 0)
                throw new InvalidCommandException();

            var command = commandSplited[0];
            if (!commands.TryGetValue(command.Trim(), out var cmd))
                throw new InvalidCommandException();
            
            var parameters = commandSplited.Skip(1).ToArray();
            return cmd(parameters);
        }
    }
}