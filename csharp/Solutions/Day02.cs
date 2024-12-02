using AdventOfCode.InputFiles;

namespace AdventOfCode.Solutions
{
    public static class Day02
    {
        private const int Day = 2;

        public static class Part1
        {
            public static double GetAnswer()
            {
                string[] inputData = InputCache.Get(Day);
                return Shared.Result(inputData);
            }
        }

        public static class Part2
        {
            public static double GetAnswer()
            {
                string[] inputData = InputCache.Get(Day);
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

                    var levels = set[i].Split(' ');
                    if (IsSafe(levels, -1))
                    {
                        result += 1;
                    }
                    else if (partTwo)
                    {
                        for (int e = 0; e < levels.Length; e++)
                        {
                            if (IsSafe(levels, e))
                            {
                                result += 1;
                                break;
                            }
                        }
                    }
                }
                return result;
            }

            public static bool IsSafe(string[] set, int ignoreOrdinal)
            {
                const int Tolerance = 3;
                var newSet = set.Where((value, index) => index != ignoreOrdinal).ToArray();
                bool ascending = true;
                bool descending = true;
                for (int i = 0; i < newSet.Length - 1; i++)
                {
                    var diff = Convert.ToInt32(newSet[i]) - Convert.ToInt32(newSet[i + 1]);
                    if (diff < 1 || diff > Tolerance)
                    {
                        ascending = false;
                        break;
                    }
                }
                for (int i = 0; i < newSet.Length - 1; i++)
                {
                    var diff = Convert.ToInt32(newSet[i]) - Convert.ToInt32(newSet[i + 1]);
                    if (diff > -1 || diff < Tolerance * -1)
                    {
                        descending = false;
                        break;
                    }
                }
                return ascending || descending;
            }
        }
    }
}
