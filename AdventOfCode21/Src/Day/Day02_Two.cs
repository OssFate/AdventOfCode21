namespace AdventOfCode21;

public class Day02_Two : Template
{
    protected override void FirstProblem(string input)
    {
        var lines = input.Split("\n");

        var pAcc = 0;
        var dAcc = 0;

        foreach(var line in lines)
        {
            var command = line.Split(" ");

            _ = command[0] switch
            {
                "forward" => pAcc += int.Parse(command[1]),
                "down" => dAcc += int.Parse(command[1]),
                "up" => dAcc -= int.Parse(command[1]),
                _ => 0,
            };
        }

        var result = pAcc * dAcc;

        Console.WriteLine($"Planned course total result is: {result}");
    }

    protected override void SecondProblem(string input)
    {
        var lines = input.Split("\n");

        var pAcc = 0;
        var dAcc = 0;
        var aAcc = 0;

        foreach (var line in lines)
        {
            var command = line.Split(" ");

            switch (command[0])
            {
                case "forward":
                    var X = int.Parse(command[1]);
                    pAcc += X;
                    dAcc += aAcc * X;
                    break;
                case "down":
                    aAcc += int.Parse(command[1]);
                    break;
                case "up":
                    aAcc -= int.Parse(command[1]);
                    break;
                default:
                    break;
            };
        }

        var result = pAcc * dAcc;

        Console.WriteLine($"Planned course total result is: {result}");
    }
}
