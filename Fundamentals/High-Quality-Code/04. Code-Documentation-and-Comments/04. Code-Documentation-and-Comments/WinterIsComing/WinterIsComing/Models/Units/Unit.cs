namespace WinterIsComing.Models.Units
{
    using System;
    using System.Text;
    using Contracts;

    public abstract class Unit : IUnit
    {
        private string name;
        protected ICombatHandler combatHandler;

        protected Unit(int x, int y,
            string name,
            int attackPoints,
            int healthPoints,
            int defensePoints,
            int energyPoints,
            int range,
            ICombatHandler combatHandler)
        {
            this.X = x;
            this.Y = y;
            this.Name = name;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.EnergyPoints = energyPoints;
            this.Range = range;
            this.CombatHandler = combatHandler;
            this.CombatHandler.Unit = this;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public int Range { get; private set; }

        public int AttackPoints { get; set; }

        public int HealthPoints { get; set; }

        public int DefensePoints { get; set; }

        public int EnergyPoints { get; set; }

        public ICombatHandler CombatHandler
        {
            get { return this.combatHandler; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Combat handler cannot be null");
                }

                this.combatHandler = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat(">{0} - {1} at ({2},{3}){4}",
                this.Name, this.GetType().Name, this.X, this.Y, Environment.NewLine);

            if (this.HealthPoints > 0)
            {
                output.AppendFormat("-Health points = {0}{1}",
                    this.HealthPoints, Environment.NewLine);
                output.AppendFormat("-Attack points = {0}{1}",
                    this.AttackPoints, Environment.NewLine);
                output.AppendFormat("-Defense points = {0}{1}",
                    this.DefensePoints, Environment.NewLine);
                output.AppendFormat("-Energy points = {0}{1}",
                    this.EnergyPoints, Environment.NewLine);
                output.AppendFormat("-Range = {0}", this.Range);
            }
            else
            {
                output.Append("(Dead)");
            }

            return output.ToString();
        }
    }
}
