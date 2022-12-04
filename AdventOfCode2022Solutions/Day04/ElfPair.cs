namespace AdventOfCode2022Tests.Day04
{
    public class ElfPair
    {
        private Elf elf1;
        private Elf elf2;

        public ElfPair(Elf elf1, Elf elf2)
        {
            this.elf1 = elf1;
            this.elf2 = elf2;
        }

        public bool DoElvesContainEachOther()
        {
            // Find elf with largest range
            Elf elfWithLargestRange = elf1.TotalRange > elf2.TotalRange ? elf1 : elf2;

            return elfWithLargestRange.rangeMinPoint <= elf1.rangeMinPoint &&
                elfWithLargestRange.rangeMinPoint <= elf2.rangeMinPoint &&
                elfWithLargestRange.rangeMaxPoint >= elf1.rangeMaxPoint &&
                elfWithLargestRange.rangeMaxPoint >= elf2.rangeMaxPoint;

        }
    }
}
