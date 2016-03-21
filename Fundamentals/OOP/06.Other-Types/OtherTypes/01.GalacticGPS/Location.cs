using System;

namespace _01.GalacticGPS
{
    public struct Location
    {
        private double latitutde;
        private double longitude;

        public Location(double latitude, double longitude, Planet planet) : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Planet = planet;
        }

        public double Latitude
        {
            get { return this.latitutde; }
            set
            {
                if (value < -90 || value > 90)
                {
                    throw new ArgumentOutOfRangeException("The latitude range must be between -90 and +90.");
                }
                this.latitutde = value;
            }
        }

        public double Longitude
        {
            get { return this.longitude; }
            set
            {
                if (value < -180 || value > 180)
                {
                    throw new ArgumentOutOfRangeException("The longitude range must be between -180 and +180.");
                }
                this.longitude = value;
            }
        }

        public Planet Planet { get; }

        public override string ToString()
        {
            return $"Latitude: {this.Latitude}, Longitude: {this.Longitude}, Planet: {this.Planet}";
        }
    }
}