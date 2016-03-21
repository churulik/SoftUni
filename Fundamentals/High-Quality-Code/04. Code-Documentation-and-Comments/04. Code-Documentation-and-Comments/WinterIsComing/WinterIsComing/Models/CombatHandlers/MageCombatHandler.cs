namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Core.Exceptions;
    using Spells;
    using WinterIsComing.Contracts;

    public class MageCombatHandler : CombatHandler
    {
        private int spellCount;

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            return candidateTargets
                .OrderByDescending(t => t.HealthPoints)
                .ThenBy(t => t.Name)
                .Take(3);
        }

        public override ISpell GenerateAttack()
        {
            ISpell attack;

            if (this.spellCount % 2 == 0)
            {
                attack = new FireBreath(this.Unit.AttackPoints);
            }
            else
            {
                attack = new Blizzard(this.Unit.AttackPoints * 2);
            }

            if (this.Unit.EnergyPoints < attack.EnergyCost)
            {
                throw new NotEnoughEnergyException(string.Format(
                    GlobalMessages.NotEnoughEnergy,
                    this.Unit.Name, attack.GetType().Name));
            }

            this.spellCount++;

            this.Unit.EnergyPoints -= attack.EnergyCost;

            return attack;
        }
    }
}
