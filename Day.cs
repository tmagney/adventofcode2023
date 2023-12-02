namespace AdventOfCode2023
{
    public abstract class Day
    {

        protected string text = String.Empty;

        public Day(bool isTest)
        {
            var filename = isTest ? "day1-test2.txt" : "day1.txt";

            text = File.ReadAllText(Directory.GetCurrentDirectory() + @"\inputs\" + filename);
     
        }

        public abstract string GetFirstResult();

        public abstract string GetSecondResult();
    }
}