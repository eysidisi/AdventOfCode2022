using AdventOfCode2022Tests.Day11;

namespace AdventOfCode2022Solutions.Day11.Operations
{
    public abstract class Operation
    {
        public int Number { get; private set; }

        protected Operation(int number)
        {
            Number = number;
        }

        protected Operation()
        {

        }

        public static Operation Create(string line)
        {
            string[] operationStrings = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (operationStrings.Last() == "old")
            {
                return new Square();
            }

            int number = int.Parse(operationStrings.Last());

            if (operationStrings[operationStrings.Length - 2] == "*")
                return new Multiplication(number);
            else if (operationStrings[operationStrings.Length - 2] == "+")
                return new Sum(number);

            throw new ArgumentException("Unknown Argument!");
        }

        abstract public long Execute(long itemValue);
    }
}
