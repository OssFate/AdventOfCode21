namespace AdventOfCode21.Day;

public class Day04Four : Template
{
    protected override void FirstProblem(string[] lines)
    {
        var boards = new List<Bingo>();
        var boardValues = new List<string>();

        var ballots = lines[0].Split(",");

        for(var i = 2; i < lines.Length; i++)
        {
            if (!string.IsNullOrEmpty(lines[i]))
            {
                boardValues.Add(lines[i]);
            }
            else
            {
                boards.Add(new Bingo(boardValues.ToArray()));
                boardValues = new List<string>();
            }
        }

        var (result, ballot) = PlayToWinBingo(boards, ballots);

        Console.WriteLine($"First Bingo: {result} on Ballot: {ballot}");
    }

    protected override void SecondProblem(string[] lines)
    {
        var boards = new List<Bingo>();
        var boardValues = new List<string>();

        var ballots = lines[0].Split(",");

        for (var i = 2; i < lines.Length; i++)
        {
            if (!string.IsNullOrEmpty(lines[i]))
            {
                boardValues.Add(lines[i]);
            }
            else
            {
                boards.Add(new Bingo(boardValues.ToArray()));
                boardValues = new List<string>();
            }
        }

        var (result, ballot) = PlayToLoseBingo(boards, ballots);

        Console.WriteLine($"Last Bingo: {result} on Ballot: {ballot}");
    }

    private static (int, string) PlayToLoseBingo(List<Bingo> boards, string[] ballots)
    {
        var boardNum = boards.Count;

        foreach (var ballot in ballots)
            foreach (var board in boards)
            {
                if (board.IsWinner) continue;
                
                var result = board.PlayBallot(ballot);
                
                if (result <= 0) continue;
                if (boardNum <= 1) return (result, ballot);
                
                board.IsWinner = true;
                boardNum--;
            }

        return (-1, "LUL");
    }

    private static (int , string) PlayToWinBingo(List<Bingo> boards, string[] ballots)
    {
        foreach (var ballot in ballots)
            foreach (var board in boards)
            {
                var result = board.PlayBallot(ballot);
                if (result > 0)
                    return (result, ballot);
            }

        return (-1, "LUL");
    }

    private class Bingo
    {
        private readonly string[][] _board;
        private readonly bool[,] _playBoard;
        public bool IsWinner;

        public Bingo(string[] input)
        {
            _board = new string[5][];
            _playBoard = new bool[5, 5];

            for (var i = 0; i < input.Length; i++)
            {
                var row = input[i].Trim().Replace("  ", " ").Split(" ");
                _board[i] = row;
            }
        }

        public int PlayBallot(string ballot)
        {
            var (x, y) = FindCoordinate(ballot);
            if (x + y < 0) return -1;
            
            if (IsBingo(x, y))
                return SumUnmarked() * int.Parse(ballot);

            return -1;
        }

        private int SumUnmarked()
        {
            var sum = 0;

            for(var i = 0; i < _board.Length; i++)
                for(var j = 0; j < _board[0].Length; j++)
                    if(!_playBoard[i, j])
                        sum += int.Parse(_board[i][j]);

            return sum;
        }

        private bool IsBingo(int x, int y)
        {
            var isRowBingo = true;
            var isColBingo = true;

            for (var i = 0; i < _board.Length; i++)
                if(!_playBoard[x, i])
                {
                    isColBingo = false;
                    break;
                }

            for (var i = 0; i < _board.Length; i++)
                if (!_playBoard[i, y])
                {
                    isRowBingo = false;
                    break;
                }

            return isRowBingo || isColBingo;
        }

        private (int, int) FindCoordinate(string ballot)
        {
            for (var i = 0; i < _board.Length; i++)
            {
                for (var j = 0; j < _board[i].Length; j++)
                {
                    if (_board[i][j] != ballot) continue;
                    
                    _playBoard[i, j] = true;
                    return (i, j);
                }
            }

            return (-1, -1);
        }
    }
}
