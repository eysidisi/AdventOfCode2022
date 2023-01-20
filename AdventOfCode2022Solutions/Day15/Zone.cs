using System.Text.RegularExpressions;

namespace AdventOfCode2022Tests.Day15
{
    public class Zone
    {
        Dictionary<(int x, int y), (int x, int y)> sensorsToBeaconCoordinates = new();

        private readonly bool limitOnCoordinates;
        private readonly (int min, int max) limitValues;

        public Zone(string input, bool limitOnCoordinates = false, (int min, int max) limitValues = default)
        {
            string[] lines = input.Split("\r\n");

            foreach (string line in lines)
            {
                ParseSensorsAndBeacons(line);
            }
            this.limitOnCoordinates = limitOnCoordinates;
            this.limitValues = limitValues;
        }

        private void ParseSensorsAndBeacons(string input)
        {
            Regex reg = new("(-?\\d+)");
            MatchCollection matches = reg.Matches(input);

            int sensorX = int.Parse(matches[0].Value);
            int sensorY = int.Parse(matches[1].Value);

            int beaconX = int.Parse(matches[2].Value);
            int beaconY = int.Parse(matches[3].Value);
            sensorsToBeaconCoordinates.Add((sensorX, sensorY), (beaconX, beaconY));
        }

        public bool HasBeaconAt(int x, int y)
        {
            return sensorsToBeaconCoordinates.ContainsValue((x, y));
        }

        public bool HasSensorAt(int x, int y)
        {
            return sensorsToBeaconCoordinates.ContainsKey((x, y));
        }

        public int HowManyCellsAreBlockedInRow(int rowNumber)
        {
            List<(int, int)> blockedRanges = FindBlockedRangesInRowBySensors(rowNumber);

            int numberOfBlockedCells = 0;

            foreach ((int, int) blockedRange in blockedRanges)
            {
                for (int currentXCoord = blockedRange.Item1;
                    currentXCoord <= blockedRange.Item2;
                    currentXCoord++)
                {
                    if ((HasBeaconAt(currentXCoord, rowNumber) ||
                        HasSensorAt(currentXCoord, rowNumber)) == false)
                    {
                        numberOfBlockedCells++;
                    }

                }
            }
            return numberOfBlockedCells;
        }

        public long CalculateUniqueuTuningFrequency()
        {
            for (int rowNum = limitValues.min; rowNum < limitValues.max; rowNum++)
            {
                List<(int, int)> blockedRanges = FindBlockedRangesInRowBySensors(rowNum);

                if (blockedRanges.Count == 2)
                {
                    blockedRanges = blockedRanges.OrderBy(r => r.Item2).ToList();
                    (int, int) smallerRange = blockedRanges[0];
                    (int, int) largerRange = blockedRanges[1];
                    return (smallerRange.Item2 + 1) * (long)4000000 + rowNum;
                }
            }

            throw new Exception("Can't find tunning freq!");
        }

        private List<(int, int)> FindBlockedRangesInRowBySensors(int rowNumber)
        {
            List<(int, int)> blockedRanges = new();

            foreach (KeyValuePair<(int x, int y), (int x, int y)> sensorToBeaconCoordinate in sensorsToBeaconCoordinates)
            {
                (int x, int y) sensorCoord = sensorToBeaconCoordinate.Key;
                (int x, int y) beaconCoord = sensorToBeaconCoordinate.Value;
                int sensorRadius = CalculateSensorRadius(sensorCoord, beaconCoord);

                bool sensorRangeReachesRow = sensorRadius >= Math.Abs(sensorCoord.y - rowNumber);

                if (sensorRangeReachesRow)
                {
                    (int, int) blockedRangesByThisSensor = FindBlockedRangesInRowBySensor(rowNumber, sensorToBeaconCoordinate);
                    blockedRanges.Add(blockedRangesByThisSensor);
                }
            }

            List<(int, int)> mergedBlockedRanges = MergeRanges(blockedRanges);

            return mergedBlockedRanges;
        }

        private List<(int, int)> MergeRanges(List<(int, int)> blockedRanges)
        {
            List<(int, int)> mergedRanges = new();

            foreach ((int, int) blockedRange in blockedRanges)
            {
                List<(int, int)> overlappingRangesWithThisRange = mergedRanges.FindAll(u => DoOverlap(u, blockedRange));

                if (overlappingRangesWithThisRange.Count != 0)
                {
                    overlappingRangesWithThisRange.Add(blockedRange);

                    (int, int) unitedRange = Unite(overlappingRangesWithThisRange);

                    mergedRanges.RemoveAll(n => overlappingRangesWithThisRange.Contains(n));

                    mergedRanges.Add(unitedRange);
                }
                else
                {
                    mergedRanges.Add(blockedRange);
                }
            }

            return mergedRanges;
        }

        private (int, int) Unite(List<(int, int)> overlappingRanges)
        {
            int startPoint = overlappingRanges.Min(r => r.Item1);
            int endPoint = overlappingRanges.Max(r => r.Item2);

            if (limitOnCoordinates)
            {
                startPoint = RoundTheValue(startPoint);
                endPoint = RoundTheValue(endPoint);
            }


            return (startPoint, endPoint);
        }

        private int RoundTheValue(int val)
        {
            if (val < limitValues.min)
            {
                val = 0;
            }

            else if (val > limitValues.max)
            {
                val = limitValues.max;
            }

            return val;
        }

        /// <summary>
        /// It's assumed that item2 >= item1 for both ranges.
        /// </summary>
        /// <param name="range1"></param>
        /// <param name="range2"></param>
        /// <returns></returns>
        private bool DoOverlap((int, int) range1, (int, int) range2)
        {
            (int, int) largerRange = (range1.Item2 > range2.Item2) ? range1 : range2;
            (int, int) smallerRange = (range1.Item2 > range2.Item2) ? range2 : range1;

            return (smallerRange.Item2 + 1) == largerRange.Item1 ||
                    (smallerRange.Item2 >= largerRange.Item1);
        }

        private (int, int) FindBlockedRangesInRowBySensor(int blockedRowNumber, KeyValuePair<(int x, int y), (int x, int y)> sensorCoordToBeaconCoord)
        {
            (int x, int y) sensorCoord = sensorCoordToBeaconCoord.Key;
            (int x, int y) beaconCoord = sensorCoordToBeaconCoord.Value;

            int sensorRadius = CalculateSensorRadius(sensorCoord, beaconCoord);

            int sensorBlockingRangeInThisRow = Math.Abs(sensorRadius - Math.Abs(sensorCoord.y - blockedRowNumber));

            return (sensorCoord.x - sensorBlockingRangeInThisRow, sensorCoord.x + sensorBlockingRangeInThisRow);
        }

        private int CalculateSensorRadius((int x, int y) sensor, (int x, int y) beacon)
        {
            return Math.Abs(sensor.x - beacon.x) + Math.Abs(sensor.y - beacon.y);
        }


    }
}
