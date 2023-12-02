namespace AdventOfCode2023
{

    public class Day1: Day
    {
        private IList<string> input = new List<string>();
        public Day1(bool isTest) : base(isTest)
        {
            input = text.Split(Environment.NewLine).ToList();
        }

        public override string GetFirstResult() {
            long total = 0;
            var values = new List<long>();

            foreach(string line in input)
            {
                
                var first = getFirstNumberAsString(line);
                var second = getSecondNumberAsString(line);

                values.Add(long.Parse(first + second));

                Console.WriteLine(line + " = " + values.Last());
            }

            total = values.Sum();
            Console.WriteLine(total);
            return total.ToString();
        }

        public override string GetSecondResult() {
            return string.Empty;
        }


        private string getFirstNumberAsString(string line)
        {           
            var number = string.Empty;
            for (int i = 0; i < line.Length; i++)
            {
                var c = line.ToCharArray()[i];
                
                if(char.IsDigit(c))
                {
                    //number += c;
                    number += c;    
                    i = line.Length;
                }
                // else if(number != string.Empty)
                // {
                //     i = line.Length;
                // }
            }

            return number;
        }

        private string getSecondNumberAsString(string line)
        {
            var number = string.Empty;
            for (int i = line.Length - 1; i > -1; i--)
            {
                var c = line.ToCharArray()[i];
                
                if(char.IsDigit(c))
                {
                    number += c;     
                    i = 0;
                }

                // else if(number != string.Empty)
                // {
                //     i = 0;
                // }
            }

            return new String(number.Reverse().ToArray());        
        }
    }
}
