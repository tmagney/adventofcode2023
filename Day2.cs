using System.ComponentModel;
using System.Globalization;
using System.Numerics;
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
                //sum = games.Where(x => x.possible).Sum(x => Convert.ToInt16(x.number));
            }
            
            return sum.ToString();
        } 

        public override string GetSecondResult() {
            var sum = 0;
            foreach(var line in input)
            {
                games.Add(new Game(line));
            }
            
            return games.Sum(x => x.getPower()).ToString();
        }
    }

    internal class Round 
    {
        internal int reds = 0;
        internal int greens = 0;

        internal int blues = 0;

        internal Round(string line)
        {
            //3 blue, 4 red
            foreach(var color in line.Split(", "))
            {
                if(color.Contains("red"))
                {
                    reds = Convert.ToInt32(color.Split(" ").First());
                } else if(color.Contains("green"))
                {
                    greens = Convert.ToInt32(color.Split(" ").First());
                } else if(color.Contains("blue"))
                {
                    blues = Convert.ToInt32(color.Split(" ").First());
                }
            }
        }
    }

    internal class Game
    {
        internal IList<Round> rounds = new List<Round>();

        internal Game(string line){
            //setIsGamePossible(line);
            foreach(var round in line.Split(": ").Last().Split("; "))
            {
                rounds.Add(new Round(round));
            }
        }

        internal int getPower()
        {
            int red = rounds.OrderBy(x => x.reds).Last().reds;
            int blue = rounds.OrderBy(x => x.blues).Last().blues;
            int green = rounds.OrderBy(x => x.greens).Last().greens;

            return red * blue * green;
        }
    }
}
