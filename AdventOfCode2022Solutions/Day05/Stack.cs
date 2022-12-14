using System.Collections.ObjectModel;

namespace AdventOfCode2022Tests.Day05
{
    public class Stack
    {
        Stack<char> crates = new();

        public char TopCrate
        {
            get
            {
                return crates.Peek();
            }
        }
        public void Reverse()
        {
            crates = new Stack<char>(crates);
        }

        public void AddCreate(char create)
        {
            crates.Push(create);
        }

        public void MoveCratesToOtherStack(int numberOfCreates, Stack otherStack)
        {
            while (numberOfCreates > 0)
            {
                char topCreate = crates.Pop();
                otherStack.AddCreate(topCreate);
                numberOfCreates--;
            }
        }

        public ReadOnlyCollection<char> Crates()
        {
            return new ReadOnlyCollection<char>(crates.ToList());
        }

        internal char RemoveCrate()
        {
            return crates.Pop();
        }
    }
}
