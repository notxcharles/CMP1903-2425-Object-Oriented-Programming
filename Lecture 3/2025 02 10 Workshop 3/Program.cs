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
            public int PlayTurn()
            {
                int playersRoll = dice.Roll();
                return playersRoll;
            }
        }
        class Game
        {
            private Player userPlayer;
            private Player computerPlayer;
            private int numberOfTurns;
            private int numberOfTurnsPlayed;

            public Game()
            {
                userPlayer = new Player();
                computerPlayer = new Player();
            }
            public void Start()
            {
                numberOfTurns = SetNumberOfTurns();
                while (numberOfTurnsPlayed < numberOfTurns)
                {
                    int playerRoll = userPlayer.PlayTurn();
                    int computerRoll = computerPlayer.PlayTurn();
                    DeclareWinner(playerRoll, computerRoll);
                }
                Console.WriteLine($"The final score was:\nuser: {userPlayer.score} | computer: {computerPlayer.score}");
                userPlayer.score = 0;
                computerPlayer.score = 0;
            }
            private void DeclareWinner(int playerRoll, int computerRoll)
            {
                if (playerRoll < computerRoll)
                {
                    Console.WriteLine($"The computer wins! The computer rolled {computerRoll} vs the player's {playerRoll}");
                    computerPlayer.score += 1;
                }
                else if (playerRoll > computerRoll)
                {
                    Console.WriteLine($"The player wins! The player rolled {playerRoll} vs the computer's {computerRoll}");
                    userPlayer.score += 1;
                }
                else
                {
                    Console.WriteLine($"No winner - both the player and the computer rolled a {playerRoll}");
                }
                numberOfTurnsPlayed += 1;
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
                        Console.WriteLine($"Error: unable to parse \"{turns}\" to an integer");
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

            game.Start();
        }
    }
}
