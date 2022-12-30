namespace AdventOfCode2022Tests.Day11
{
    public class Round
    {
        private List<Monkey> monkeys;

        public Round(List<Monkey> monkeys)
        {
            this.monkeys = monkeys;
        }

        public void Turn()
        {
            foreach (Monkey monkey in monkeys)
            {
                while (monkey.ItemValues.Count != 0)
                {
                    Item item = monkey.Throw();
                    Monkey monkeyToGetItem = monkeys.Find(m => m.Id == item.MonkeyToThrow);
                    monkeyToGetItem.AddItem(item.Value);
                }
            }
        }
    }
}
