namespace AdventOfCode21
{
    public class One : Template
    {
        protected override void FirstProblem(string input)
        {
            var lines = input.Split('\n');

            Console.WriteLine(lines[0]);
        }

        protected override void SecondProblem(string input)
        {
            Console.WriteLine(input);
        }
    }
}
