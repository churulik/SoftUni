namespace TheSlum.Items
{
    public class Injection : Bonus
    {
        private const int BonustHealthEffect = 200;
        private const int BonusCountdown = 3;

        public Injection(string id, int defenseEffect, int attackEffect,  int healthEffect = BonustHealthEffect) 
            : base(id, healthEffect, defenseEffect, attackEffect)
        {
            this.Countdown = BonusCountdown;
        }
    }
}