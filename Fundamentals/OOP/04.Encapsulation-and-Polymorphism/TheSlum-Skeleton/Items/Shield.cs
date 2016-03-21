namespace TheSlum.Items
{
    public class Shield : Item
    {
        private const int DefaultHealthEffect = 0;
        private const int DefaultDefenseEffect = 50;
        private const int DefaultAttackEffect = 0;

        public Shield(string id, int healthEffect = DefaultHealthEffect,
            int defenseEffect = DefaultDefenseEffect, int attackEffect = DefaultAttackEffect) 
            : base(id, healthEffect, defenseEffect, attackEffect)
        {
        }
    }
}