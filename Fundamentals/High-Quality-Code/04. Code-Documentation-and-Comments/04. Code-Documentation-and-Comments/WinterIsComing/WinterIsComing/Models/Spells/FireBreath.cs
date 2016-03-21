namespace WinterIsComing.Models.Spells
{
    public class FireBreath : Spell
    {
        private const int FireBreathEnergyCost = 30;

        public FireBreath(int damage) 
            : base(damage, FireBreathEnergyCost)
        {
        }
    }
}
