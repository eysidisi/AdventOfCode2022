using FluentAssertions;
using Xunit;

namespace AdventOfCode2022Tests.Day12
{
    public class Part1
    {
        [Fact]
        public void CreateNodeUsingChar()
        {
            char height = 'a';
            Node node = new(height);
            Assert.Equal(0, node.Height);
        }

        [Fact]
        public void ConnectNodesLowerToHigherWithOneDifference()
        {
            char node1Height = 'a';
            Node node1 = new(node1Height);
            char node2Height = 'b';
            Node node2 = new(node2Height);

            node1.Connect(node2);
            AssertNode1HasNodes(node1, node2);
            AssertNode1HasNodes(node2, node1);
        }

        [Fact]
        public void DontConnectTheSameNodesMoreThanOnce()
        {
            char node1Height = 'a';
            Node node1 = new(node1Height);
            char node2Height = 'b';
            Node node2 = new(node2Height);

            node1.Connect(node2);
            node1.Connect(node2);
            node2.Connect(node1);
            node2.Connect(node1);

            Assert.Single(node1.GetConnectedNodes());
            Assert.Single(node2.GetConnectedNodes());
        }

        [Fact]
        public void ConnectNodesLowerToHigherWithTwoDifference()
        {
            char node1Height = 'a';
            Node node1 = new(node1Height);
            char node2Height = 'c';
            Node node2 = new(node2Height);

            node1.Connect(node2);

            AssertNode1HasNodes(node1, new List<Node>());
            AssertNode1HasNodes(node2, node1);
        }

        [Fact]
        public void ConnectNodesHigherToLowerWithOneDifference()
        {
            char node2Height = 'b';
            Node node2 = new(node2Height);
            char node1Height = 'a';
            Node node1 = new(node1Height);

            node2.Connect(node1);

            AssertNode1HasNodes(node1, node2);
            AssertNode1HasNodes(node2, node1);
        }

        [Fact]
        public void ConnectNodesHigherToLowerWithTwoDifference()
        {
            char node2Height = 'c';
            Node node2 = new(node2Height);
            char node1Height = 'a';
            Node node1 = new(node1Height);

            node2.Connect(node1);
            AssertNode1HasNodes(node1, new List<Node>());
            AssertNode1HasNodes(node2, node1);
        }

        [Fact]
        public void ThreeNodesConnect()
        {
            // a-b-c
            Node node1 = new('a');
            Node node2 = new('b');
            Node node3 = new('c');

            node1.Connect(node2);
            node2.Connect(node3);

            AssertNode1HasNodes(node1, node2);
            AssertNode1HasNodes(node2, new List<Node>() { node1, node3 });
        }

        [Fact]
        public void HeightMapCreatesNodesFromOneLineString()
        {
            string mapStr = "abc";
            HeightMap map = new(mapStr);
            Node nodeA = map.Nodes.First(n => n.Height == 0);
            Node nodeB = map.Nodes.First(n => n.Height == 1);
            Node nodeC = map.Nodes.First(n => n.Height == 2);

            Assert.NotNull(nodeA);
            Assert.NotNull(nodeB);
            Assert.NotNull(nodeC);

            Assert.True(nodeA.ConnectedNodes.Count() == 1);
            Assert.True(nodeB.ConnectedNodes.Count() == 2);
            Assert.True(nodeC.ConnectedNodes.Count() == 1);
        }

        [Fact]
        public void HeightMapCreatesNodesFromTwoLineString()
        {
            string mapStr = "ab\r\nce";
            HeightMap map = new(mapStr);

            Node nodeA = map.Nodes.First(n => n.Height == 0);
            Node nodeB = map.Nodes.First(n => n.Height == 1);
            Node nodeC = map.Nodes.First(n => n.Height == 2);
            Node nodeE = map.Nodes.First(n => n.Height == 4);

            Assert.NotNull(nodeA);
            Assert.NotNull(nodeB);
            Assert.NotNull(nodeC);
            Assert.NotNull(nodeE);

            Assert.True(nodeA.ConnectedNodes.Count() == 1);
            Assert.True(nodeB.ConnectedNodes.Count() == 1);
            Assert.True(nodeC.ConnectedNodes.Count() == 1);
            Assert.True(nodeE.ConnectedNodes.Count() == 2);

        }

        //abd
        //cfe
        [Fact]
        public void HeightMapCreatesNodesFromTwoByThreeLineString()
        {
            string mapStr = "abd\r\ncfe";
            HeightMap map = new(mapStr);

            Node nodeA = map.Nodes.First(n => n.Height == 0);
            Node nodeB = map.Nodes.First(n => n.Height == 1);
            Node nodeC = map.Nodes.First(n => n.Height == 2);
            Node nodeD = map.Nodes.First(n => n.Height == 3);
            Node nodeE = map.Nodes.First(n => n.Height == 4);
            Node nodeF = map.Nodes.First(n => n.Height == 5);

            Assert.NotNull(nodeA);
            Assert.NotNull(nodeB);
            Assert.NotNull(nodeC);
            Assert.NotNull(nodeD);
            Assert.NotNull(nodeE);
            Assert.NotNull(nodeF);

            Assert.True(nodeA.ConnectedNodes.Count() == 1);
            Assert.True(nodeB.ConnectedNodes.Count() == 1);
            Assert.True(nodeC.ConnectedNodes.Count() == 1);
            Assert.True(nodeD.ConnectedNodes.Count() == 2);
            Assert.True(nodeE.ConnectedNodes.Count() == 2);
            Assert.True(nodeF.ConnectedNodes.Count() == 3);

        }

