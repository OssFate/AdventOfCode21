namespace AdventOfCode21.Day;

public class Day02Two : Template
{
    protected override void FirstProblem(string[] lines)
    {
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

    protected override void SecondProblem(string[] lines)
    {
        var pAcc = 0;
        var dAcc = 0;
        var aAcc = 0;

        foreach (var line in lines)
        {
            var command = line.Split(" ");

            switch (command[0])
            {
                case "forward":
                    var x = int.Parse(command[1]);
                    pAcc += x;
                    dAcc += aAcc * x;
                    break;
                case "down":
                    aAcc += int.Parse(command[1]);
                    break;
                case "up":
                    aAcc -= int.Parse(command[1]);
                    break;
            }
        }

        var result = pAcc * dAcc;

        Console.WriteLine($"Planned course total result is: {result}");
    }
}
