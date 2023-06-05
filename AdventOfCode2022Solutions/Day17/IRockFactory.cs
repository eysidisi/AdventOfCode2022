namespace AdventOfCode2022Tests.Day17
{
    public interface IRockFactory
    {
        Rock CreateRock(string type, double bottomLength);
        Rock CreateTheNextRockInOrder(double currentHeight);
    }
}