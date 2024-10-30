using AdventOfCode.InputFiles;

namespace AdventOfCode.Solutions
{
    public static class DayNN
    {
        private const int Day = 99;

        public static class Part1
        {
            public static double GetAnswer()
            {
                string[] inputData = InputCache.Get(Day, true);
                return Shared.Result(inputData);
            }
        }

        public static class Part2
        {
            public static double GetAnswer()
            {
                string[] inputData = InputCache.Get(Day, true);
                return Shared.Result(inputData, true);
            }
        }

        private class Shared
        {
            public static double Result(string[] set, bool partTwo = false)
            {
                var result = 0d;
                for (int i = 0; i < set.Length; i++)
                {
                    if (set[i].Trim() == string.Empty)
                    {
                        continue;
                    }
                    result += 1;
                }
                return -1;
            }
        }
    }
}
