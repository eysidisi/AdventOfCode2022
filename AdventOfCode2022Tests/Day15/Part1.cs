using Xunit;

namespace AdventOfCode2022Tests.Day15
{
    public class Part1
    {
        [Fact]
        public void ParseInput()
        {
            string input = "Sensor at x=2, y=18: closest beacon is at x=-2, y=15";
            Zone zone = new(input);

            Assert.True(zone.HasSensorAt(2, 18));
            Assert.True(zone.HasBeaconAt(-2, 15));

            Assert.False(zone.HasSensorAt(-2, 15));
            Assert.False(zone.HasBeaconAt(2, 18));
        }

        [Fact]
        public void ParseMultipleLineInput()
        {
            string input = "Sensor at x=2, y=18: closest beacon is at x=-2, y=15\r\n" +
                "Sensor at x=9, y=16: closest beacon is at x=10, y=16";

            Zone zone = new(input);

            Assert.True(zone.HasSensorAt(2, 18));
            Assert.True(zone.HasBeaconAt(-2, 15));
            Assert.True(zone.HasSensorAt(9, 16));
            Assert.True(zone.HasBeaconAt(10, 16));
        }

        [Fact]
        public void CalculateNumberOfBlockedCellsOnePair()
        {
            string input = "Sensor at x=2, y=5: closest beacon is at x=0, y=5";

            Zone zone = new(input);

            Assert.Equal(3, zone.HowManyCellsAreBlockedInRow(5));
        }

        [Fact]
        public void CalculateNumberOfBlockedCellsMultiplePairs()
        {
            string input = "Sensor at x=2, y=0: closest beacon is at x=3, y=-1\r\n" +
            "Sensor at x=7, y=2: closest beacon is at x=7, y=-1\r\n" +
                "Sensor at x=12, y=0: closest beacon is at x=16, y=0";

            Zone zone = new(input);

            Assert.Equal(13, zone.HowManyCellsAreBlockedInRow(0));
            Assert.Equal(14, zone.HowManyCellsAreBlockedInRow(1));
            Assert.Equal(11, zone.HowManyCellsAreBlockedInRow(2));
        }

        [Fact]
        public void LargeExample()
        {
            string filePath = @"TestFiles/Day15/LargeExample.txt";
            string input = File.ReadAllText(filePath);

            Zone zone = new(input);

            Assert.Equal(25, zone.HowManyCellsAreBlockedInRow(9));
            Assert.Equal(26, zone.HowManyCellsAreBlockedInRow(10));
            Assert.Equal(27, zone.HowManyCellsAreBlockedInRow(11));
        }

        [Fact]
        public void ExerciseSolution()
        {
            string filePath = @"TestFiles/Day15/ExerciseInput.txt";
            string input = File.ReadAllText(filePath);

            Zone zone = new(input);

            Assert.Equal(5335787, zone.HowManyCellsAreBlockedInRow(2000000));
        }
    }
}
