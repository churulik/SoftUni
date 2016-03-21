namespace WinterIsComing.Core
{
    using System;
    using Contracts;
    using Models;
    using Models.Units;

    public static class UnitFactory
    {
        public static IUnit Create(UnitType type, string name, int x, int y)
        {
            switch (type)
            {
                case UnitType.Warrior:
                    return new Warrior(x, y, name);
                case UnitType.Mage:
                    return new Mage(x, y, name);
                case UnitType.IceGiant:
                    return new IceGiant(x, y, name);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
