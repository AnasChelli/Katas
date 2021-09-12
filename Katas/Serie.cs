namespace Katas
{
    public class Serie
    {
        public int Value { get; }
        public int StartingIndex { get; }
        public int NumberOfRepeatation { get; set; }


        public Serie(int value, int startingIndex, int numberOfRepeatation)
        {
            Value = value;
            StartingIndex = startingIndex;
            NumberOfRepeatation = numberOfRepeatation;
        }

    }
}
