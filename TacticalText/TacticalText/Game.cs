using System;
using System.Collections.Generic;

namespace TacticalText
{
    public class Game
    {
        public int CurrentMove { get; private set; }
        public Player Player1 { get; }
        public Player Player2 { get; }

        public Game(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }

        // Setup the game by allowing players to choose sides and buy units
        public void SetupGame()
        {
            Console.WriteLine("Welcome to Tactical Text!");

            // Player 1 chooses side (Allied/Axis)
            Player1.ChooseAndBuyUnits();

            // Player 2 automatically gets the other side and buys units
            Player2.ChooseAndBuyUnits();
        }


        // Deploy units for the current move
        public void DeployUnits()
        {
            Console.WriteLine($"Move: {CurrentMove}");

            Console.WriteLine($"{Player1.Side} deploying units:");
            DeployUnits(Player1);

            Console.WriteLine($"{Player2.Side} deploying units:");
            DeployUnits(Player2);

            // Increment the move after deployment
            CurrentMove++;
        }

        // Helper method to deploy units for a player
        private void DeployUnits(Player player)
        {
            HashSet<Type> deployedUnitTypesThisTurn = new HashSet<Type>();

            foreach (IUnit unit in player.Units)
            {
                // If the unit has already been deployed in this move, skip it
                if (deployedUnitTypesThisTurn.Contains(unit.GetType()))
                {
                    continue;
                }

                // If the unit has zero health or less, it cannot be deployed
                if (unit.Health <= 0)
                {
                    continue;
                }

                int availableUnits = player.Units.Count(u => u.GetType() == unit.GetType() && u.Health > 0);

                Console.WriteLine($"{unit.Name}: Available {availableUnits}");

                Console.Write($"Enter the number of {unit.Name}s to deploy (or press Enter to skip): ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    continue;
                }

                if (int.TryParse(input, out int unitsToDeploy) && unitsToDeploy > 0 && unitsToDeploy <= availableUnits)
                {
                    // Update the unit's health to the number of deployed units for each move
                    unit.Health -= unitsToDeploy;

                    // Add the deployed unit type to the set to prevent redeployment in the same turn
                    deployedUnitTypesThisTurn.Add(unit.GetType());

                    Console.WriteLine($"{unit.Name} deployed: {unitsToDeploy}");
                }
                else
                {
                    Console.WriteLine($"Invalid input. Please enter a positive number within the available {unit.Name}s.");
                    // Repeat the iteration to allow the player to input the correct value
                }
            }
        }




        // Helper method to get the number of units to deploy from the player
        private int GetUnitsToDeploy()
        {
            int unitsToDeploy;
            while (!int.TryParse(Console.ReadLine(), out unitsToDeploy) || unitsToDeploy < 0)
            {
                Console.WriteLine("Invalid input. Please enter a non-negative number.");
                Console.Write("Enter again: ");
            }
            return unitsToDeploy;
        }


        // New method to calculate the outcomes of the moves
        private void CalculateOutcomes()
        {
            Console.WriteLine("Calculating outcomes...");

            // Implement your logic here to calculate outcomes, including unit kills
            // For simplicity, I'll assume a basic scenario where units kill each other based on their attack logic

            foreach (Player player in new[] { Player1, Player2 })
            {
                foreach (IUnit attacker in player.Units)
                {
                    foreach (IUnit target in player == Player1 ? Player2.Units : Player1.Units)
                    {
                        attacker.Attack(target);
                    }
                }
            }

            // Display results after calculating outcomes
            DisplayResults();
        }

        // Display results after each move
        public void DisplayResults()
        {
            Console.WriteLine("Results after Move " + CurrentMove + ":");
            DisplayPlayerResults(Player1);
            DisplayPlayerResults(Player2);
        }

        // Helper method to display results for a player
        private void DisplayPlayerResults(Player player)
        {
            Console.WriteLine($"{player.Side} player:");

            // Group units by type and display remaining count
            var groupedUnits = player.Units.Where(unit => unit.Health > 0)
                                            .GroupBy(unit => unit.GetType())
                                            .Select(group => new
                                            {
                                                UnitType = group.Key.Name,
                                                Remaining = group.Count()
                                            });

            foreach (var unitGroup in groupedUnits)
            {
                Console.WriteLine($"{unitGroup.UnitType} - Remaining: {unitGroup.Remaining}");
            }

            Console.WriteLine();
        }

        // Check if the game is over
        public bool IsGameOver()
        {
            // Check if any player has all units defeated
            return Player1.Units.All(unit => unit.Health <= 0) || Player2.Units.All(unit => unit.Health <= 0);
        }

        // Determine the winner of the game
        public Player GetWinner()
        {
            // Check if the game is not over yet
            if (!IsGameOver())
                return null;

            // Determine the winner based on remaining unit health
            return Player1.Units.Sum(unit => unit.Health) > Player2.Units.Sum(unit => unit.Health) ? Player1 : Player2;
        }
    }
}
