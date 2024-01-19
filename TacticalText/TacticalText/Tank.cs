using System;

namespace TacticalText
{
    public class Tank : IUnit
    {
        public string Name => "Tank";
        public int Price => 30;
        public int Health { get; set; } = 3;

        public void Attack(IUnit target)
        {
            // Implement attack logic for Tank
            if (target == null)
            {
                return;
            }

            // Adjust attack logic based on target type
            if (target is Tank)
            {
                // Tank attacks other tanks, reducing their health by 1
                target.Health -= 1;
            }
            else
            {
                // Tank attacks other units, reducing their health by 2
                target.Health -= 2;
            }
        }
    }

}
