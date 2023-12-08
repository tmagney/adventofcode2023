using System.Globalization;
using System.Reflection.Metadata;

namespace AdventOfCode2023
{

    public class Day2: Day
    {
        private IList<string> input = new List<string>();

        private IList<Game> games = new List<Game>();

        public Day2(bool isTest) : base(isTest)
        {
            input = text.Split(Environment.NewLine).ToList();
        }

        public override string GetFirstResult() {
            var sum = 0;
            foreach(var line in input)
            {
                games.Add(new Game(line));
                sum = games.Where(x => x.possible).Sum(x => Convert.ToInt16(x.number));
                // var game = new Game(line);

                // if(game.reds <= redLimit && game.greens <= greenLimit && game.blues <= blueLimit)
                // {
                //     Console.WriteLine("Possible game: " + game.number);
                //     sum += game.number;
                // }
                // else{
                //     Console.WriteLine("Impossible game: " + game.number + " red: " + game.reds + 
                //         " green: " + game.greens + " blue: " + game.blues);
                // }
            }
            
            return sum.ToString();
        } 

        public override string GetSecondResult() {
            return "";
        }
    }

    internal class Game
    {
        private const int redLimit = 12;
        private const int greenLimit = 13;
        private const int blueLimit = 14;

        internal int number = 0;

        internal bool possible = false;

        internal Game(string line){
            number = Convert.ToInt32(line.Split(":").First().Split(" ").Last());

            var red = 0;
            var green = 0;
            var blue = 0;

            foreach(var colors in line.Split(":").Last().Split(";"))
            {
                // reds += colors.Contains("red") ? Convert.ToInt32(colors.Split(" red").First().Split(" ").Last()) : 0;
                // greens += colors.Contains("green") ? Convert.ToInt32(colors.Split(" green").First().Split(" ").Last()) : 0;
                // blues += colors.Contains("blue") ? Convert.ToInt32(colors.Split(" blue").First().Split(" ").Last()) : 0;
            
                red = colors.Contains("red") ? Convert.ToInt32(colors.Split(" red").First().Split(" ").Last()) : 0;
                green = colors.Contains("green") ? Convert.ToInt32(colors.Split(" green").First().Split(" ").Last()) : 0;
                blue = colors.Contains("blue") ? Convert.ToInt32(colors.Split(" blue").First().Split(" ").Last()) : 0;

                if(red <= redLimit && green <= greenLimit && blue <= blueLimit)
                {
                    Console.WriteLine("Possible game: " + number);
                    possible = true;
                }
                else{
                    Console.WriteLine("Impossible game: " + number + " red: " + red + 
                        " green: " + green + " blue: " + blue);
                    possible = false;
                    break;
                }
            }
        }
    }
}
