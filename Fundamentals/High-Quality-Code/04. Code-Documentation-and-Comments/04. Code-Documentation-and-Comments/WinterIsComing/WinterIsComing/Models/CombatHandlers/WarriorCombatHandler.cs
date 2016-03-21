namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Core.Exceptions;
    using Spells;
    using WinterIsComing.Contracts;

    public class WarriorCombatHandler : CombatHandler
    {
        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            return candidateTargets
                .OrderBy(t => t.HealthPoints)
                .ThenBy(t => t.Name)
                .Take(1);
        }

        protected int AttackDamage
        {
            get
            {
                int damage = this.Unit.AttackPoints;
                if (this.Unit.HealthPoints <= 80)
                {
                    damage += this.Unit.HealthPoints * 2;
                }

                return damage;
            }
        }

        public override ISpell GenerateAttack()
        {
            var attack = new Cleave(this.AttackDamage);

            if (this.Unit.HealthPoints > 50)
            {
                if (this.Unit.EnergyPoints < attack.EnergyCost)
                {
                    throw new NotEnoughEnergyException(string.Format(
                        GlobalMessages.NotEnoughEnergy,
                        this.Unit.Name, attack.GetType().Name));
                }

                this.Unit.EnergyPoints -= attack.EnergyCost;                
            }

            return attack;
        }
    }
}
