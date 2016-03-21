namespace WinterIsComing.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// A container for keeping units in some kind of a structure (i.e. 2D matrix or 3D plane).
    /// </summary>
    public interface IUnitContainer
    {
        /// <summary>
        /// IUnit enumarator that defines unit position.
        /// </summary>
        /// <param name="x">horizontal positon</param>
        /// <param name="y">vertical position</param>
        /// <param name="range">range position</param>
        /// <returns></returns>
        IEnumerable<IUnit> GetUnitsInRange(int x, int y, int range);

        /// <summary>
        /// Add new unit.
        /// </summary>
        /// <param name="unit"></param>
        void Add(IUnit unit);

        /// <summary>
        /// Remove unit.
        /// </summary>
        /// <param name="unit"></param>
        void Remove(IUnit unit);

        /// <summary>
        /// Unit direction of move.
        /// </summary>
        /// <param name="unit">unit to be moved</param>
        /// <param name="newX">new horizontal positon</param>
        /// <param name="newY">new vertical position</param>
        void Move(IUnit unit, int newX, int newY);
    }
}
