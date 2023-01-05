namespace AdventOfCode2022Tests.Day12
{
    public class Node
    {
        public IReadOnlyList<Node> ConnectedNodes => new List<Node>(connectedNodes);
        private HashSet<Node> connectedNodes = new();

        public int Height { get; private set; }
        public bool IsStartingNode { get; internal set; } = false;
        public bool IsEndingNode { get; internal set; }

        public Node(char height)
        {
            if (height == 'S')
            {
                IsStartingNode = true;
                height = 'a';
            }

            else if (height == 'E')
            {
                IsEndingNode = true;
                height = 'z';
            }

            Height = height - 'a';
        }

        public void Connect(Node otherNode)
        {
            if (Math.Abs(Height - otherNode.Height) <= 1)
            {
                connectedNodes.Add(otherNode);
                otherNode.connectedNodes.Add(this);
            }

            else if (otherNode.Height > Height)
            {
                otherNode.connectedNodes.Add(this);
            }

            else
            {
                connectedNodes.Add(otherNode);
            }
        }

        public List<Node> GetConnectedNodes()
        {
            return new List<Node>(connectedNodes);
        }
    }

}
