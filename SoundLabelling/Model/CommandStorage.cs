using System;
using System.Collections;
using System.Collections.Generic;

namespace SoundLabelling
{
    class CommandStorage:IEnumerable<CommandType>
    {

        private List<CommandType> commandTypes;

        public int Count
        {
            get { return commandTypes.Count; }
        }
        
        public CommandType this[int index]
        {
            get
            {
                return commandTypes[index];
            }
            
        }

        public CommandStorage()
        {
            commandTypes = new List<CommandType>();
        }

        public void addCommand(string type, string name)
        {
            CommandType theType = findCommandType(type);
            if (theType == null)
            {
                theType = new CommandType(type);
                commandTypes.Add(theType);
            }

            Command found = findCommand(name,theType);
            if (found==null)
            {
                theType.addCommand(new Command(name));
            }

        }

        public CommandType GetByName(string name)
        {
            foreach (CommandType type in commandTypes)
            {
                if (type.Name==name)
                {
                    return type;
                }
            }
            return null;
        }

        private Command findCommand(string name, CommandType commandType)
        {
            
            foreach (Command command in commandType)
            {
                if (command!= null)
                {
                    if (command.name == name)
                    {
                        return command;
                    }
                }
            }
            return null;
        }

        public void addCommandType(string name)
        {
            CommandType found = findCommandType(name);
            if (found == null)
            {
                commandTypes.Add(new CommandType(name));
            }
        }

        private CommandType findCommandType(string name)
        {
            foreach (CommandType commandType in commandTypes)
            {
                if (commandType.Name==name)
                {
                    return commandType;
                }
            }
            return null;
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<CommandType> IEnumerable<CommandType>.GetEnumerator()
        {
            return new CommandTypeEnumerator(this);
        }
    }
}
