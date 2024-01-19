using System;

namespace TacticalText
{
    public class Engineer : IUnit
    {
        public string Name => "Engineer";
        public int Price => 10;
        public int Health { get; set; } = 1;

        public void Attack(IUnit target)
        {
            // Engineer doesn't perform regular attacks, so Ileave this empty
        }

        public void Revive(IUnit target)
        {
            // Implement revive logic for Engineer
            if (target == null)
            {
                return;
            }

            // Revive the target (assuming it's a tank) after 3 turns
            if (target is Tank tankTarget)
            {
                tankTarget.Health = Math.Min(tankTarget.Health + 1, 3); // Assuming maximum health is 3 for tanks
            }
        }
    }
}
