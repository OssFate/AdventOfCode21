namespace AdventOfCode21;

class Code
{
    public static int WorkToDo(string[] args)
    {
        try
        {
            // For testing is something is wrong
            //args = new string[] { "one", "../../../Input/input01" };

            var config = new Config(args);

            Console.WriteLine($"Running command: {config.Command}");

            var fileText = ReadAllText(config.FilePath);

            return config.Command switch
            {
                "one" => new Day01_One().DoWork(fileText),
                "two" => new Day02_Two().DoWork(fileText),
                _ => Template.NoneOption(),
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return -1;
        }
    }

    private static string ReadAllText(string filePath)
    {
        return File.ReadAllText(filePath);
    }

}

struct Config
{
    public string Command;
    public string FilePath;

    public Config(string[] args)
    {
        if (args.Length < 2)
            throw new ArgumentException("Not enough arguments, please use this way: \"{day} {file}\"");

        Command = args[0];
        FilePath = args[1];
    }
}
