using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandoBun.Workspace.ClassLib
{
    public static class Randomizer
    {
        static Random? _random = null;
        public static Random GetRandom()
        {
            if (_random == null)
            {
                throw new Exception("Randomizer has not been initialized");
            }
            return _random;
        }

        public static void Initialize(int seed)
        {
            _random = new Random(seed);
        }

        public static int GetInt(int min, int max)
        {
            return GetRandom().Next(min, max);
        }

        public static int GetInt(int max)
        {
            return GetInt(0, max);
        }

        //public static float GetFloat(float min, float max, int decimalLength = 2)
        //{   
        //    // get random
        //    Random r = GetRandom();

        //    // get random number before the decimal point
        //    string beforePoint = r.Next(0, 9).ToString();
        //    string afterPoint = "";

        //    // append decimals
        //    for (int i = 0; i < decimalLength; i++)
        //    {
        //        beforePoint += r.Next(0, 9).ToString();
        //    }
        //    string combined = string.IsNullOrEmpty(afterPoint) ? beforePoint : beforePoint + "." + afterPoint;
        //    var decimalNumber = float.Parse(combined);
        //    return decimalNumber;
        //}

        // function to return a random float between a min and max value with a specified number of decimal places using the "Random" class

        public static float GetFloat(float min, float max)
        {
            var next = GetRandom().NextSingle();

            return min + (next * (max - min));
        }
}
