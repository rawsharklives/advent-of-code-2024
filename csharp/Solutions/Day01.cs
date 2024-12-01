using AdventOfCode.InputFiles;
using System.Linq;

namespace AdventOfCode.Solutions
{
    public static class Day01
    {
        private const int Day = 1;

        public static class Part1
        {
            public static double GetAnswer()
            {
                string[] inputData = InputCache.Get(Day, false);
                return Shared.Result(inputData);
            }
        }

        public static class Part2
        {
            public static double GetAnswer()
            {
                string[] inputData = InputCache.Get(Day, false);
                return Shared.Result(inputData, true);
            }
        }

        private class Shared
        {
            public static double Result(string[] set, bool partTwo = false)
            {
                var result = 0d;

                var lhs = new List<int>();
                var rhs = new List<int>();

                for (int i = 0; i < set.Length; i++)
                {
                    if (set[i].Trim() == string.Empty)
                    {
                        continue;
                    }
                    var pairs = set[i].Split("   ");
                    lhs.Add(Convert.ToInt32(pairs[0]));
                    rhs.Add(Convert.ToInt32(pairs[1]));
                }

                if (!partTwo)
                {
                    lhs.Sort();
                    rhs.Sort();

                    foreach (var (lValue, rValue) in lhs.Zip(rhs, (a, b) => (a, b)))
                    {
                        result += Math.Abs(lValue - rValue);
                    }
                }
                else
                {
                    foreach(var value in lhs)
                    {
                        result += value * rhs.Count(v => v == value);
                    }
                }

                return result;
            }
        }
    }
}
