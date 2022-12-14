using System.Collections.ObjectModel;

namespace AdventOfCode2022Tests.Day05
{
    public class Cargo
    {
        List<Stack> stacks = new();

        string filePath;

        public Cargo(string filePath)
        {
            this.filePath = filePath;
        }

        public ReadOnlyCollection<Stack> Stacks()
        {
            return new ReadOnlyCollection<Stack>(stacks);
        }

        public void CreateStacks()
        {
            string[] lines = File.ReadAllLines(filePath);

            stacks = CreateEmptyStacks(lines[0]);

            foreach (string line in lines)
            {
                if (LineHasCrateNumbers(line)) break;

                string[] crates = GetCrates(line);

                AddCratesToStacks(crates);
            }

            foreach (Stack stack in stacks)
            {
                stack.Reverse();
            }
        }

        public void MoveCrates()
        {
            string[] lines = File.ReadAllLines(filePath);
            List<string> commandLines = new();
            for (int i = 0; i < lines.Length; i++)
            {
                if (string.IsNullOrEmpty(lines[i].Trim()))
                {
                    commandLines = lines.Take(new Range(i + 1, lines.Length)).ToList();
                    break;
                }
            }

            foreach (string command in commandLines)
            {
                ProcessCommand(command);
            }
        }

        private void ProcessCommand(string command)
        {
            int numberOfCratesToMove = int.Parse(command.Split(' ')[1]);
            int fromStackIndex = int.Parse(command.Split(' ')[3]) - 1;
            int toStackIndex = int.Parse(command.Split(' ')[5]) - 1;
            Stack fromStack = stacks.ElementAt(fromStackIndex);
            Stack toStack = stacks.ElementAt(toStackIndex);

            fromStack.MoveCratesToOtherStack(numberOfCratesToMove, toStack);
        }

        public string GetTopCrates()
        {
            string topCrates = "";

            foreach (Stack stack in stacks)
            {
                topCrates += stack.TopCrate;
            }

            return topCrates;
        }

        private void AddCratesToStacks(string[] crates)
        {
            for (int i = 0; i < crates.Length; i++)
            {
                if (string.IsNullOrEmpty(crates[i].Trim()) == false)
                {
                    stacks.ElementAt(i).AddCreate(crates[i].Trim()[0]);
                }
            }
        }

        private bool LineHasCrateNumbers(string line)
        {
            return char.IsDigit(line.Trim()[0]);
        }

        private string[] GetCrates(string line)
        {
            string newline = new(line.Replace("[", " ").Replace("]", " "));
            List<string> crates = new();
            for (int i = 0; i < newline.Length - 2; i += 4)
            {
                crates.Add(newline.Substring(i, 3));
            }

            return crates.ToArray();
        }

        private List<Stack> CreateEmptyStacks(string line)
        {
            int numberOfStacks = GetCrates(line).Count();

            List<Stack> stacks = new();
            while (numberOfStacks > 0)
            {
                stacks.Add(new Stack());
                numberOfStacks--;
            }

            return stacks;
        }
    }
}
