using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_02_10_Workshop_3
{
    internal class Program
    {
        class Dice
        {
            static Random random;
            public Dice()
            {
                random = new Random();
            }
            public int Roll(int rangeStart = 1, int rangeEnd = 6)
            {
                return random.Next(rangeStart, rangeEnd);
            }
        }
        class Game
        {
            public Game()
            {
            }
            public void Start()
            {

            }
        }

        static void Main(string[] args)
        {
            Game game = new Game();
        }
    }
}
