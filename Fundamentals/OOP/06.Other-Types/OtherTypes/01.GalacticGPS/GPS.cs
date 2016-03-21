using System;

namespace _01.GalacticGPS
{
    class GPS
    {
        static void Main()
        {
            var home = new Location(42.7000, 23.3333, Planet.Earth);
            Console.WriteLine(home);
        }
    }
}
