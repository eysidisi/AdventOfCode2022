﻿using AdventOfCode2022Solutions.Day11.Operations;

namespace AdventOfCode2022Tests.Day11
{
    public class Sum : Operation
    {
        public Sum(int number) : base(number) { }

        public override int Execute(int itemValue)
        {
            return Number + itemValue;
        }
    }
}
