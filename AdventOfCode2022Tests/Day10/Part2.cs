using Xunit;

namespace AdventOfCode2022Tests.Day10
{
    public class Part2
    {
        [Fact]
        public void CRTDrawsLines()
        {
            CRT crt = new(4);
            int pixelNum = 0;
            int spritePos = 1;

            crt.DrawSprite(pixelNum, spritePos);
            //"#"

            pixelNum++;
            spritePos = 3;
            crt.DrawSprite(pixelNum, spritePos);
            //"#."

            pixelNum++;
            spritePos = 3;
            crt.DrawSprite(pixelNum, spritePos);
            //"#.#"

            pixelNum++;
            spritePos = 1;
            crt.DrawSprite(pixelNum, spritePos);
            //"#.#."

            string[] expectedLine = new[] { "#.#." };

            Assert.Equal(expectedLine, crt.GetLines());
        }

        [Fact]
        public void CRTDrawsMultipleLines()
        {
            CRT crt = new(4);

            int pixelNum = 0;
            int spritePos = 1;

            crt.DrawSprite(pixelNum % 4, spritePos);
            //"#"

            pixelNum++;
            spritePos = 3;
            crt.DrawSprite(pixelNum % 4, spritePos);
            //"#."

            pixelNum++;
            spritePos = 1;
            crt.DrawSprite(pixelNum % 4, spritePos);
            //"#.#"

            pixelNum++;
            spritePos = 2;
            crt.DrawSprite(pixelNum % 4, spritePos);
            //"#.##"

            pixelNum++;
            spritePos = 2;
            crt.DrawSprite(pixelNum % 4, spritePos);
            //"#.##"
            //"."

            pixelNum++;
            spritePos = 2;
            crt.DrawSprite(pixelNum % 4, spritePos);
            //"#.##"
            //".#"

            pixelNum++;
            spritePos = 0;
            crt.DrawSprite(pixelNum % 4, spritePos);
            //"#.##"
            //".#."

            pixelNum++;
            spritePos = 2;
            crt.DrawSprite(pixelNum % 4, spritePos);
            //"#.##"
            //".#.#"

            string[] expectedLine = new[]
            {
            "#.##",
            ".#.#"
            };

            Assert.Equal(expectedLine, crt.GetLines());
        }

        [Fact]
        public void CPUDrawsOnCRT()
        {
            CRT crt = new(3);
            CPU cpu = new(crt);

            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");

            string[] expectedLines = new[]
            {
                "###",
                "###"
            };

            Assert.Equal(expectedLines, crt.GetLines());
        }

        [Fact]
        public void BigExample()
        {
            CRT crt = new(40);
            CPU cpu = new(crt);

            cpu.ExecuteInstruction("addx 15");
            cpu.ExecuteInstruction("addx -11");
            cpu.ExecuteInstruction("addx 6");
            cpu.ExecuteInstruction("addx -3");
            cpu.ExecuteInstruction("addx 5");
            cpu.ExecuteInstruction("addx -1");
            cpu.ExecuteInstruction("addx -8");
            cpu.ExecuteInstruction("addx 13");
            cpu.ExecuteInstruction("addx 4");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx -1");
            cpu.ExecuteInstruction("addx 5");
            cpu.ExecuteInstruction("addx -1");
            cpu.ExecuteInstruction("addx 5");
            cpu.ExecuteInstruction("addx -1");
            cpu.ExecuteInstruction("addx 5");
            cpu.ExecuteInstruction("addx -1");
            cpu.ExecuteInstruction("addx 5");
            cpu.ExecuteInstruction("addx -1");
            cpu.ExecuteInstruction("addx -35");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("addx 24");
            cpu.ExecuteInstruction("addx -19");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("addx 16");
            cpu.ExecuteInstruction("addx -11");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 21");
            cpu.ExecuteInstruction("addx -15");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx -3");
            cpu.ExecuteInstruction("addx 9");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("addx -3");
            cpu.ExecuteInstruction("addx 8");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("addx 5");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx -36");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("addx 7");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 2");
            cpu.ExecuteInstruction("addx 6");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 7");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx -13");
            cpu.ExecuteInstruction("addx 13");
            cpu.ExecuteInstruction("addx 7");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("addx -33");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 2");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 8");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx -1");
            cpu.ExecuteInstruction("addx 2");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 17");
            cpu.ExecuteInstruction("addx -9");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("addx -3");
            cpu.ExecuteInstruction("addx 11");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx -13");
            cpu.ExecuteInstruction("addx -19");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("addx 3");
            cpu.ExecuteInstruction("addx 26");
            cpu.ExecuteInstruction("addx -30");
            cpu.ExecuteInstruction("addx 12");
            cpu.ExecuteInstruction("addx -1");
            cpu.ExecuteInstruction("addx 3");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx -9");
            cpu.ExecuteInstruction("addx 18");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("addx 2");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 9");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx -1");
            cpu.ExecuteInstruction("addx 2");
            cpu.ExecuteInstruction("addx -37");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("addx 3");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 15");
            cpu.ExecuteInstruction("addx -21");
            cpu.ExecuteInstruction("addx 22");
            cpu.ExecuteInstruction("addx -6");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 2");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx -10");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("addx 20");
            cpu.ExecuteInstruction("addx 1");
            cpu.ExecuteInstruction("addx 2");
            cpu.ExecuteInstruction("addx 2");
            cpu.ExecuteInstruction("addx -6");
            cpu.ExecuteInstruction("addx -11");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");
            cpu.ExecuteInstruction("noop");

            string[] expectedLines = new[]
            {
            "##..##..##..##..##..##..##..##..##..##..",
            "###...###...###...###...###...###...###.",
            "####....####....####....####....####....",
            "#####.....#####.....#####.....#####.....",
            "######......######......######......####",
            "#######.......#######.......#######.....",
            };

            Assert.Equal(expectedLines, crt.GetLines());
        }

        [Fact]
        public void ExerciseSolution()
        {
            string filePath = @"TestFiles/Day10/ExerciseInput.txt";

            string[] instructions = File.ReadAllLines(filePath);

            CRT crt = new(40);

            CPU cpu = new(crt);

            foreach (string instruction in instructions)
            {
                cpu.ExecuteInstruction(instruction);
            }

            string[] expectedMessage = new string[]
            {
                "###..###..####..##..###...##..####..##..",
                "#..#.#..#....#.#..#.#..#.#..#....#.#..#.",
                "#..#.###....#..#....#..#.#..#...#..#..#.",
                "###..#..#..#...#.##.###..####..#...####.",
                "#....#..#.#....#..#.#.#..#..#.#....#..#.",
                "#....###..####..###.#..#.#..#.####.#..#.",
            };

            Assert.Equal(expectedMessage, crt.GetLines());
        }
    }
}
