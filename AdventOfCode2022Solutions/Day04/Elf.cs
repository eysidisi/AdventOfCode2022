namespace AdventOfCode2022Tests.Day04
{
    public class Elf
    {
        public int rangeMinPoint { get; private set; }
        public int rangeMaxPoint { get; private set; }
        public int TotalRange => rangeMaxPoint - rangeMinPoint;

        public Elf(string range)
        {
            string[] splittedRange = range.Split('-');

            rangeMinPoint = int.Parse(splittedRange[0]);
            rangeMaxPoint = int.Parse(splittedRange[1]);
        }
    }
}
