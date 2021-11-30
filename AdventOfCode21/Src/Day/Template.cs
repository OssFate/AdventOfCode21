namespace AdventOfCode21
{
    public abstract class Template
    {
        protected abstract void FirstProblem(string input);
        protected abstract void SecondProblem(string input);
        public int DoWork(string input)
        {
            Console.WriteLine("\t>> First Problem <<");
            FirstProblem(input);
            Console.WriteLine("\t>> Second Problem <<");
            SecondProblem(input);

            return 0;
        }

        public static int NoneOption()
        {
            Console.WriteLine("None Option!");
            return 1;
        }
    }
}
