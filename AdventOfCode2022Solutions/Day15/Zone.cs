using System.Text.RegularExpressions;

namespace AdventOfCode2022Tests.Day15
{
    public class Zone
    {
        Dictionary<(int x, int y), (int x, int y)> sensorsToBeacons = new();

        public Zone(string input)
        {
            string[] lines = input.Split("\r\n");

            foreach (string line in lines)
            {
                ParseSensorsAndBeacons(line);
            }
        }

        private void ParseSensorsAndBeacons(string input)
        {
            Regex reg = new("(-?\\d+)");
            MatchCollection matches = reg.Matches(input);

            int sensorX = int.Parse(matches[0].Value);
            int sensorY = int.Parse(matches[1].Value);

            int beaconX = int.Parse(matches[2].Value);
            int beaconY = int.Parse(matches[3].Value);
            sensorsToBeacons.Add((sensorX, sensorY), (beaconX, beaconY));
        }

        public bool HasBeaconAt(int x, int y)
        {
            return sensorsToBeacons.ContainsValue((x, y));
        }

        public bool HasSensorAt(int x, int y)
        {
            return sensorsToBeacons.ContainsKey((x, y));
        }

        public int HowManyCellsAreBlockedInRow(int blockedRowNumber)
        {
            HashSet<(int, int)> àllBlockedCells = new();

            foreach (KeyValuePair<(int x, int y), (int x, int y)> sensorToBeacon in sensorsToBeacons)
            {
                (int x, int y) sensor = sensorToBeacon.Key;
                (int x, int y) beacon = sensorToBeacon.Value;
                int sensorRadius = CalculateSensorRadius(sensor, beacon);

                bool sensorRangeReachesRow = sensorRadius >= sensor.y - blockedRowNumber;

                if (sensorRangeReachesRow)
                {
                    HashSet<(int, int)> blockedCells = FindBlockedCellsInRowBecauseOfThisPair(blockedRowNumber, sensorToBeacon);
                    àllBlockedCells.UnionWith(blockedCells);
                }
            }

            àllBlockedCells.RemoveWhere(b => sensorsToBeacons.ContainsKey(b) || sensorsToBeacons.ContainsValue(b));

            return àllBlockedCells.Count();
        }

        private static int CalculateSensorRadius((int x, int y) sensor, (int x, int y) beacon)
        {
            return Math.Abs(sensor.x - beacon.x) + Math.Abs(sensor.y - beacon.y);
        }

        private HashSet<(int, int)> FindBlockedCellsInRowBecauseOfThisPair(int rowIndex, KeyValuePair<(int x, int y), (int x, int y)> sensorToBeacon)
        {
            (int x, int y) sensor = sensorToBeacon.Key;
            (int x, int y) beacon = sensorToBeacon.Value;

            int sensorRadius = CalculateSensorRadius(sensor, beacon);

            int xDelta = sensorRadius - Math.Abs(sensor.y - rowIndex);
            HashSet<(int, int)> blockedCells = new();

            for (int x = sensor.x - xDelta; x <= sensor.x + xDelta; x++)
            {
                blockedCells.Add((x, rowIndex));
            }

            return blockedCells;
        }
    }
}
