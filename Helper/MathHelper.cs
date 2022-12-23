using Terraria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Celestia.Helper
{
    public static class MathHelper
    {
		/// <summary>
		///  Returns a random double between given maximum and minimum.
		/// </summary>
		/// <param name="minimum"></param>
		/// <param name="maximum"></param>
		/// <returns></returns>
        public static double GetRandomDouble(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
		/// <summary>
		/// Returns a random double between given maximum and minimum. Overload with new Random() for loops.
		/// </summary>
		/// <param name="minimum"></param>
		/// <param name="maximum"></param>
		/// <param name="random"></param>
		/// <returns></returns>

		public static double GetRandomDouble(double minimum, double maximum, Random random)
        {
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
