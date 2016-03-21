namespace WinterIsComing.Contracts
{
    /// <summary>
    /// А unit with position (x, y), name, range, attack points, 
    /// health points, defense points, energy points and a combat handler.
    /// </summary>
    public interface IUnit
    {
        /// <summary>
        /// Unit horizontal position.
        /// </summary>
        int X { get; set; }

        /// <summary>
        /// Unit vertical position.
        /// </summary>
        int Y { get; set; }

        /// <summary>
        /// Unit name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Unit range.
        /// </summary>
        int Range { get; }

        /// <summary>
        /// Unit attack points.
        /// </summary>
        int AttackPoints { get; set; }

        /// <summary>
        /// Unit helth points.
        /// </summary>
        int HealthPoints { get; set; }

        /// <summary>
        /// Unit defense points.
        /// </summary>
        int DefensePoints { get; set; }

        /// <summary>
        /// Unit energy points.
        /// </summary>
        int EnergyPoints { get; set; }

        /// <summary>
        /// Used for determining the unit's actions during combat.
        /// </summary>
        ICombatHandler CombatHandler { get; }
    }
}
