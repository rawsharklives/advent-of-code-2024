using AdventOfCode.Solutions;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("local.settings.json")
                .Build();

            string session = config["session"];

            if (!await DownloadPuzzleInputs(session, 2024, DateTime.Now.Day))
            {
                Console.WriteLine("No puzzle inputs available just yet - check dates and session in local.settings.json!");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"Day 1 - Part One Answer: {Day01.Part1.GetAnswer()}");
            Console.WriteLine($"Day 1 - Part Two Answer: {Day01.Part2.GetAnswer()}");
            Console.WriteLine("----------------------------------------------------------------------");

            //Console.WriteLine($"Day 2 - Part One Answer: {Day02.Part1.GetAnswer()}");
            //Console.WriteLine($"Day 2 - Part Two Answer: {Day02.Part2.GetAnswer()}");
            //Console.WriteLine("----------------------------------------------------------------------");

            //Console.WriteLine($"Day 3 - Part One Answer: {Day03.Part1.GetAnswer()}");
            //Console.WriteLine($"Day 3 - Part Two Answer: {Day03.Part2.GetAnswer()}");
            //Console.WriteLine("----------------------------------------------------------------------");

            //Console.WriteLine($"Day 4 - Part One Answer: {Day04.Part1.GetAnswer()}");
            //Console.WriteLine($"Day 4 - Part Two Answer: {Day04.Part2.GetAnswer()}");
            //Console.WriteLine("----------------------------------------------------------------------");

            //Console.WriteLine($"Day 5 - Part One Answer: {Day05.Part1.GetAnswer()}");
            //Console.WriteLine($"Day 5 - Part Two Answer: {Day05.Part2.GetAnswer()}");
            //Console.WriteLine("----------------------------------------------------------------------");

            //Console.WriteLine($"Day 6 - Part One Answer: {Day06.Part1.GetAnswer()}");
            //Console.WriteLine($"Day 6 - Part Two Answer: {Day06.Part2.GetAnswer()}");
            //Console.WriteLine("----------------------------------------------------------------------");

            //Console.WriteLine($"Day 7 - Part One Answer: {Day07.Part1.GetAnswer()}");
            //Console.WriteLine($"Day 7 - Part Two Answer: {Day07.Part2.GetAnswer()}");
            //Console.WriteLine("----------------------------------------------------------------------");

            //Console.WriteLine($"Day 8 - Part One Answer: {Day08.Part1.GetAnswer()}");
            //Console.WriteLine($"Day 8 - Part Two Answer: {Day08.Part2.GetAnswer()}");
            //Console.WriteLine("----------------------------------------------------------------------");

            //Console.WriteLine($"Day 9 - Part One Answer: {Day09.Part1.GetAnswer()}");
            //Console.WriteLine($"Day 9 - Part Two Answer: {Day09.Part2.GetAnswer()}");
            //Console.WriteLine("----------------------------------------------------------------------");

            //Console.WriteLine($"Day 10 - Part One Answer: {Day10.Part1.GetAnswer()}");
            //Console.WriteLine($"Day 10 - Part Two Answer: {Day10.Part2.GetAnswer()}");
            //Console.WriteLine("----------------------------------------------------------------------");

            //Console.WriteLine($"Day 11 - Part One Answer: {Day11.Part1.GetAnswer()}");
            //Console.WriteLine($"Day 11 - Part Two Answer: {Day11.Part2.GetAnswer()}");
            //Console.WriteLine("----------------------------------------------------------------------");

            //Console.WriteLine($"Day 12 - Part One Answer: {Day12.Part1.GetAnswer()}");
            //Console.WriteLine($"Day 12 - Part Two Answer: {Day12.Part2.GetAnswer()}");
            //Console.WriteLine("----------------------------------------------------------------------");

            //Console.WriteLine($"Day 13 - Part One Answer: {Day13.Part1.GetAnswer()}");
            //Console.WriteLine($"Day 13 - Part Two Answer: {Day13.Part2.GetAnswer()}");
            //Console.WriteLine("----------------------------------------------------------------------");

            //Console.WriteLine($"Day 14 - Part One Answer: {Day14.Part1.GetAnswer()}");
            //Console.WriteLine($"Day 14 - Part Two Answer: {Day14.Part2.GetAnswer()}");
            //Console.WriteLine("----------------------------------------------------------------------");

            //Console.WriteLine($"Day 15 - Part One Answer: {Day15.Part1.GetAnswer()}");
            //Console.WriteLine($"Day 15 - Part Two Answer: {Day15.Part2.GetAnswer()}");
            //Console.WriteLine("----------------------------------------------------------------------");

            //Console.WriteLine($"Day 16 - Part One Answer: {Day16.Part1.GetAnswer()}");
            //Console.WriteLine($"Day 16 - Part Two Answer: {Day16.Part2.GetAnswer()}");
            //Console.WriteLine("----------------------------------------------------------------------");

            //Console.WriteLine($"Day 17 - Part One Answer: {Day17.Part1.GetAnswer()}");
            //Console.WriteLine($"Day 17 - Part Two Answer: {Day17.Part2.GetAnswer()}");
            //Console.WriteLine("----------------------------------------------------------------------");

            //Console.WriteLine($"Day 18 - Part One Answer: {Day18.Part1.GetAnswer()}");
            //Console.WriteLine($"Day 18 - Part Two Answer: {Day18.Part2.GetAnswer()}");
            //Console.WriteLine("----------------------------------------------------------------------");

            //Console.WriteLine($"Day 19 - Part One Answer: {Day19.Part1.GetAnswer()}");
            //Console.WriteLine($"Day 19 - Part Two Answer: {Day19.Part2.GetAnswer()}");
            //Console.WriteLine("----------------------------------------------------------------------");

            //Console.WriteLine($"Day 20 - Part One Answer: {Day20.Part1.GetAnswer()}");
            //Console.WriteLine($"Day 20 - Part Two Answer: {Day20.Part2.GetAnswer()}");
            //Console.WriteLine("----------------------------------------------------------------------");

            //Console.WriteLine($"Day 21 - Part One Answer: {Day21.Part1.GetAnswer()}");
            //Console.WriteLine($"Day 21 - Part Two Answer: {Day21.Part2.GetAnswer()}");
            //Console.WriteLine("----------------------------------------------------------------------");

            //Console.WriteLine($"Day 22 - Part One Answer: {Day22.Part1.GetAnswer()}");
            //Console.WriteLine($"Day 22 - Part Two Answer: {Day22.Part2.GetAnswer()}");
            //Console.WriteLine("----------------------------------------------------------------------");

            //Console.WriteLine($"Day 23 - Part One Answer: {Day23.Part1.GetAnswer()}");
            //Console.WriteLine($"Day 23 - Part Two Answer: {Day23.Part2.GetAnswer()}");
            //Console.WriteLine("----------------------------------------------------------------------");

            //Console.WriteLine($"Day 24 - Part One Answer: {Day24.Part1.GetAnswer()}");
            //Console.WriteLine($"Day 24 - Part Two Answer: {Day24.Part2.GetAnswer()}");
            //Console.WriteLine("----------------------------------------------------------------------");

            //Console.WriteLine($"Day 25 - Part One Answer: {Day25.Part1.GetAnswer()}");
            //Console.WriteLine($"Day 25 - Part Two Answer: {Day25.Part2.GetAnswer()}");
            //Console.WriteLine("----------------------------------------------------------------------");

            _ = Console.ReadKey();
        }

        private static async Task<bool> DownloadPuzzleInputs(string session, int year = 2024, int todaysDay = 1)
        {
            var puzzleFoundInCache = false;
            var puzzleDownloaded = false;

            if (DateTime.Now.Year != year || DateTime.Now.Month != 12)
            {
                return false; // It's not December in the correct year!
            }

            using HttpClient httpClient = new();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("Cookie", $"session={session}");

            for (int day = 1; day <= todaysDay; day++)
            {
                if (AlreadyDownloaded(day))
                {
                    puzzleFoundInCache = true;
                    Console.WriteLine($"Puzzle Input verified in [cache] - Day {day}");
                    continue;
                }

                string url = $"https://adventofcode.com/{year}/day/{day}/input";
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    puzzleDownloaded = true;

                    string input = await response.Content.ReadAsStringAsync();

                    File.WriteAllText(GetDayFilePath(day), input);

                    // Also write out to a NTestFile.txt which we can
                    // manually add the Test example data to afterwards

                    if (!AlreadyDownloaded(day, true))
                    {
                        File.WriteAllText(GetDayFilePath(day, true), input);
                    }
                    Console.WriteLine($"Puzzle Input added to [cache] - Day {day}");
                }
            }
            Console.WriteLine("----------------------------------------------------------------------");
            
            return puzzleDownloaded || puzzleFoundInCache;
        }

        private static bool AlreadyDownloaded(int day, bool useTestFile = false)
        {
            return File.Exists(GetDayFilePath(day, useTestFile));
        }

        public static string GetDayFilePath(int day, bool useTestFile = false)
        {
            string testFileName = useTestFile ? "TestFile" : string.Empty;
            return $@"{Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent}\InputFiles\{day:00}{testFileName}.txt";
        }
    }
}
