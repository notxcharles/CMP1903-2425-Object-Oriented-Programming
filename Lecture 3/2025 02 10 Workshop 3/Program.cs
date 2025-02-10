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
        class Player
        {
            private Dice dice;
            public int score;
            public Player()
            {
                dice = new Dice();
                score = 0;
            }
            public void PlayTurn()
            {
                // Computer's roll:
                int computerRoll = dice.Roll();
                // Player's roll:
                int playersRoll = dice.Roll();

                if (playersRoll > computerRoll)
                {
                    score += 1;
                } 
                else if (playersRoll < computerRoll)
                {
                    score -= 1;
                }
            }
        }
        class Game
        {
            private Player userPlayer;
            private Player computerPlayer;
            private int numberOfTurns;
            private int userScore;
            private int computerScore;
            private int userWins;
            private int computerWins;
            public Game()
            {
                userPlayer = new Player();
                computerPlayer = new Player();
            }
            public void Start()
            {

            }
            private int SetNumberOfTurns()
            {
                bool failed = true;

                while (failed)
                {
                    Console.WriteLine("How many turns would you like to play?");
                    string turns = Console.ReadLine();
                    try
                    {
                        int turnsInput = Int32.Parse(turns);
                        failed = false;
                        return turnsInput;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Error: unable to parse {turns} to an integer");
                    }
                }
                return -1;
            }
        }

        static void Main(string[] args)
        {
            Game game = new Game();
            Dice dice = new Dice();

            Player player = new Player();
            player.PlayTurn();
            Console.WriteLine(player.score);
        }
    }
}
