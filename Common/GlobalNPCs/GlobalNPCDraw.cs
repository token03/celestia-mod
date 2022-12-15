using Celestia.Content.Buffs.Elements;
using Celestia.Content.Buffs.Reactions;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Celestia.Common.GlobalNPCs
{
    public class GlobalNPCDraw : GlobalNPC
    {
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (npc.HasBuff<Superconduct>())
            {
                drawColor = Color.GhostWhite;
            }
            else if (npc.HasBuff<Electro>())
            {
                drawColor = Color.Purple;
            }
            else if (npc.HasBuff<Pyro>())
            {
                drawColor = Color.OrangeRed;
            }
            else if (npc.HasBuff<Hydro>())
            {
                drawColor = Color.DeepSkyBlue;
            }
            else if (npc.HasBuff<Cryo>())
            {
                drawColor = Color.LightCyan;
            }
            else if (npc.HasBuff<Dendro>())
            {
                drawColor = Color.SpringGreen;
            }
        }
    }
}
