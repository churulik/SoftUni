using System.Collections.Generic;
using System.Linq;
using TheSlum.Interfaces;
using TheSlum.Items;

namespace TheSlum.Characters
{
    public class Warrior : Character, IAttack
    {
        private const int DefaultHelthPoints = 200;
        private const int DefaultDefencePoints = 100;
        private const int DefaultAttackPoints = 150;
        private const int DefaultRange = 2;

        public Warrior(string id, int x, int y, Team team, int range = DefaultRange, 
            int healthPoints = DefaultHelthPoints, int defensePoints = DefaultDefencePoints, int attackPoints = DefaultAttackPoints) 
            : base(id, x, y, healthPoints, defensePoints, team, range)
        {
            this.AttackPoints = attackPoints;
        }

        public int AttackPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList.FirstOrDefault(t => t.IsAlive && t.Team != this.Team);
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            this.ApplyItemEffects(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            this.RemoveItemEffects(item);
        }
        protected override void ApplyItemEffects(Item item)
        {
            base.ApplyItemEffects(item);
            this.AttackPoints += item.AttackEffect;
        }

        protected override void RemoveItemEffects(Item item)
        {
            base.RemoveItemEffects(item);
            this.AttackPoints -= item.AttackEffect;
        }
       

        public override string ToString()
        {
            return "-- " + base.ToString() + ", Attack: " + this.AttackPoints;
        }
    }
}