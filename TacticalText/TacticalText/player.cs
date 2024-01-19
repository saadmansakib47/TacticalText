using System;
using System.Collections.Generic;

namespace TacticalText
{
    public class Player
    {
        public string Side { get;  set; }
        public int Budget { get; set; }
        public List<IUnit> Units { get; private set; }
        private static readonly string[] UnitTypes = { "Infantry", "Tank", "Sniper", "Medic", "Engineer" };
        private static readonly int[] UnitPrices = { 5, 30, 20, 10, 10 };

        public Player(string side)
        {
            Side = side;
            Budget = 500;
            Units = new List<IUnit>();
        }

        public void ChooseAndBuyUnits()
        {
            Console.WriteLine($"Unit Shop (Press y to buy, n to skip)");
            Console.WriteLine($"Customer: {Side} Player");
            Console.WriteLine("[You can buy a maximum of 3 types of units]");

            HashSet<int> purchasedUnitTypes = new HashSet<int>();

            while (Budget > 0 && purchasedUnitTypes.Count < 3)
            {
                Console.WriteLine($"Budget: ${Budget}");

                for (int i = 0; i < UnitTypes.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {UnitTypes[i]} (Price: ${UnitPrices[i]})");
                }

                Console.Write("Choose a unit (1-5) or press 'n' to skip: ");
                char choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (choice == 'n')
                {
                    break;
                }
                else if (choice >= '1' && choice <= '5')
                {
                    int unitIndex = int.Parse(choice.ToString()) - 1;

                    if (purchasedUnitTypes.Contains(unitIndex))
                    {
                        Console.WriteLine("You've already purchased this unit type. Choose again.");
                        continue;
                    }

                    BuyUnit(unitIndex);
                    purchasedUnitTypes.Add(unitIndex);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose again.");
                }
            }
        }

        private void BuyUnit(int unitIndex)
        {
            IUnit unit = CreateUnit(unitIndex);

            if (unit != null)
            {
                Console.Write($"Amount of {unit.Name}s to buy: ");
                string input = Console.ReadLine();

                if (input.ToLower() == "n")
                {
                    Console.WriteLine($"No {unit.Name}s purchased.");
                    return;
                }

                if (int.TryParse(input, out int amount) && amount >= 0)
                {
                    int totalCost = amount * unit.Price;

                    if (totalCost <= Budget)
                    {
                        Budget -= totalCost;

                        // Update the unit's health to the total amount
                        unit.Health = amount;

                        // Add the purchased units to the player's list
                        for (int i = 0; i < amount; i++)
                        {
                            Units.Add(unit);
                        }

                        Console.WriteLine($"You bought {amount} {unit.Name}(s) for ${totalCost}. Remaining budget: ${Budget}");

                        // Update the available count after the purchase
                        int availableUnits = Units.Count(u => u.GetType() == unit.GetType() && u.Health > 0);
                        Console.WriteLine($"Available {unit.Name}s: {availableUnits}");
                    }
                    else
                    {
                        Console.WriteLine("Not enough budget to buy that many units.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a non-negative number.");
                    BuyUnit(unitIndex); // Prompt again if the input is invalid
                }
            }
            else
            {
                Console.WriteLine("Invalid unit.");
            }
        }

        private IUnit CreateUnit(int unitIndex)
        {
            IUnit unit = null;

            switch (unitIndex)
            {
                case 0:
                    unit = new Infantry();
                    break;
                case 1:
                    unit = new Tank();
                    break;
                case 2:
                    unit = new Sniper();
                    break;
                case 3:
                    unit = new Medic();
                    break;
                case 4:
                    unit = new Engineer();
                    break;
                default:
                    break;
            }

            return unit;
        }



        private int GetAmountToBuy()
        {
            int amount;
            while (!int.TryParse(Console.ReadLine(), out amount) || amount < 0)
            {
                Console.WriteLine("Invalid input. Please enter a non-negative number.");
                Console.Write("Enter again or press 'n' to skip: ");

                // If 'n' is pressed, return 0 to represent skipping the unit
                if (Console.ReadLine().ToLower() == "n")
                {
                    return 0;
                }
            }
            return amount;
        }

    }
}
