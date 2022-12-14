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

        public void MoveCrates9001()
        {
            List<string> commandLines = GetCommandLines();

            foreach (string command in commandLines)
            {
                ProcessCommand9001(command);
            }
        }

        private void ProcessCommand9001(string command)
        {
            int numberOfCratesToMove;
            Stack fromStack, toStack;
            ExtractCommand(command, out numberOfCratesToMove, out fromStack, out toStack);

            Stack<char> tempStack = new();

            while (numberOfCratesToMove > 0)
            {
                char crate = fromStack.RemoveCrate();
                tempStack.Push(crate);
                numberOfCratesToMove--;
            }

            while (tempStack.Count != 0)
            {
                char crate = tempStack.Pop();
                toStack.AddCreate(crate);
            }
        }

        private void ExtractCommand(string command, out int numberOfCratesToMove, out Stack fromStack, out Stack toStack)
        {
            numberOfCratesToMove = int.Parse(command.Split(' ')[1]);
            int fromStackIndex = int.Parse(command.Split(' ')[3]) - 1;
            int toStackIndex = int.Parse(command.Split(' ')[5]) - 1;
            fromStack = stacks.ElementAt(fromStackIndex);
            toStack = stacks.ElementAt(toStackIndex);
        }

        public void MoveCrates9000()
        {
            List<string> commandLines = GetCommandLines();

            foreach (string command in commandLines)
            {
                ProcessCommand9000(command);
            }
        }

        private List<string> GetCommandLines()
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

            return commandLines;
        }

        private void ProcessCommand9000(string command)
        {
            int numberOfCratesToMove;
            Stack fromStack, toStack;
            ExtractCommand(command, out numberOfCratesToMove, out fromStack, out toStack);
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
