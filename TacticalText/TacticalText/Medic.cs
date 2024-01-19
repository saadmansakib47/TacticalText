using System;

namespace TacticalText
{
    public class Medic : IUnit
    {
        public string Name => "Medic";
        public int Price => 10;
        public int Health { get; set; } = 1;

        public void Attack(IUnit target)
        {
            // Medic doesn't perform regular attacks, so I leave this empty
        }

        public void Revive(IUnit target)
        {
            // Implement revive logic for Medic
            if (target == null)
            {
                return;
            }

            // Revive the target by restoring its health
            target.Health = Math.Min(target.Health + 1, 3); // Assuming maximum health is 3 for other units
        }
    }

}
