using System.Collections;
using System.Collections.Generic;

namespace SoundLabelling
{
    class CommandType : IEnumerable<Command>
    {
        public string Name { get;private set; }
        private List<Command> commands;

        public int Count
        {
            get { return commands.Count; }
        }

        public Command this[int index]
        {
            get
            {
                return commands[index];
            }

        }

        public CommandType(string name)
        {
            this.Name = name;
            this.commands = new List<Command>();
        }

        public void addCommand(Command newCommand)
        {
            commands.Add(newCommand);
        }

        public IEnumerator<Command> GetEnumerator()
        {
            return new CommandEnumerator(commands);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
