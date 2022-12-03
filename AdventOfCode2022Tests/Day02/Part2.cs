using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2022Tests.Day02
{
    public class Part2
    {
        private readonly ITestOutputHelper output;

        public Part2(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void SelectWinningShapeForRock()
        {
            Shape rock = Shape.Rock();

            Shape expectedShape = Shape.Paper();

            Shape actualShape = rock.GetWinningShape();

            Assert.Equal(expectedShape, actualShape);
        }

        [Fact]
        public void SelectLosingShapeForRock()
        {
            Shape rock = Shape.Rock();

            Shape expectedShape = Shape.Scissors();

            Shape actualShape = rock.GetLosingShape();

            Assert.Equal(expectedShape, actualShape);
        }

        [Fact]
        public void AYResolvesIntoRockDraw()
        {
            string roundText = "A Y";

            Round expectedRound = new(Shape.Rock(), Shape.Rock());

            Round actualRound = new(roundText);

            Assert.Equal(expectedRound, actualRound);
        }

        [Fact]
        public void BXResolvesIntoRockLose()
        {
            string roundText = "B X";

            Round expectedRound = new(Shape.Rock(), Shape.Paper());

            Round actualRound = new(roundText);

            Assert.Equal(expectedRound, actualRound);
        }

        [Fact]
        public void CZResolvesIntoRockWin()
        {
            string roundText = "C Z";

            Round expectedRound = new(Shape.Rock(), Shape.Scissors());

            Round actualRound = new(roundText);

            Assert.Equal(expectedRound, actualRound);
        }

        // A X sc rock
        // B Y pap pap
        // C Z rock sc
        [Fact]
        public void Part2FileDataSource()
        {
            string filePath = @"TestFiles/Day02/ThreeRounds.txt";
            ITournamentDataSource tournamentDataSource = new Part2DataSource(filePath);

            List<Round> expectedRounds = new()
            {
                new Round(Shape.Scissors(),Shape.Rock()),
                new Round(Shape.Paper(),Shape.Paper()),
                new Round(Shape.Rock(),Shape.Scissors()),
            };

            List<Round> actualRounds = tournamentDataSource.GetRounds();

            expectedRounds.Should().BeEquivalentTo(actualRounds);
        }

        [Fact]
        public void ExerciseSolution()
        {
            string filePath = @"TestFiles/Day02/ExerciseInput.txt";
            ITournamentDataSource tournamentDataSource = new Part2DataSource(filePath);
            Tournament tournament = new(tournamentDataSource);
            output.WriteLine(tournament.GetTotalScore().ToString());
        }
    }
}
