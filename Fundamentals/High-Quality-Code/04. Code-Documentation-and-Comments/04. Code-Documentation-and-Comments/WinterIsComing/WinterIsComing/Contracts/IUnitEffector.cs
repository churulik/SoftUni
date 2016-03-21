namespace WinterIsComing.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// A global entity that gives effects to all units in the game.
    /// </summary>
    public interface IUnitEffector
    {
        /// <summary>
        /// Apply effects to all units.
        /// </summary>
        /// <param name="units"></param>
        void ApplyEffect(IEnumerable<IUnit> units);
    }
}
