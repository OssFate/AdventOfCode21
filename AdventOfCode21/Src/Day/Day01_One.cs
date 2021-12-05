namespace AdventOfCode21;

public class Day01_One : Template
{
    protected override void FirstProblem(string[] lines)
    {
        int acc = 0;
        int prev = int.MaxValue;

        foreach (var line in lines)
        {
            var parsed = int.TryParse(line, out int current);
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
            var parsed = int.TryParse(l, out int num);
            if (parsed)
                numLines.Add(num);
        });

        int acc = 0;
        int prev = int.MaxValue;

        for (int i = 0; i < numLines.Count - 2; i++)
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
    //protected override void SecondProblem(string input)
    //{
    //    var lines = input.Split('\n');
    //    var result = lines
    //        .TakeWhile(l => !l.Equals(string.Empty))
    //        .Select(l => int.Parse(l))
    //        .Aggregate(
    //            (fst: int.MaxValue, snd: int.MaxValue, trd: int.MaxValue, num: 0),
    //            (acc, curr) =>
    //            {
    //                acc.num += acc.snd + acc.trd + curr > acc.fst + acc.snd + acc.trd ? 1 : 0;
    //                (acc.fst, acc.snd, acc.trd) = (acc.snd, acc.trd, curr);
    //                return acc;
    //            }
    //        ).num;
    //    Console.WriteLine(result);
    //}
}
