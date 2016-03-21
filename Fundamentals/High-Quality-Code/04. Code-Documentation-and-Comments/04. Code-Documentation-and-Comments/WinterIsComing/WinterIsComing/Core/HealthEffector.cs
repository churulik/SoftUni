namespace WinterIsComing.Core
{
    using Contracts;
    using System.Collections.Generic;

    public class HealthEffector : IUnitEffector
    {
        private const int HealthRaiseBonus = 50;

        public void ApplyEffect(IEnumerable<IUnit> units)
        {
            foreach (var unit in units)
            {
                unit.HealthPoints += HealthRaiseBonus;
            }
        }
    }
}
