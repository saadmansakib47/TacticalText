public class Infantry : IUnit
{
    public string Name => "Infantry";
    public int Price => 5;
    public int Health { get; set; } = 0;  // Set the initial health to 0

    public void Attack(IUnit target)
    {
        if (target == null)
        {
            return;
        }

        // Reduce the target's health based on Infantry's attack logic
        target.Health -= 1;
    }
}
