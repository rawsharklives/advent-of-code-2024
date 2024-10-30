using System.IO;

namespace AdventOfCode.InputFiles
{
    public static class InputCache
    {
        public static string[] Get(int day, bool useTestFile = false)
        {
            // Input Files themselves are ignored in GIT
            return File.ReadAllLines(Program.GetDayFilePath(day, useTestFile));
        }
    }
}
