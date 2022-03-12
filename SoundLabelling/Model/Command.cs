namespace SoundLabelling
{
    class Command
    {
        public string name { get; private set; }

        public Command(string name)
        {
            this.name = name;
        }
    }
}
