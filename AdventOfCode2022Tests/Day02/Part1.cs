using FluentAssertions;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2022Tests.Day02
{
    public class Part1
    {
        private readonly ITestOutputHelper output;

        public Part1(ITestOutputHelper output)
        {
            this.output = output;
        }


        [Fact]
        public void RockBeatsScissors()
        {
            Shape rock = Shape.Rock();
            Shape scissors = Shape.Scissors();

            Assert.True(rock.Beats(scissors));
        }

        [Fact]
        public void PaperBeatsRock()
        {
            Shape paper = Shape.Paper();
            Shape rock = Shape.Rock();

            Assert.True(paper.Beats(rock));
        }

        [Fact]
        public void ScissorsBeatsPaper()
        {
            Shape scissors = Shape.Scissors();
            Shape paper = Shape.Paper();

            Assert.True(scissors.Beats(paper));
        }

        [Fact]
        public void RockScissorsWinningRound()
        {
            // Arrange
            Round round = new(Shape.Rock(), Shape.Scissors());
            int expectedScore = 7;

            // Act
            int actualScore = round.GetScore();

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void RockScissorsLosingRound()
        {
            // Arrange
            Round round = new(Shape.Scissors(), Shape.Rock());
            int expectedScore = 3;

            // Act
            int actualScore = round.GetScore();

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void RockDrawRound()
        {
            // Arrange
            Round round = new(Shape.Rock(), Shape.Rock());
            int expectedScore = 4;

            // Act
            int actualScore = round.GetScore();

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void PaperRockWinningRound()
        {
            // Arrange
            Round round = new(Shape.Paper(), Shape.Rock());
            int expectedScore = 8;

            // Act
            int actualScore = round.GetScore();

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void PaperRockLosingRound()
        {
            // Arrange
            Round round = new(Shape.Rock(), Shape.Paper());
            int expectedScore = 1;

            // Act
            int actualScore = round.GetScore();

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void PaperDrawRound()
        {
            // Arrange
            Round round = new(Shape.Paper(), Shape.Paper());
            int expectedScore = 5;

            // Act
            int actualScore = round.GetScore();

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void ScissorsPaperWinningRound()
        {
            // Arrange
            Round round = new(Shape.Scissors(), Shape.Paper());
            int expectedScore = 9;

            // Act
            int actualScore = round.GetScore();

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void ScissorsPaperLosingRound()
        {
            // Arrange
            Round round = new(Shape.Paper(), Shape.Scissors());
            int expectedScore = 2;

            // Act
            int actualScore = round.GetScore();

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void ScissorsDrawRound()
        {
            // Arrange
            Round round = new(Shape.Scissors(), Shape.Scissors());
            int expectedScore = 6;

            // Act
            int actualScore = round.GetScore();

            // Assert
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void TournamentTotalScore()
        {
            Mock<ITournamentDataSource> dataSource = new();
            Round winRound = new(Shape.Rock(), Shape.Scissors());
            Round drawRound = new(Shape.Paper(), Shape.Paper());
            Round loseRound = new(Shape.Scissors(), Shape.Rock());

            int expectedTotalScore = 7 + 5 + 3;

            dataSource.Setup(ds => ds.GetRounds()).Returns(new List<Round>()
            {
                winRound,
                drawRound,
                loseRound,
            });

            Tournament tournament = new(dataSource.Object);
            int actualTotalScore = tournament.GetTotalScore();

            Assert.Equal(expectedTotalScore, actualTotalScore);
        }

        [Fact]
        public void TextDataSourceReadsRoundInfo()
        {
            string filePath = @"TestFiles/Day02/ThreeRounds.txt";
            ITournamentDataSource fileDataSource = new FileDataSource(filePath);

            List<Round> expectedRounds = new() {
            new(Shape.Rock(), Shape.Rock()),
            new(Shape.Paper(), Shape.Paper()),
            new(Shape.Scissors(), Shape.Scissors())
            };

            List<Round> actualRounds = fileDataSource.GetRounds();

            expectedRounds.Should().BeEquivalentTo(actualRounds);
        }

        [Fact]
        public void TournamentReadsRoundsFromFile()
        {
            string filePath = @"TestFiles/Day02/ThreeRounds.txt";
            ITournamentDataSource fileDataSource = new FileDataSource(filePath);
            Tournament tournament = new(fileDataSource);
            int expectedScore = 3 * 3 + 1 + 2 + 3;

            int actualScore = tournament.GetTotalScore();

            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void ExerciseSolution()
        {
            string filePath = @"TestFiles/Day02/Part1.txt";
            ITournamentDataSource fileDataSource = new FileDataSource(filePath);
            Tournament tournament = new(fileDataSource);

            int actualScore = tournament.GetTotalScore();

            output.WriteLine(actualScore.ToString());
        }
    }
}
