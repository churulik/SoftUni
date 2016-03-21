namespace WinterIsComing.Models.Spells
{
    using Contracts;

    public abstract class Spell : ISpell
    {
        protected Spell(int damage, int energyCost)
        {
            this.Damage = damage;
            this.EnergyCost = energyCost;
        }

        public int Damage { get; private set; }

        public int EnergyCost { get; private set; }
    }
}
