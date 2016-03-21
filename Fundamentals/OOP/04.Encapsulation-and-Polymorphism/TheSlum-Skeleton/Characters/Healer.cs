using System.Collections.Generic;
using System.Linq;
using TheSlum.Interfaces;
using TheSlum.Items;

namespace TheSlum.Characters
{
    public class Healer : Character, IHeal
    {
        private const int DefaultHelthPoints = 75;
        private const int DefaultDefencePoints = 50;
        private const int DefaultHealingPoints = 60;
        private const int DefaultRange = 6;

        public Healer(string id, int x, int y, Team team, int range = DefaultRange, 
            int healthPoints = DefaultHelthPoints, int defensePoints = DefaultDefencePoints, int healingPoints = DefaultHealingPoints) 
            : base(id, x, y, healthPoints, defensePoints, team, range)
        {
            this.HealingPoints = healingPoints;
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList.OrderBy(t => t.HealthPoints)
                .FirstOrDefault(t => t.IsAlive && t.Team == this.Team && t.Id != this.Id);
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

        public int HealingPoints { get; set; }

        public override string ToString()
        {
            return "-- " + base.ToString() + ", Healing: " + this.HealingPoints;
        }
    }
}