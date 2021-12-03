﻿namespace AdventOfCode21;

class Code
{
    public static int WorkToDo(string[] args)
    {
        try
        {
            // For debuging if something is wrong
            //args = new string[] { "one", "../../../Input/input01" };

            var config = new Config(args);

            Console.WriteLine($"Running day: {config.Command}\n");

            var fileText = ReadAllText(config.FilePath);

            return config.Command switch
            {
                var com when com == "one" || com == "1" => new Day01_One().DoWork(fileText),
                var com when com == "two" || com == "2" => new Day02_Two().DoWork(fileText),
                var com when com == "three" || com == "3" => new Day03_Three().DoWork(fileText),
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
