namespace WinterIsComing.Models.Spells
{
    public class Cleave : Spell
    {
        private const int CleaveEnergyCost = 15;

        public Cleave(int damage)
            : base(damage, CleaveEnergyCost)
        {
        }
    }
}
