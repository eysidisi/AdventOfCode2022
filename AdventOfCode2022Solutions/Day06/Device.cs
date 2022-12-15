namespace AdventOfCode2022Tests.Day06
{
    public class Device
    {
        private string input;

        public Device(string input)
        {
            this.input = input;
        }

        public int FindStartOfMessageMarker()
        {
            for (int i = 0; i < input.Length - 13; i++)
            {
                if (FirstNCharsAreDifferent(i, 14))
                    return i + 14;
            }

            throw new Exception("Invalid input!");

        }

        public int FindStartOfPacketMarker()
        {
            for (int i = 0; i < input.Length - 3; i++)
            {
                if (FirstNCharsAreDifferent(i, 4))
                    return i + 4;
            }

            throw new Exception("Invalid input!");
        }

        private bool FirstNCharsAreDifferent(int firstCharIndex, int n)
        {
            for (int i = firstCharIndex; i < firstCharIndex + n; i++)
            {
                for (int j = i + 1; j < firstCharIndex + n; j++)
                {
                    if (input[i] == input[j])
                        return false;
                }
            }
            return true;
        }
    }
}
