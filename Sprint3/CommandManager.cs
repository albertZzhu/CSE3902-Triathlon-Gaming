using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Sprint3.Commands
{
    class CommandManager
    {
        private Dictionary<String, ConstructorInfo> commandConstructors;

        public CommandManager()
        {
            commandConstructors = new Dictionary<string, ConstructorInfo>();
            String[] commandsStrings = File.ReadAllLines("Data/Commands.txt");
            foreach (String commandName in commandsStrings) {
                Type type = Type.GetType(commandName);
                //thinking ahead: i might have to change all the params in the command classes to IGameObject...
                commandConstructors.Add(commandName, type.GetConstructors()[0]);
            }
        }
    }
}
