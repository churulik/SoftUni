namespace WinterIsComing.Contracts
{
    /// <summary>
    /// An attack produced by units during battle.
    /// </summary>
    public interface ISpell
    {
        /// <summary>
        /// Determinets the damage cost. 
        /// </summary>
        int Damage { get; }

        /// <summary>
        /// Determinets the energy cost. 
        /// </summary>
        int EnergyCost { get; }
    }
}
