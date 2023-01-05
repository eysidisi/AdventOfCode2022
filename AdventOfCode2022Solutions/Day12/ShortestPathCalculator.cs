namespace AdventOfCode2022Tests.Day12
{
    public class ShortestPathCalculator
    {
        public HeightMap Map { get; }

        Dictionary<Node, int> nodesToDistances = new();
        Queue<Node> nodesToVisit = new();

        public ShortestPathCalculator(HeightMap map)
        {
            Map = map;
        }

        public int FindShortestPathWithOneStartingPoint()
        {
            Node? startingNode = Map.Nodes.FirstOrDefault(n => n.IsStartingNode);

            if (startingNode == null)
            {
                throw new Exception("No path exist!");
            }

            else
            {
                nodesToVisit.Enqueue(startingNode);
                nodesToDistances.Add(startingNode, 0);
                return VisitNode(ref startingNode);
            }
        }


        private int VisitNode(ref Node currentNode)
        {
            int distanceToTheCurrentNode = nodesToDistances[currentNode];

            if (currentNode.IsEndingNode)
            {
                return distanceToTheCurrentNode;
            }

            else
            {
                List<Node> newNodesToAdd = currentNode.ConnectedNodes.Where(n => nodesToDistances.ContainsKey(n) == false &&
                nodesToVisit.Contains(n) == false).ToList();

                newNodesToAdd.ForEach(n =>
                {
                    nodesToVisit.Enqueue(n);
                    nodesToDistances.Add(n, distanceToTheCurrentNode + 1);
                }
                );

                if (nodesToVisit.TryDequeue(out Node newNodeToVisit) == false)
                {
                    throw new Exception("No path exist!");
                }

                return VisitNode(ref newNodeToVisit);
            }
        }
    }
}
