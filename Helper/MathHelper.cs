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
        public static double GetRandomDouble(double minimum, double maximum)
        {
            return Main.rand.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
