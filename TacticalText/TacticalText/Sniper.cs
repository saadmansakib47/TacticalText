using System;

namespace TacticalText
{
    public class Sniper : IUnit
    {
        public string Name => "Sniper";
        public int Price => 20;
        public int Health { get; set; } = 2;

        public void Attack(IUnit target)
        {
            // Implement attack logic for Sniper
            if (target == null)
            {
                return;
            }

            // Adjust attack logic based on target type
            if (!(target is Tank))
            {
                // Sniper kills any unit (except tanks) in a single turn
                target.Health = 0;
            }
            else
            {
                // Reduce the target's health by 1 for tanks
                target.Health -= 1;
            }
        }
    }

    // Rest of the classes remain unchanged
}
