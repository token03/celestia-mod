using System;
using Terraria;
using Terraria.ModLoader;

namespace Celestia.Common.Players
{
    public class EMPlayer : ModPlayer
    {
        public int elementalMastery = 0;

        public override void ResetEffects()
        {
            elementalMastery = 0;
        }
    }
}
