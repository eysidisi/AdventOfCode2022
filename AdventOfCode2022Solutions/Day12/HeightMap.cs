namespace AdventOfCode2022Tests.Day12
{
    public class HeightMap
    {
        public IReadOnlyList<Node> Nodes => new List<Node>(nodes);
        private readonly List<Node> nodes = new();

        public HeightMap(string mapStr)
        {
            string[] splittedString = mapStr.Split("\r\n");

            CreateAllNodes(splittedString);

            int numberOfRows = splittedString.Length;
            int numberOfCols = splittedString[0].Length;

            ConnectNodesInRow(numberOfCols);
            ConnectNodesInColumns(numberOfRows, numberOfCols);
        }

        public void MarkManyStartingPoints()
        {
            nodes.Where(n => n.Height == 0).ToList().ForEach(n => n.IsStartingNode = true);
        }

        private void ConnectNodesInColumns(int numberOfRows, int numberOfCols)
        {
            for (int nodeIndex = 0; nodeIndex < (numberOfRows - 1) * numberOfCols; nodeIndex++)
            {
                Node currentNode = nodes.ElementAt(nodeIndex);
                Node nextNode = nodes.ElementAt(nodeIndex + numberOfCols);
                currentNode.Connect(nextNode);
            }

        }

        private void ConnectNodesInRow(int numberOfCols)
        {
            int currentCol = 1;
            for (int nodeIndex = 0; nodeIndex < nodes.Count - 1; nodeIndex++)
            {
                if (currentCol == numberOfCols)
                {
                    currentCol = 1;
                    continue;
                }

                Node currentNode = nodes.ElementAt(nodeIndex);
                Node nextNode = nodes.ElementAt(nodeIndex + 1);
                currentNode.Connect(nextNode);
                currentCol++;
            }
        }

        private void CreateAllNodes(string[] splittedString)
        {
            foreach (string row in splittedString)
            {
                for (int i = 0; i < row.Length; i++)
                {
                    nodes.Add(new(row[i]));
                }
            }
        }


    }
}
