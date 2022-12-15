using Celestia.Common.Players;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.Graphics.Renderers;
using Terraria.ID;
using Terraria.ModLoader;

namespace Celestia.Helper.Reactions
{
    public class Vaporize : InstantReaction
    {
        public static void applyVaporize(NPC npc, Player player, int baseDamage, bool reverse)
		{
			int em = player.GetModPlayer<EMPlayer>().elementalMastery;
			int damage = damageCalc(em, baseDamage, reverse); // Calculates damage
			ApplyReactionDamage(npc, damage, Color.LightCyan, player);
        }

        public static int damageCalc(int em, int baseDamage, bool reverse)
        {
            double vapeMultipler = reverse ? 2.5 : 4;
            double damage = baseDamage * MathHelper.GetRandomNumber(0.85, 1.15) * vapeMultipler;
            return Convert.ToInt32(damage);
        }
    }
}