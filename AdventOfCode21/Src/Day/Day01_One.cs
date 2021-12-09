namespace AdventOfCode21.Day;

public class Day01One : Template
{
    protected override void FirstProblem(string[] lines)
    {
        var acc = 0;
        var prev = int.MaxValue;

        foreach (var line in lines)
        {
            var parsed = int.TryParse(line, out var current);
            if (parsed && current > prev)
                acc++;

            prev = current;
        }

        Console.WriteLine($"The amount of measurements larger than the previous one are: {acc}.");
    }

    protected override void SecondProblem(string[] lines)
    {
        var numLines = new List<int>();
        lines.ToList().ForEach(l =>
        {
            var parsed = int.TryParse(l, out var num);
            if (parsed)
                numLines.Add(num);
        });
    
        var acc = 0;
        var prev = int.MaxValue;
    
        for (var i = 0; i < numLines.Count - 2; i++)
        {
            var current = numLines[i] + numLines[i + 1] + numLines[i + 2];
            if (current > prev)
                acc++;
    
            prev = current;
        }
    
        Console.WriteLine($"The amount of sums larger than the previous sum are: {acc}.");
    }

    // Some code from someone on github
    // https://github.com/KristofferStrube/AoC2021.NET6
    // protected override void SecondProblem(string[] lines)
    // {
    //     var result = lines
    //         .TakeWhile(l => !l.Equals(string.Empty))
    //         .Select(int.Parse)
    //         .Aggregate(
    //             (fst: int.MaxValue, snd: int.MaxValue, trd: int.MaxValue, num: 0),
    //             (acc, curr) =>
    //             {
    //                 acc.num += acc.snd + acc.trd + curr > acc.fst + acc.snd + acc.trd ? 1 : 0;
    //                 (acc.fst, acc.snd, acc.trd) = (acc.snd, acc.trd, curr);
    //                 return acc;
    //             }
    //         ).num;
    //     Console.WriteLine(result);
    // }
}
