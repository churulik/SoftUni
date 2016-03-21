using System;

namespace WcfServiceCalculator
{
    public class DistanceCalculator : IServiceCalculator
    {
        public double CalcDistance(int startX, int startY, int endX, int endY)
        {
            var result = Math.Sqrt(Math.Pow(endX - startX, 2) + Math.Pow(endY - startY, 2));
            return result;
        }
    }
}
