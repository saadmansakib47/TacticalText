using System;

namespace TacticalText
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create players
            Player player1 = new Player("Allied");
            Player player2 = new Player("Axis");

            // Create the game
            Game tacticalTextGame = new Game(player1, player2);

            // Setup the game by allowing players to choose sides and buy units
            tacticalTextGame.SetupGame();

            // Game loop
            while (!tacticalTextGame.IsGameOver())
            {
                Console.Clear();  // Clear the console for each turn

                // Deploy units for the current move
                tacticalTextGame.DeployUnits();

                // Display results after each move
                tacticalTextGame.DisplayResults();

                // Wait for user input before proceeding to the next turn
                Console.WriteLine("Press Enter to continue to the next move...");
                Console.ReadLine();
            }

            // Determine the winner and display the result
            Player winner = tacticalTextGame.GetWinner();
            Console.WriteLine($"The game is over! {winner.Side} player wins!");
        }
    }
}