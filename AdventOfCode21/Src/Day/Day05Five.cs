using System.Runtime.CompilerServices;

namespace AdventOfCode21.Day;

public class Day05Five : Template
{
    protected override void FirstProblem(string[] lines)
    {
        var coords =
            lines
                .Select(l => l.Split("->"))
                .Select(c => new { coord1 = c[0].Trim().Split(","),  coord2 = c[1].Trim().Split(",") })
                .Select(cc => new VentLine
                {
                    A = (int.Parse(cc.coord1[0]), int.Parse(cc.coord1[1])),
                    B = (int.Parse(cc.coord2[0]), int.Parse(cc.coord2[1]))
                }).ToList();

        var map = new Dictionary<(int, int), int>();

        foreach (var coord in coords)
        {
            var array = coord.GetArray();
            foreach (var c in array)
            {
                var isThere = map.TryGetValue(c, out var value);
                if (isThere)
                    map[c] = value + 1;
                else
                    map.Add(c, 1);
            }
        }

        map.Remove((-1, -1));
        var result = map.Values.Count(v => v > 1);
        
        Console.WriteLine($"Num: {result}");
    }

    protected override void SecondProblem(string[] lines)
    {
        var coords =
            lines
                .Select(l => l.Split("->"))
                .Select(c => new { coord1 = c[0].Trim().Split(","),  coord2 = c[1].Trim().Split(",") })
                .Select(cc => new VentLine
                {
                    A = (int.Parse(cc.coord1[0]), int.Parse(cc.coord1[1])),
                    B = (int.Parse(cc.coord2[0]), int.Parse(cc.coord2[1]))
                }).ToList();

        var map = new Dictionary<(int, int), int>();

        foreach (var coord in coords)
        {
            var array = coord.GetArray(false);
            foreach (var c in array)
            {
                var isThere = map.TryGetValue(c, out var value);
                if (isThere)
                    map[c] = value + 1;
                else
                    map.Add(c, 1);
            }
        }

        map.Remove((-1, -1));
        var result = map.Values.Count(v => v > 1);
        
        Console.WriteLine($"Num: {result}");
    }

    private struct VentLine
    {
        public (int x1, int y1) A;
        public (int x2, int y2) B;

        public (int, int)[] GetArray(bool isOne = true)
        {
            var d = IsColOrRow();
            if(isOne && d > 2) return new[] { (-1, -1) };
            
            switch (d)
            {
                case 1:
                    var f1 = A.y1 < B.y2;
                    var r1 = Enumerable.Range(f1 ? A.y1 : B.y2, (f1 ? B.y2 - A.y1 : A.y1 - B.y2) + 1 );
                    var x = A.x1;
                    return r1.Select(r => (x, r)).ToArray();
                case 2:
                    var f2 = A.x1 < B.x2;
                    var r2 = Enumerable.Range(f2 ? A.x1 : B.x2, (f2 ? B.x2 - A.x1 : A.x1 - B.x2) + 1 );
                    var y = A.y1;
                    return r2.Select(r => (r, y)).ToArray();
                case 3:
                    var f3 = A.x1 < B.x2;
                    var r3 = Enumerable.Range(f3 ? A.x1 : B.x2, (f3 ? B.x2 - A.x1 : A.x1 - B.x2) + 1 );
                    var c = f3 ? A : B;
                    return r3.Select(r => (r, c.Item2 + (r - c.Item1))).ToArray();
                case 4:
                    var f4 = A.x1 < B.x2;
                    var r4 = Enumerable.Range(f4 ? A.x1 : B.x2, (f4 ? B.x2 - A.x1 : A.x1 - B.x2) + 1 );
                    var max = A.x1 + A.y1;
                    return r4.Select(r => (r, max - r)).ToArray();
            }

            return new[] { (-1, -1) };
        }
        
        private int IsColOrRow() =>
            IsRow() switch
            {
                true => 2,
                false => IsCol() switch
                {
                    true => 1,
                    false => IsDiagL() switch
                    {
                        true => 4,
                        false => IsDiagR() switch
                        {
                            true => 3,
                            false => 0
                        }
                    }
                }
            };

        private bool IsCol() => A.x1 == B.x2;
        private bool IsRow() => A.y1 == B.y2;
        private bool IsDiagR() => ((A.y1 - B.y2) / (A.x1 - B.x2)) == 1;
        private bool IsDiagL() => A.x1 + A.y1 == B.x2 + B.y2;
    }
}