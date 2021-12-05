namespace AdventOfCode21;

public class Day04_Four : Template
{
    protected override void FirstProblem(string[] lines)
    {
        var boards = new List<Bingo>();
        var boardValues = new List<string>();

        var ballots = lines[0].Split(",");

        for(int i = 2; i < lines.Length; i++)
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

        for (int i = 2; i < lines.Length; i++)
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

    private (int, string) PlayToLoseBingo(List<Bingo> boards, string[] ballots)
    {
        var boardNum = boards.Count;

        foreach (var ballot in ballots)
            foreach (var board in boards)
            {
                if (!board.isWinner)
                {
                    var result = board.PlayBallot(ballot);
                    if(result > 0)
                    {
                        if(boardNum > 1)
                        {
                            board.isWinner = true;
                            boardNum--;
                            continue;
                        }

                        return (result, ballot);
                    }
                }
            }

        return (-1, "LUL");
    }

    private (int , string) PlayToWinBingo(List<Bingo> boards, string[] ballots)
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

    internal class Bingo
    {
        private string[][] Board;
        private bool[,] playBoard;
        public bool isWinner = false;

        public Bingo(string[] input)
        {
            Board = new string[5][];
            playBoard = new bool[5, 5];

            for (int i = 0; i < input.Length; i++)
            {
                var row = input[i].Trim().Replace("  ", " ").Split(" ");
                Board[i] = row;
            }
        }

        public int PlayBallot(string ballot)
        {
            var (x, y) = FindCoordinate(ballot);
            if (x + y >= 0)
                if (IsBingo(x, y))
                    return SumUnmarked() * int.Parse(ballot);

            return -1;
        }

        private int SumUnmarked()
        {
            var sum = 0;

            for(int i = 0; i < Board.Length; i++)
                for(int j = 0; j < Board[0].Length; j++)
                    if(!playBoard[i, j])
                        sum += int.Parse(Board[i][j]);

            return sum;
        }

        private bool IsBingo(int x, int y)
        {
            var isRowBingo = true;
            var isColBingo = true;
            var isDiaLRBingo = false;
            var isDiaRLBingo = false;

            //if (x == y)
            //{
            //    isDiaLRBingo = true;
            //    for (int i = 0; i < Board.Length; i++)
            //        if (!playBoard[i, i])
            //        {
            //            isDiaLRBingo = false;
            //            break;
            //        }
            //}

            //if (x + y == 4)
            //{
            //    isDiaRLBingo = true;
            //    for (int i = 0; i < Board.Length; i++)
            //        if (!playBoard[i, Board.Length - 1 - i])
            //        {
            //            isDiaRLBingo = false;
            //            break;
            //        }
            //}


            for (int i = 0; i < Board.Length; i++)
                if(!playBoard[x, i])
                {
                    isColBingo = false;
                    break;
                }

            for (int i = 0; i < Board.Length; i++)
                if (!playBoard[i, y])
                {
                    isRowBingo = false;
                    break;
                }

            return isRowBingo || isColBingo || isDiaLRBingo || isDiaRLBingo;
        }

        private (int, int) FindCoordinate(string ballot)
        {
            for (int i = 0; i < Board.Length; i++)
            {
                for (var j = 0; j < Board[i].Length; j++)
                {
                    if (Board[i][j] == ballot)
                    {
                        playBoard[i, j] = true;
                        return (i, j);
                    }
                }
            }

            return (-1, -1);
        }
    }
}