        //ab
        //cf
        //de
        [Fact]
        public void HeightMapCreatesNodesFromThreeByTwoLineString()
        {
            string mapStr = "ab\r\ncf\r\nde";
            HeightMap map = new(mapStr);

            Node nodeA = map.Nodes.First(n => n.Height == 0);
            Node nodeB = map.Nodes.First(n => n.Height == 1);
            Node nodeC = map.Nodes.First(n => n.Height == 2);
            Node nodeD = map.Nodes.First(n => n.Height == 3);
            Node nodeE = map.Nodes.First(n => n.Height == 4);
            Node nodeF = map.Nodes.First(n => n.Height == 5);

            Assert.NotNull(nodeA);
            Assert.NotNull(nodeB);
            Assert.NotNull(nodeC);
            Assert.NotNull(nodeD);
            Assert.NotNull(nodeE);
            Assert.NotNull(nodeF);

            Assert.True(nodeA.ConnectedNodes.Count() == 1);
            Assert.True(nodeB.ConnectedNodes.Count() == 1);
            Assert.True(nodeC.ConnectedNodes.Count() == 2);
            Assert.True(nodeD.ConnectedNodes.Count() == 2);
            Assert.True(nodeE.ConnectedNodes.Count() == 2);
            Assert.True(nodeF.ConnectedNodes.Count() == 3);

        }

        [Fact]
        public void StartingNodeHasCharSAndHeight0()
        {
            Node startingNode = new('S');
            Node notStartingNode = new('a');

            Assert.True(startingNode.IsStartingNode);
            Assert.False(notStartingNode.IsStartingNode);
            Assert.Equal(0, startingNode.Height);
        }

        [Fact]
        public void EndingNodeHasCharEAndHeightZ()
        {
            Node endingNode = new('E');

            Assert.False(endingNode.IsStartingNode);
            Assert.True(endingNode.IsEndingNode);

            Assert.Equal('z' - 'a', endingNode.Height);
        }

        [Fact]
        public void FindShortestPathReturns0NoStartingNodeIsProvided()
        {
            HeightMap heightMap = new("a");
            ShortestPathCalculator pathCalculator = new(heightMap);
            Assert.Throws<Exception>(() => pathCalculator.FindShortestPathWithOneStartingPoint());
        }

        [Fact]
        public void FindShortestPathReturns0NoEndingNodeIsProvided()
        {
            HeightMap heightMap = new("a");
            ShortestPathCalculator pathCalculator = new(heightMap);
            Assert.Throws<Exception>(() => pathCalculator.FindShortestPathWithOneStartingPoint());
        }

        [Fact]
        public void JustStartingNodeAndEndingNodeProvided()
        {
            HeightMap heightMap = new("SE");
            ShortestPathCalculator pathCalculator = new(heightMap);
            Assert.Throws<Exception>(() => pathCalculator.FindShortestPathWithOneStartingPoint());
        }

        [Fact]
        public void CanReachEnd()
        {
            HeightMap heightMap = new("SbcdefghijklmnopqrstuvwxyE");
            ShortestPathCalculator pathCalculator = new(heightMap);
            int shortestPath = pathCalculator.FindShortestPathWithOneStartingPoint();
            Assert.Equal(25, shortestPath);
        }

        [Fact]
        public void CanReachEnd2()
        {
            HeightMap heightMap = new("Sabcdefghijklmnopqrstuvwx\r\n" +
                "bcdefghijklmnopqrstuvwxyE");
            ShortestPathCalculator pathCalculator = new(heightMap);
            int shortestPath = pathCalculator.FindShortestPathWithOneStartingPoint();
            Assert.Equal(25, shortestPath);
        }

        [Fact]
        public void LargeExample()
        {
            string filePath = @"TestFiles/Day12/LargeExample.txt";

            string inputString = File.ReadAllText(filePath);

            HeightMap heightMap = new(inputString);

            ShortestPathCalculator pathCalculator = new(heightMap);
            int shortestPath = pathCalculator.FindShortestPathWithOneStartingPoint();
            Assert.Equal(31, shortestPath);
        }

        [Fact]
        public void ExerciseSolution()
        {
            string filePath = @"TestFiles/Day12/ExerciseInput.txt";

            string inputString = File.ReadAllText(filePath);

            HeightMap heightMap = new(inputString);

            ShortestPathCalculator pathCalculator = new(heightMap);
            int shortestPath = pathCalculator.FindShortestPathWithOneStartingPoint();
            Assert.Equal(361, shortestPath);
        }

        private void AssertNode1HasNodes(Node node1, List<Node> nodes)
        {
            nodes.Should().BeEquivalentTo(node1.GetConnectedNodes());
        }

        private void AssertNode1HasNodes(Node node1, Node node2)
        {
            AssertNode1HasNodes(node1, new List<Node> { node2 });
        }
    }
}
