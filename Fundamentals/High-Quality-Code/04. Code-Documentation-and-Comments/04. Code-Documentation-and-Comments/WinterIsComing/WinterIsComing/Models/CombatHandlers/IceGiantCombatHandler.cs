namespace WinterIsComing.Models.CombatHandlers
{
    using System;
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Core.Exceptions;
    using Spells;

    public class IceGiantCombatHandler : CombatHandler
    {
        private const int AfterAttackBonus = 5;

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            if (this.Unit.HealthPoints <= 150)
            {
                return candidateTargets.Take(1);
            }

            return candidateTargets;
        }

        public override ISpell GenerateAttack()
        {
            var attack = new Stomp(this.Unit.AttackPoints);

            if (this.Unit.EnergyPoints < attack.EnergyCost)
            {
                throw new NotEnoughEnergyException(string.Format(
                    GlobalMessages.NotEnoughEnergy,
                    this.Unit.Name, attack.GetType().Name));
            }

            this.Unit.EnergyPoints -= attack.EnergyCost;
            this.Unit.AttackPoints += AfterAttackBonus;

            return attack;
        }
    }
}
