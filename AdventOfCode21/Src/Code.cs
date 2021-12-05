namespace AdventOfCode21;

class Code
{
    public static int WorkToDo(string[] args)
    {
        try
        {
            // For debuging if something is wrong
            //args = new string[] { "one", "../../../Input/input01" };

            var config = new Config(args);

            Console.WriteLine($"Running day: {config.Day}\n");

            var fileText = ReadAllLines(config.FilePath);

            return config.Day switch
            {
                var com when com == "one" || com == "1" => new Day01_One().DoWork(fileText),
                var com when com == "two" || com == "2" => new Day02_Two().DoWork(fileText),
                var com when com == "three" || com == "3" => new Day03_Three().DoWork(fileText),
                var com when com == "four" || com == "4" => new Day04_Four().DoWork(fileText),
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

struct Config
{
    public string Day;
    public string FilePath;

    public Config(string[] args)
    {
        if (args.Length < 2)
            throw new ArgumentException("Not enough arguments, please use this way: \"{day} {file}\"");

        Day = args[0];
        FilePath = args[1];
    }
}
