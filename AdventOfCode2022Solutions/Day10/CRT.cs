namespace AdventOfCode2022Tests.Day10
{
    public class CRT
    {
        private List<string> lines = new() { "" };
        private int numberOfPixelsPerLine;

        public CRT(int numberOfPixelsPerLine)
        {
            this.numberOfPixelsPerLine = numberOfPixelsPerLine;
        }


        public void DrawSprite(int pixelNumber, int spriteMidPos)
        {
            int normalizedPixelNumber = pixelNumber % numberOfPixelsPerLine;

            if (lines[lines.Count() - 1].Length >= numberOfPixelsPerLine)
            {
                lines.Add("");
            }

            if (Math.Abs(spriteMidPos - normalizedPixelNumber) <= 1)
            {
                lines[lines.Count() - 1] += "#";
            }

            else
            {
                lines[lines.Count() - 1] += ".";
            }
        }

        public string[] GetLines()
        {
            return lines.ToArray();
        }
    }
}
