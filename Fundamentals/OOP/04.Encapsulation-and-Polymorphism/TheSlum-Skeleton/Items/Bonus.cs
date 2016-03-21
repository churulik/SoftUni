using TheSlum.Interfaces;

namespace TheSlum.Items
{
    public class Bonus : Item, ITimeoutable
    {
        public Bonus(string id, int healthEffect, int defenseEffect, int attackEffect) 
            : base(id, healthEffect, defenseEffect, attackEffect)
        {
        }

        public int Timeout { get; set; }
        public int Countdown { get; set; }
        public bool HasTimedOut { get; set; }
    }
}