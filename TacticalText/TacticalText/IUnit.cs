using System;
using System.Collections.Generic;

// Interface for units that can perform actions during the game
public interface IUnit
{
    string Name { get; }
    int Price { get; }
    int Health { get; set; }
    void Attack(IUnit target);
}