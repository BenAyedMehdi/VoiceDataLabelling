using System.Collections;
using System.Collections.Generic;

namespace SoundLabelling
{
    class CommandTypeEnumerator : IEnumerator<CommandType>
    {
        int currentIndex;
        CommandStorage storage;

        public CommandTypeEnumerator(CommandStorage storage)
        {
            this.storage = storage;
            Reset();
        }

        public CommandType Current => storage[currentIndex];

        object IEnumerator.Current => storage[currentIndex];

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            currentIndex++;
            return (currentIndex < storage.Count);
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }
}
