using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode2022Tests.Day17
{
    public class Part1
    {
        [Fact]
        public void CanCreateRocksInOrder()
        {
            RockFactory factory = new RockFactory();
            Rock rock = factory.CreateTheNextRockInOrder();
            Assert.Equal("Horizontal", rock.Type);
            rock = factory.CreateTheNextRockInOrder();
            Assert.Equal("Star", rock.Type);
            rock = factory.CreateTheNextRockInOrder();
            Assert.Equal("L", rock.Type);
            rock = factory.CreateTheNextRockInOrder();
            Assert.Equal("Vertical", rock.Type);
            rock = factory.CreateTheNextRockInOrder();
            Assert.Equal("Square", rock.Type);
            rock = factory.CreateTheNextRockInOrder();
            Assert.Equal("Horizontal", rock.Type);
        }

        [Fact]
        public void HorizontalRocksAreCreatedWithCorrectCoordinates()
        {
            RockFactory factory = new RockFactory();
            int bottomLength = 3;
            Rock rock = factory.CreateRock("Horizontal", bottomLength);
            Assert.Equal(2, rock.Coordinates[0].X);
            Assert.Equal(bottomLength + 4, rock.Coordinates[0].Y);
            Assert.Equal(3, rock.Coordinates[1].X);
            Assert.Equal(bottomLength + 4, rock.Coordinates[1].Y);
            Assert.Equal(4, rock.Coordinates[2].X);
            Assert.Equal(bottomLength + 4, rock.Coordinates[2].Y);
            Assert.Equal(5, rock.Coordinates[3].X);
            Assert.Equal(bottomLength + 4, rock.Coordinates[3].Y);
        }

        [Fact]
        public void ChamberHasRocks()
        {
            RockFactory rockFactory = new();
            Chamber chamber = new(rockFactory);
            chamber.CreateRock();
            Rock rock = chamber.CurrentRock;
            Assert.Equal("Horizontal", rock.Type);
        }

        [Fact]
        public void HorizontalRockFallsDownInChamber()
        {
            IRockFactory rockFactory = new MockHorizontalRockFactory();
            Chamber chamber = new(rockFactory);
            chamber.CreateRock();
            chamber.TryToMoveRock();
            Rock rock = chamber.CurrentRock;
            Assert.Equal(3, rock.Coordinates[0].Y);
        }

        [Fact]
        public void FirstHorizontalThenStarRockRollsDownInChamber()
        {
            IRockFactory mockRockFactory = new RockFactory();
            string wind = ">>><<><>><<<>><>>><<<>>><<<><<<>><>><<>>";
            Chamber chamber = new(mockRockFactory, wind);
            chamber.CreateRock();
            chamber.Roll();
            double expectedHeight = 1;
            double actualHeight = chamber.GetHeight();
            Assert.Equal(expectedHeight, actualHeight);
            HashSet<Coordinate> expectedRockCoordinates = new HashSet<Coordinate>()
            {
                new Coordinate(2, 1),
                new Coordinate(3, 1),
                new Coordinate(4, 1),
                new Coordinate(5, 1)
            };
            var actualRockCoordinates = chamber.RockCoordinates;
            actualRockCoordinates.Should().BeEquivalentTo(expectedRockCoordinates);

            chamber.CreateRock();
            chamber.Roll();
            expectedHeight = 4;
            actualHeight = chamber.GetHeight();
            Assert.Equal(expectedHeight, actualHeight);
            expectedRockCoordinates = new HashSet<Coordinate>()
            {
                new Coordinate(2, 1),
                new Coordinate(3, 1),
                new Coordinate(4, 1),
                new Coordinate(5, 1),

                new Coordinate(3, 2),
                new Coordinate(3, 3),
                new Coordinate(3, 4),
                new Coordinate(2, 3),
                new Coordinate(4, 3)
            };
            actualRockCoordinates = chamber.RockCoordinates;
            actualRockCoordinates.Should().BeEquivalentTo(expectedRockCoordinates);

            chamber.CreateRock();
            chamber.Roll();
            expectedHeight = 6;
            actualHeight = chamber.GetHeight();
            Assert.Equal(expectedHeight, actualHeight);
            expectedRockCoordinates = new HashSet<Coordinate>()
            {
                new Coordinate(2, 1),
                new Coordinate(3, 1),
                new Coordinate(4, 1),
                new Coordinate(5, 1),

                new Coordinate(3, 2),
                new Coordinate(3, 3),
                new Coordinate(3, 4),
                new Coordinate(2, 3),
                new Coordinate(4, 3),

                new Coordinate(0, 4),
                new Coordinate(1, 4),
                new Coordinate(2, 4),
                new Coordinate(2, 5),
                new Coordinate(2, 6)
            };
            actualRockCoordinates = chamber.RockCoordinates;
            actualRockCoordinates.Should().BeEquivalentTo(expectedRockCoordinates);

            chamber.CreateRock();
            chamber.Roll();
            expectedHeight = 7;
            actualHeight = chamber.GetHeight();
            Assert.Equal(expectedHeight, actualHeight);
            expectedRockCoordinates = new HashSet<Coordinate>()
            {
                new Coordinate(2, 1),
                new Coordinate(3, 1),
                new Coordinate(4, 1),
                new Coordinate(5, 1),

                new Coordinate(3, 2),
                new Coordinate(3, 3),
                new Coordinate(3, 4),
                new Coordinate(2, 3),
                new Coordinate(4, 3),

                new Coordinate(0, 4),
                new Coordinate(1, 4),
                new Coordinate(2, 4),
                new Coordinate(2, 5),
                new Coordinate(2, 6),

                // Vertical Rock
                new Coordinate(4, 4),
                new Coordinate(4, 5),
                new Coordinate(4, 6),
                new Coordinate(4, 7)
            };
            actualRockCoordinates = chamber.RockCoordinates;
            actualRockCoordinates.Should().BeEquivalentTo(expectedRockCoordinates);

            chamber.CreateRock();
            chamber.Roll();
            expectedHeight = 9;
            actualHeight = chamber.GetHeight();
            Assert.Equal(expectedHeight, actualHeight);
            expectedRockCoordinates = new HashSet<Coordinate>()
            {
                new Coordinate(2, 1),
                new Coordinate(3, 1),
                new Coordinate(4, 1),
                new Coordinate(5, 1),

                new Coordinate(3, 2),
                new Coordinate(3, 3),
                new Coordinate(3, 4),
                new Coordinate(2, 3),
                new Coordinate(4, 3),

                new Coordinate(0, 4),
                new Coordinate(1, 4),
                new Coordinate(2, 4),
                new Coordinate(2, 5),
                new Coordinate(2, 6),

                // Vertical Rock
                new Coordinate(4, 4),
                new Coordinate(4, 5),
                new Coordinate(4, 6),
                new Coordinate(4, 7),

                // Square Rock
                new Coordinate(4, 8),
                new Coordinate(5, 8),
                new Coordinate(4, 9),
                new Coordinate(5, 9)

            };
            actualRockCoordinates = chamber.RockCoordinates;
            actualRockCoordinates.Should().BeEquivalentTo(expectedRockCoordinates);
        }

        [Fact]
        public void RockRollsUntilItHitsGround()
        {
            RockFactory rockFactory = new();
            string wind = ">>><";
            Chamber chamber = new(rockFactory, wind);
            chamber.CreateRock();
            chamber.Roll();
            Rock rock = chamber.CurrentRock;
            Assert.Equal(1, rock.Coordinates[0].Y);

            // Assert X Coordinates
            var xCoordinate = rock.Coordinates.Select(x => x.X);
            Assert.Equal(new double[] { 2, 3, 4, 5 }, xCoordinate);
        }

        [Fact]
        public void RockRollsUntilItHitsAnotherRock()
        {
            IRockFactory rockFactory = new MockHorizontalRockFactory();
            Chamber chamber = new(rockFactory);
            chamber.CreateRock();
            chamber.Roll();
            chamber.CreateRock();
            chamber.Roll();

            Rock rock = chamber.CurrentRock;
            Assert.Equal(2, rock.Coordinates[0].Y);
        }

        [Fact]
        public void NewRockIsCreatedThreeUnitsUpwardOfCurrentHeight()
        {
            IRockFactory rockFactory = new MockHorizontalRockFactory();
            Chamber chamber = new(rockFactory);

            chamber.CreateRock();
            chamber.Roll();

            chamber.CreateRock();
            Rock rock = chamber.CurrentRock;
            Assert.Equal(5, rock.Coordinates[0].Y);
            chamber.Roll();

            chamber.CreateRock();
            rock = chamber.CurrentRock;
            Assert.Equal(6, rock.Coordinates[0].Y);
        }

        [Fact]
        public void RockMovesInWind()
        {
            RockFactory rockFactory = new();

            string windDirection = "><><";
            Chamber chamber = new(rockFactory, windDirection);

            chamber.CreateRock();
            Rock rock = chamber.CurrentRock;

            chamber.TryToMoveRock();
            var xCoordinates = rock.Coordinates.Select(c => c.X);
            Assert.Contains(3, xCoordinates);
            Assert.Contains(4, xCoordinates);
            Assert.Contains(5, xCoordinates);
            Assert.Contains(6, xCoordinates);

            chamber.TryToMoveRock();
            xCoordinates = rock.Coordinates.Select(c => c.X);
            Assert.Contains(2, xCoordinates);
            Assert.Contains(3, xCoordinates);
            Assert.Contains(4, xCoordinates);
            Assert.Contains(5, xCoordinates);

            chamber.TryToMoveRock();
            xCoordinates = rock.Coordinates.Select(c => c.X);
            Assert.Contains(3, xCoordinates);
            Assert.Contains(4, xCoordinates);
            Assert.Contains(5, xCoordinates);
            Assert.Contains(6, xCoordinates);

            chamber.TryToMoveRock();
            xCoordinates = rock.Coordinates.Select(c => c.X);
            Assert.Contains(2, xCoordinates);
            Assert.Contains(3, xCoordinates);
            Assert.Contains(4, xCoordinates);
            Assert.Contains(5, xCoordinates);
        }

        [Fact]
        public void Example()
        {
            IRockFactory mockRockFactory = new RockFactory();
            string wind = ">>><<><>><<<>><>>><<<>>><<<><<<>><>><<>>";
            Chamber chamber = new(mockRockFactory, wind);

            for (double i = 0; i < 2022; i++)
            {
                chamber.CreateRock();
                chamber.Roll();
            }
            chamber.GetHeight().Should().Be(3068);
        }

        [Fact]
        public void Solution()
        {
            IRockFactory mockRockFactory = new RockFactory();
            string wind = ">>>><<<><>>><<<<>>><>>><>><<<<>>><>><<<<>><<<<>><<<>>>><>>>><<<<>>><>><<>>>><>>>><<>>>><<<<>>>><<<<>>><<>>><<<>>><<<<>>" +
                "<<>><>>>><<<>>><>><<<<>><<<>><<>>>><<<<>>>><<><>>><<<<><>><<<<>>>><><<<<>>><<<<>><<<<>>><<<>><<<>>><<>><>>>><<<>>><>>>><<<<>>>><<" +
                ">>>><><>>>><<<><<<<><<<<>>><<>>><<<<>>><<<>><<<<>><>><<>>><<>>><<<<>>>><<>>><<<>>><<>>><<<>>><<<>><<>><<<>>>><>><<<<>>>><><>><>><" +
                "<><<<><<<<>>><<<<>>><>><<<<><<<>>><<<<>><<>><<<<>>><<<>>><<>>>><<<>>><<<>>><<<<><<>><>><<<<><<<><<><<<><<<>>>><<<><<>>><<<<><<<<>" +
                ">><>><>>><<<>><<>><<<<>>><<>>><><<<<>><<><<<<>><<<<>>><<<<>><>><<>><<<<>><<>>>><<<>><<<<>>><<<>>>><><<<>>>><<<>>>><<><<<<>>>><><<>" +
                ">>><<>><<<<>>>><><<<>><><<<>>><><<<>><<<>>><>>><<<>>><<<<>>>><<<>>>><>>><>>>><<>><<><<<><<>>><<>><<<><<<<><<<>>>><<>>><<>><<>><><>" +
                "<<>>><>>>><<>><<<>>>><>>><><<>>>><>>>><>>><<<>><<<<>><<><<<<>>><<><<>>>><<<<>>><<<<>>>><<<<>><<><<<<>><>>>><<<<>><<<>>><<<>>>><>><" +
                ">>>><>><<>>><<>>>><<<>><<>>>><<<<>>>><<><<<<>>><><<<><<<<>>><<>>>><>>>><>>>><<>><<>><<><<<><<<<>>><<<<><<<>>>><<>>><<<<>>><>>>><<>" +
                ">>><<>><<>>><<>><<<<>><>><<<<>>>><<>>><<<>>>><>>>><<<><>>>><<>>>><<<>>><<><>>><>>><<<<><>><<<>><<><<<>><><>><><<>><<<>><<<>><<<>>>" +
                "<<>><<>><<<<>><>>><><<<><>><>><<<<>><<>>><<>>>><<<<>><<<<>>>><<<<><<<<>>><>>>><<<>>>><<<>><<><<<<>>><<<><<><<<>>>><<<<>><<>>>><>>>>" +
                "<<>><<<<>><<<<><>>>><><<<<>><>><<>>><><>><><><<<<>>>><>>><<>><<<>>><<<>><<>>>><<<><<<<><>><<>><>><>>><>>><<>>><<<<>><>>>><>>><<<<><" +
                "<><<<<>><>><>>>><>><<>>><>><><<<><<<>>><<<>>><<<<><<>>>><><<<>>>><<>>><<<>>><<<>>><<<<><><<<>>>><<<<>>>><<<<>>><><<<<><>>>><<<><>>>" +
                "><>>>><<<<>>>><<<>>>><<<<><<<>><<>>><<<>><>><>>><><<<<><<<<><<<><><<<<>><<>>>><>>><><<<<>>><>><<<>><<>>><<<><<><<>>>><<<<>>><<<>>>>" +
                "<<<>>><<><<<><<<<>>>><<>><>><<<>>>><<>>><>>><<<>>><<<<>>><><<<<>>>><<<>><<<><<>><<>>>><<<>><<>>>><<>><<<><>>><>><><<<<>>>><><<<<>>" +
                "><<<>>>><<<<>>>><<>>>><<>>><>>>><<<>>>><<<>>><<<><<<<><>><<<<>>><<<<>>><<>><<<<>>><>>><<<<>>>><<>><<>>><<<<><<>>>><<>><<>>>><>>>><" +
                "<<>>>><<<><>><>>>><<<<>><<>>>><<<>>><<<<>>>><><<>>><<<>>><<<>>><<>>>><<<>>><>>><<<<>><<><<<<>><<<<>>>><<<>>>><>>>><>>><<>>>><<><<<>>" +
                "<>><<<>>>><<<<><<<<><<<<>>><<<<><><<>><<>><<<<>>>><<>>>><>>><<>>>><<<<><>><<>>>><>><>>><<<>><<<<>><<<><<<>>>><<<>><<>>>><<<<><<<<>>>" +
                "<<<>><>>><<><<>>>><<<<><<<<>>>><<<>>>><<>>><>>><<<>><<><<<>>>><>>>><<<>>>><<<<>>><<<>>>><>>>><<<<>>>><<<>><<<<>>>><><<<>><<<<><<<><<" +
                ">>>><<>>><>>><<<>>><<<<><<><<><<<><<<>>>><<<<><<<<><<><<>>><>><<>><<><<<>>>><<<><<<<>>><>>>><<<<>>>><<<<><<<>>>><<<>>>><>><<>>><>>>>" +
                "<<>>><<>>><>><<>><<>>>><<>>>><>><<><<<<>>><<>>><>>>><<<<>>><<<>>><<<><<<<><<>><>><<<<>>><<>>>><>>>><<<><><<>>><<><<<><<<><>>>><<><>" +
                "><>><>><<<>>>><<<>><<>>>><<<>>><>>>><<<><<><<<<>>>><>><<><<<<><<<><<<>><><<<>><><<<<>>><<<<>><<<<><<<>>>><<<<>>>><<<>><<><>>>><<>>>" +
                "<>>><<<>>><>>>><<>><<<<>><<<<>>>><<>>><<<>><<<<>>><<<<>>>><>>>><<<<>><>>>><<<>><>>><<<<>>><<<<><<<<>>><<>><<<>><<<<>><<><<>>><<>>>" +
                "<<<>><<>>><<>>>><<<>>>><<<<>>>><<><>>>><<>><>><<<>>><<<>>>><>>>><<<>><<><><>>>><<><<<>><>><><<>><<<>>><<>><<<<><<>>><<<><<<<>>><<>" +
                "><<<>>><<>>>><<<>><<<><<<<>>>><<<>>><<<<><<<<><>>>><<<>><<<>>>><<<>>>><><<<<>>>><>>>><<<>><>><<<<>><><<<>>><<<<>>>><>><<<<>><><<<>" +
                ">>><<<>>>><<<<>>><>><<<<>><<<<>><<<<>>><<>><<<><>>><><<<<>>><<<>>>><<<>>>><<<>>><<<<>><<><<<<>>><<>>>><<<<>><<>>><>>><<<>>><<<<>>>" +
                "><<>><<<>><<>>>><<>>><<<<>>><<>>>><><<<>>>><<<<>>><<<<>><<<>>><>><<>>><<>>>><<<>>><<>>>><>><>>>><<<<>>>><>>>><<<>><<<<>>>><<<<>>><" +
                ">>><<<>>>><<><<><><<<><<<>>>><<>>><<>><<<<>><<>>><<><<<<>><<<>>><<>><>><<><<<<><>>><<<>>>><>>>><<<<><<<>><<>>><>><>><<>>><<<><<<<>>" +
                "><>>>><<<>>>><<<>>>><>><><<<>>>><<<<><<<>>>><<<<>>><>>><<<<>>><>>>><<>>><<<>><<<<><<<><<>>><<<<><<>>>><<<>>>><<<>>><<>><<<<>><><<<<" +
                "><<<>><<>>>><>>><<><<><<<><<>>>><<>><<>>>><<>>>><<<>>><<>><<>>><<<><>>>><<<>>><>>><>>><>><<>><>><<<<>>>><><<<<>>><><<<>>>><<<<>><<<<>>" +
                "><<>>><<<>>>><<<<>>>><<<<><>>><<><<<>>>><<<>><<<<>>>><<<><<<>><<<>><<>>><<<>>><><><>>>><>>>><<>>><<<>>><>>>><<<>><>>><>>><<<<>><<><<<<" +
                "><<><<<<>>>><<<>><><>>>><<<>>><<<>><<>>>><><<<<>><<<<>>>><<<><<>>><<>>><<<<>>>><<>><<>>><>>><<>>><<><>><<>><>>><<<<>><<<>>>><<<>><<<<" +
                ">>>><>>><<<>>><<<<>>>><<<>><<><>>>><<<<><<>>><<>>>><<<<><>>><<<<>>>><><<<<>>><>><<<<>><<<<><<<>>><<<<><<>>>><<<<>>><<<><<><<<>><<<<><" +
                "<<>><<<><>>><<<<>>>><>>><<>>>><<<>>><<<<>>>><<<<>>>><<<>><<>>><<>>><<<>>><<<<>><<<>>><<><<>>><<<<>>>><>>><<<>><<<>>><<><<<>>>><<<><<<" +
                "<>>>><<<>><<<<>>><<>>>><<>><<<><><><<<><<<>>><<<>><><><<<><<<<>><>>>><<<>>><<<>><<<>>>><>><<>><>>>><<>>>><><>><<>>>><<<>>><<<>>>><<<>" +
                ">>><<<><<><<<>><>>><<<<>>>><<>><<<<><>>><<>>>><<<<>>><<><<<>>>><<<><<<>>>><<<<>>><<<<>>><<<>><<>>>><<<>>>><<<><<><>>><<<<>>><<>>><<>>" +
                "><<<><<<><<>><<<><>><<>><<<<><<>>>><>>><>>><>>><>><><<<>>><<<>>>><<>><>><<><<>>><<>>><><<<><<><<<<>>><>>>><<<<>>>><<>>>><<<>><<<>><><" +
                "<<<>>><<<><<<<>>><>>>><<>>>><<>><<<>>><<<><<<<>>><<>>><<><>>>><><<<>>><<<>><><><<<><<<><<<<>>><<><>>><<<<>><<<<>>><<<><<<>>><<><<<><<" +
                "<><<<<>><><>><><<<>>>><<>>><>><>>><><<<<>>>><<<<>>>><<<>>>><<<>>><<<<>>>><<<<><<<<>><>>>><<><<<<>>>><<>>><<><><<<<>><<<>>>><<<>>><<<>" +
                "<<>>>><<><<>>><<>><<>><<<>>>><<>>><<<<>>>><<<><>>>><>><<<>>>><><<<<>>>><<>>>><<<>>><<>>>><<<>>><<<<>><<>>><<<<>>><>>><<<><<>>><>><<>>" +
                "<<<<><<<<>>>><<<<>><>>><<<<>>>><<<<>>>><<<<>><<<<>>><<<>>><<<>>><<>><>>><<>>>><>>><>>>><>>><<<><<<>><<<><<<<><<<>><>><><<<<>>>><<>>><<" +
                "<>>>><<><>>>><<<<>>><<><<>><<><<<><<<<>><>>>><><<<><<>><<<>><<<<>>>><>>>><<<<>><<<><<<<><<>>><<<<><<<>>>><<<>>>><<>><<<<><>><><><><<>>><<" +
                "<><<>><<>>>><<<>>><>><<<>>><<<>>><<>>><>>><<<<>>>><<<<>><<<<>>><<<>><<<>>>><<><>><><<><<>><<" +
                "<>>>><<<><<>>>><<><<<<>>><<>><<<>>><<><<>>><<<>><<><<>><<><<><<<>>>><>>><<<><<<>>>><><<<>><<<>>><<><>>><<<<>>>><>><<<><>>><<>>>><<<><" +
                "<<>><>>>><<<><<<<><>><<<<>>><<<<>><><><<<>>>><<<>>><<>>><<<<>>><<<<>>><<<<>>><<<<>>><<>>>><<>>>><<<<>>><<>><><>>>><<>>><>>>><<<>><<<" +
                "<>>>><<<<>>><<<>>>><>><<<<>>>><<<<><<<<>>>><><>><>>><<>><>>>><<<<>>><<<><<<><<<>>>><<<>>>><><><<<>>>><>>><<<>><><<<<><<<<>><<<>><><<" +
                ">>><<<<><<>>><<>>><<>>><>>>><<<>><><<<>>><<<<>>><<<<>><><<<<>><<<>>>><<<<>>><<<>>><<><<>>>><>><<<><<<>>>><<<><<<<>>><>>>><<>>><<<<>>" +
                "<<<<>>>><<<>>><<<>>><<<>>><<<>>><<<>>><><><<>><>>><<<>>><<><>>>><<>>><<<<>><<><<<<>>><<<<><<>><>><<<>><<<<><<<<>>><<><>><<<<>><<<>>" +
                ">><<<>>>><<<<>><<<>>><<>>>><<<<><<<<>>>><<<<><<<<>>>><>>><<<<><<<><<<>>><<<>>>><>><<<>><<>>>><>>><><<>>><<<<>>>><>>><<<>><<>><<<>><" +
                "<<<>><<<<><<<<><<<<><<<<>><<>><<<><<>>><<<<>>><>><<><>>>><<<>>><<<<>>><<>>><<<><<<<>><<>><<>>>><<<<><>>>><<<><<>>>><<<<>>>><<<>><<>>" +
                ">><>><<<<>>><<<<><<>><<<<>>>><><><<>><<>>><<<>><<<<><<<>>>><<<>>><<<<><<<<><>>>><><<<>><<<>><>>><<><><<<><<><>>>><<<<>>><<<<><<<<>>>" +
                "<<<<>>><<<<><>>>><<<>>>><<<>>>><<<<><<>>><<>>><<<<>>>><<<<>>><<>>>><><><<><<>><<>><<><<>>>><>><><<<>>>><<<>><<<>>>><<>>>><>>><<>><<<" +
                "<>><>>><<<><<<<><<<><<<<>>><<<>><<>>>><<<>>>><<<<>>>><<<<>>><>>><<<>>><>>>><<<<>><<<<>>>><<>>>><<>><<<<>>>><<>><>>><<<>>><>>>><<><<<" +
                "<>><<>>><<<>>><<<><<<<><<<<>><<>><>><>><<>><<>>><<<<>><<<>><<<<>><>><<<>>>><>>>><>>><<>>><><<<<>>>><<>><<<<>>>><<>><<<>>><<<><<<<>>" +
                "><<>><<<>>>><<<>>>><<>>>><>><<<>><>>>><<>>><<>>>><<<>>>><<>>><>>><<<>>>><<>><<<<>>><<>><<<>><>><<<><<<><<<>><<<<>><<<<>>>><<>><><>>><<<>>><<<<><<<>>>><<<<>>><>><<<>>><<<<>>><<<>>><><<><<>><>>><<>>><<<<>>>><<<<>>>><<<>>>><><<<>>>><<><<<<>>>><<>><>>><><<<>>><<<>>><<<>>>><<<<>>><>>><<<<><<<>>>><<<>>>><<<>>><<<<><<>>><>><<<<>><>><<<<><<>>>><<<>>>><<<<>>>><<>>><><<<>>><<<>><<<<>>>><<<<>>><<>>><<<>>>><>>>><<<>>><<>><<<<>><<<>><<<>><<<<>><<<>><<><<><>><><><<>>>><<>>><>>>><>><><>><><<>>><<>>>><>><<<<>><><<<><<<<>>><<>>>><<<<>>>><><>><<>>>><<><<<>>><>><<<<>>><<>><<><<>>>><<<<>>><<<>>><<<<><<<><<<><<<><>><<<>><<<><<<<><<<>><<><<<<>><<>><>>><<>>><>>>><><<>><<>><<>>>><>>><<<<>>>><<<>><>><<<>>><<<<>><<>>><<<<>>>><<<<>><<<><>><<><<<>>><<<<>>><<<>>><<>><<<>>><>>>><<<<>><<<<>><<>>>><<<>>>><<<><<<>><>>>><<><<<<>>>><<<><>>>><<>>><<<>>><<>>>><<<>>>><<<><<<>><<<><<>>><<<<>>><<><<<<>><<<><<<<>>>><<>>>><<<>><<>><<<>>>><<<><<<><<<<>>>><>>><<<>>><<<<>>><<<<><<<>>>><<<<>><<>><<><<<>>><<<>>><<<>><>>>><>><<><<<<>>>><>><><><<<<>><>><<<<>><><<<>>><<<<><>>><><>>><<<<>>><<>>><<<>>>><<<<>>><<<<><<<>>>><<>>>><>><<<>>><<<<>><<>>><<<<>>>><<<<><<>>>><<<>><<<>>><<<<><<>>><<>>><>>>><<<<>>><<<><<<>>>><>><<<>><<<>><><<<<><<>>>><<>><>>><<>><<<<>>>><<>><>>><<<<>><><<<<>><<<<>>><<<<>>>><<<><<>>><<<>><<<>>>><<>><<>><>>><<>>>><><<>><<>>>><<>>><>>><<<<>><<>>><<<>>><<><<<<>><<<><<<<>>>><<<>>><<<<>>><<<<>>><<<>>><<<<>>>><>>><<<<>>><<<>>>><<><<<<>>><<>>>><<<>>>><<<<>>>><<>>>><<><<<<>><><<<>>>><>>>><<>>>><><<<>>><<>>>><><<<>><<<>>><<<>>>><>>>><>>><<>>>><<<>>>><<>>><<<<><<<<>><>><<<>>>><<><<<>>><<<>><<>><<<<>>>><<><<<<><<>><<>>><>><<<>>><><<<>>>><<><<<>>>><<<><<<>><>>>><>>>><<<>>>><>>><>>><<<><<<<>>><<<<><<<><<>>>><<<>>>><<<<><<<><<<>>>><<<>>>><<>>>><<<><<>>>><><<>><<<><<<>>><<<>><<<<><<><<<<><<<>>>><<<>><<><<>><<><<<>><<>>>><<<>><<<<>><<<>>><>>>><<<<>>>><<>>>><>>>><<>><<>><<<><<<<>><<>>><<<<>>><<>>>><<><<<<><<<>>><<<<><<<>>><<>><<<<>>><<<<>>><<<<>>>><<>><<<<>>>><<<<>><<<<>>><<<<>>><<<>>>><<>><<<<>>><<><<<<>><<>>>><<<<><<>>>><>>>><>>><>>>><<<><<<<><<>><<<<>><<<>>>><<<<>>>><<>><<>>><<<><<<>><><<<<><<<<>>><<<<>>><<<>>><>><<><<>><<<>>>><<<<>><>><<><<<<>>><<<>>><<<<>><<>>>><>><>>>><<<>>><<<<>>><<><<>><<<>><<<><>>><><<>>><<<>>><<<>>><<<<>>>><<<>><<<>><<<>>><<<<>>>><<<><<>>><>>><>><>>>><<<>><<<><<<>>>><<<<><<<>><>>><>><<<><><<><<<>>><>><<<<>><<<<>>>><<>><>><<<<>><>><<<<>>><<<<>><>>><>>>><<<<>>>><<<><<<>>><>>>><<<<>>>><<<<>><<<><<<<>>>><<<>>><<><<<>>><<<>>>><>><<><<<><<<<>><<<>>><<<>>><<<>>><<<>><<<<>>>><<<<>><<>>><>>><<<><<>>><<<<><<<>>><<<<>>>><<<<><>><<>>>><<<>><>>><<><<<<>>><><<<><<>><<<<><<<>>>><><<><<>>><<>>><>>><>>><>>>><<><><><<>>>><>>>><<<<>><<<<>>>><><<<<>>><<<><<<<><><<>>><<<<>>><<<<>><<<<>>>><<><<<>>><<<<>>>><<<><<<<><>>><<<>>><>>>><<<>><<<<>>>><<<<>><<<><<<>>><><<>>><<>>><>>><<<<><<<>>><<<<><<<>>><<>>><<<><<>><><<>>><<<<>>><<<<>>>><<>><<<<><><<<><<<<>>>><<><>><<>>>><>>><<>>>><<><<<>>>><<<<>><<<><<>>>><<>>><<>><<<>>><<><<<<>>><<<<>>>><<<<><<<>><>>><<<>>>><<<><<<<><<>>><<>><>>>><>>><<<<>>>><<<<>><><>>>><<>>><<><<<>>><<<<><<<<>>><>>>><<<<><<<><<<<>>>><<>><<<<>>>><<<>><<>><>>><<<<>>>><>>><>>><<><>><<<><>><<<<>>>><><<>><<<>><>>><><<>>><<<<>><<><<<<><>>><<<><<<<>>";
            Chamber chamber = new(mockRockFactory, wind);

            for (int i = 0; i < 2022; i++)
            {
                chamber.CreateRock();
                chamber.Roll();
            }
            chamber.GetHeight().Should().Be(3191);
        }
    }

    public class MockHorizontalRockFactory : IRockFactory
    {
        public Rock CreateRock(string type, double bottomLength)
        {
            throw new NotImplementedException();
        }

        public Rock CreateTheNextRockInOrder(double currentHeight)
        {
            RockFactory rockFactory = new();
            // Create a horizontal rock
            return rockFactory.CreateRock("Horizontal", currentHeight);
        }
    }

    public class MockFirstTimeHorizontalThenStarRockFactory : IRockFactory
    {
        private bool _firstTime = true;
        public Rock CreateRock(string type, double bottomLength)
        {
            throw new NotImplementedException();
        }

        public Rock CreateTheNextRockInOrder(double currentHeight)
        {
            RockFactory rockFactory = new();
            // Create a horizontal rock
            if (_firstTime)
            {
                _firstTime = false;
                return rockFactory.CreateRock("Horizontal", currentHeight);
            }
            else
            {
                return rockFactory.CreateRock("Star", currentHeight);
            }
        }
    }

}
