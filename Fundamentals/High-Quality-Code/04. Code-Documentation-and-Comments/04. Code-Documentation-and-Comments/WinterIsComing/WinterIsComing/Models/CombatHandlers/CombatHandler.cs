namespace WinterIsComing.Models.CombatHandlers
{
    using Contracts;
    using System.Collections.Generic;

    public abstract class CombatHandler : ICombatHandler
    {
        public IUnit Unit { get; set; }

        public abstract IEnumerable<IUnit> PickNextTargets(
            IEnumerable<IUnit> candidateTargets);

        public abstract ISpell GenerateAttack();
    }
}
