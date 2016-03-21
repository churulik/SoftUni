namespace WinterIsComing.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines an engine.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Beggin the process.
        /// </summary>
        void Start();

        /// <summary>
        /// End the process.
        /// </summary>
        void Stop();

        /// <summary>
        /// Insert new unit.
        /// </summary>
        /// <param name="unit"></param>
        void InsertUnit(IUnit unit);

        /// <summary>
        /// Remove unit.
        /// </summary>
        /// <param name="unit"></param>
        void RemoveUnit(IUnit unit);

        /// <summary>
        /// Returns an IUnit enumerator that can be iterate.
        /// </summary>
        IEnumerable<IUnit> Units { get; }

        /// <summary>
        /// A container for keeping units in some kind of a structure (i.e. 2D matrix or 3D plane)
        /// </summary>
        IUnitContainer UnitContainer { get; }

        /// <summary>
        /// Defines an output source (e.g. console).
        /// </summary>
        IOutputWriter OutputWriter { get; }

        /// <summary>
        /// A global entity that gives effects to all units in the game.
        /// </summary>
        IUnitEffector UnitEffector { get; }
    }
}
