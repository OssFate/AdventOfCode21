using AdventOfCode21.Day;

namespace AdventOfCode21;

class Code
{
    public static int WorkToDo(string[] args)
    {
        try
        {
            // For debugging if something is wrong
            //args = new string[] { "one", "../../../Input/input01" };

            var config = new Config(args);

            Console.WriteLine($"Running day: {config.Day}\n");

            var fileText = ReadAllLines(config.FilePath);

            return config.Day switch
            {
                "one" or "1" => new Day01One().DoWork(fileText),
                "two" or "2" => new Day02Two().DoWork(fileText),
                "three" or "3" => new Day03Three().DoWork(fileText),
                "four" or "4" => new Day04Four().DoWork(fileText),
                "five" or "5" => new Day05Five().DoWork(fileText),
                _ => Template.NoneOption(),
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return -1;
        }
    }

    private static string[] ReadAllLines(string filePath)
    {
        return File.ReadAllLines(filePath);
    }

}

internal struct Config
{
    public readonly string Day;
    public readonly string FilePath;

    public Config(string[] args)
    {
        if (args.Length < 2)
            throw new ArgumentException("Not enough arguments, please use this way: \"{day} {file}\"");

        Day = args[0];
        FilePath = args[1];
    }
}
