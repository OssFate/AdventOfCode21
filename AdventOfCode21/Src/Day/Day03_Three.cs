﻿namespace AdventOfCode21;

public class Day03_Three : Template
{
    protected override void FirstProblem(string[] lines)
    {
        var lineAmmount = lines.Length;

        var bitsNum = new int[lines[0].Length];

        foreach (var line in lines)
        {
            for(var i = 0; i < line.Length; i++)
                bitsNum[i] += line[i] == '1' ? 1 : 0;
        }

        var bitsGamma = new string[lines[0].Length];
        var bitsEpsilon = new string[lines[0].Length];

        for (var j = 0; j < lines[0].Length; j++)
        {
            var flag = bitsNum[j] > lineAmmount / 2;
            bitsGamma[j] = flag ? "1" : "0";
            bitsEpsilon[j] = flag ? "0" : "1";
        }

        var gamma = Convert.ToInt32(string.Concat(bitsGamma), 2);
        var epsilon = Convert.ToInt32(string.Concat(bitsEpsilon), 2);
        var result = gamma * epsilon;

        Console.WriteLine($"Submarine power consumption is: {result}");
    }

    protected override void SecondProblem(string[] lines)
    {
        var bitsO2 = FindThatO2(lines, 0);
        var bitsOther = FindThatOther(lines, 0);

        var o2 = Convert.ToInt32(bitsO2, 2);
        var other = Convert.ToInt32(bitsOther, 2);
        var result = o2 * other;

        Console.WriteLine($"Submarine life support rating is: {result}");
    }

    private string FindThatO2(string[] array, int index)
    {
        if(array.Length == 1)
            return array[0];

        var o2One = new List<string>();
        var o2Zero = new List<string>();

        foreach (var line in array)
        {
            if (!string.IsNullOrEmpty(line))
            {
                if (line[index] == '1')
                    o2One.Add(line);
                else
                    o2Zero.Add(line);
            }
        }

        if (o2One.Count >= o2Zero.Count)
            return FindThatO2(o2One.ToArray(), index + 1);

        return FindThatO2(o2Zero.ToArray(), index + 1);
    }

    private string FindThatOther(string[] array, int index)
    {
        if (array.Length == 1)
            return array[0];

        var o2One = new List<string>();
        var o2Zero = new List<string>();

        foreach (var line in array)
        {
            if (!string.IsNullOrEmpty(line))
            {
                if (line[index] == '0')
                    o2Zero.Add(line);
                else
                    o2One.Add(line);
            }
        }

        if (o2Zero.Count <= o2One.Count)
            return FindThatOther(o2Zero.ToArray(), index + 1);

        return FindThatOther(o2One.ToArray(), index + 1);
    }
}
