namespace WinterIsComing.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// A combat handler used for determining a unit's targets and spells during a fight. 
    /// </summary>
    public interface ICombatHandler
    {
        /// <summary>
        /// A unit with position (x, y), name, range, attack points, health points, 
        /// defense points, energy points and 
        /// a combat handler (used for determining the unit's actions during combat).
        /// </summary>
        IUnit Unit { get; set; }

        /// <summary>
        /// IUnit enumarator that selects next target.
        /// </summary>
        /// <param name="candidateTargets">IUnit enumarator that holds possible targets.</param>
        /// <returns></returns>
        IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets);

        ISpell GenerateAttack();
    }
}
