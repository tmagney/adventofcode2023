namespace AdventOfCode2023
{

    public class Day1: Day
    {
        private IList<string> input = new List<string>();

        private IList<string> digits = new List<string>(){"one", "two", "three", "four", "five",
            "six", "seven", "eight", "nine"};
        public Day1(bool isTest) : base(isTest)
        {
            input = text.Split(Environment.NewLine).ToList();
        }

        public override string GetFirstResult() {
            long total = 0;
            var values = new List<long>();

            foreach(string line in input)
            {
                
                var first = getFirstCoordinate(line);
                var second = getSecondCoordinate(line);

                values.Add(long.Parse(first + second));

                Console.WriteLine(line + " = " + values.Last());
            }

            total = values.Sum();
            Console.WriteLine(total);
            return total.ToString();
        } 

        public override string GetSecondResult() {

            int total = 0;
            var values = new List<int>();

            foreach(string line in input)
            {
                
                var first = getFirstCoordinate(line);
                var second = getSecondCoordinate(line);

                int coordinate = int.Parse(getCoordinate(first,second));
                values.Add(coordinate);

                Console.WriteLine(line + " = " + first + "|" + second);
            }           
            
            total = values.Sum();
            Console.WriteLine(total);
            return total.ToString();
        }


        private string getFirstCoordinate(string line)
        {           
            var number = string.Empty;
            for (int i = 0; i < line.Length; i++)
            {
                var c = line.ToCharArray()[i];
                
                if(char.IsDigit(c))
                {
                    number += c;    
                    i = line.Length;
                } else {
                    foreach(var digit in digits)
                    {
                        if(line.Substring(i).StartsWith(digit))
                        {
                            number = digit;
                            i = line.Length;
                        }
                    }
                }
            }

            return number;
        }

        private string getSecondCoordinate(string line)
        {
            var number = string.Empty;
            for (int i = line.Length - 1; i > -1; i--)
            {
                var c = line.ToCharArray()[i];
                
                if(char.IsDigit(c))
                {
                    number += c;     
                    i = 0;
                } else{
                    foreach(var digit in digits)
                    {
                        if(line.Substring(i).StartsWith(digit))
                        {
                            number = digit;
                            i = 0;
                            break;
                        }
                    }
                }
            }

            return number;        
        }

        private string getCoordinate(string first, string second)
        {
            var coordinate = string.Empty;

            int i = -1;
            
            var isDigit = int.TryParse(first, out i);
                  
            if(isDigit)
            {
                coordinate += i.ToString();
            }
            else{
                coordinate += getNumberFromText(first);
            }

            isDigit = int.TryParse(second, out i);

            if(isDigit)
            {
                coordinate += i.ToString();
            }
            else{
                coordinate += getNumberFromText(second);
            }

            return coordinate;
        }

        private string getNumberFromText(string number)
        {
            var digit = string.Empty;

            switch(number)
            {
                case "one":
                    digit = "1";
                    break;
                case "two":
                    digit = "2";
                    break;
                case "three":
                    digit = "3";
                    break;
                case "four":
                    digit = "4";
                    break;
                case "five":
                    digit = "5";
                    break;
                case "six": 
                    digit = "6";
                    break;
                case "seven":
                    digit = "7";
                    break;
                case "eight":
                    digit = "8";
                    break;
                case "nine":
                    digit = "9";
                    break;
            }

            return digit;
        }
    }
}
