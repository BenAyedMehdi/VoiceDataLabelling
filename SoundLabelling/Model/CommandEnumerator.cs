using System.Collections;
using System.Collections.Generic;

namespace SoundLabelling
{
    class CommandEnumerator : IEnumerator<Command>
    {
        int currentIndex;
        List<Command> commands;

        public CommandEnumerator(List<Command> commands)
        {
            this.commands = commands;
            Reset();
        }

        public Command Current => commands[currentIndex];

        object IEnumerator.Current => commands[currentIndex];

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            currentIndex++;
            return (currentIndex < commands.Count);
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }
}
