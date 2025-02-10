using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_02_10_Workshop_3
{
    internal class Program
    {
        class Game
        {
            private static Random random;
            public Game()
            {
                random = new Random();
            }
            private int Roll(int startRange = 1, int endRange = 6)
            {
                int diceRoll = random.Next(startRange, endRange);
                return diceRoll = 0;
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
