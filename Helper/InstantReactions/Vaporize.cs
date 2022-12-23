using Celestia.Common.Players;
using Microsoft.Xna.Framework;
using System;
using Terraria;

namespace Celestia.Helper.Reactions
{
	public class Vaporize : InstantReaction
    {
        public static void applyVaporize(NPC npc, Player player, int baseDamage, bool reverse)
		{
			int em = player.GetModPlayer<EMPlayer>().ElementalMastery;
			int damage = damageCalc(em, baseDamage, reverse); // Calculates damage
			applyReactionDamage(npc, damage, Color.LightCyan, player);
        }

        public static int damageCalc(int em, int baseDamage, bool reverse)
        {
            double vapeMultipler = reverse ? 2.5 : 4;
            double damage = baseDamage * MathHelper.GetRandomDouble(0.85, 1.15) * vapeMultipler;
            return Convert.ToInt32(damage);
        }
    }
}