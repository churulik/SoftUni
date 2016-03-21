namespace TheSlum.Items
{
    public class Pill : Bonus
    {
        private const int BonustAttackEffect = 100;
        private const int BonusCountdown = 1;
        public Pill(string id, int healthEffect, int defenseEffect, int attackEffect = BonustAttackEffect) 
            : base(id, healthEffect, defenseEffect, attackEffect)
        {
            this.Countdown = BonusCountdown;
        }
    }
}