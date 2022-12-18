using Celestia.Common.Players;
using Microsoft.Xna.Framework;
using System;
using Terraria;

namespace Celestia.Helper.Reactions
{
	public class Spread : InstantReaction
    {
        public static void applySpread(NPC npc, Player player, int baseDamage)
		{
			int em = player.GetModPlayer<EMPlayer>().elementalMastery;
			int damage = damageCalc(em, baseDamage); // Calculates damage
			ApplyReactionDamage(npc, damage, Color.ForestGreen, player);
		}

        public static int damageCalc(int em, int baseDamage)
        {
            double damage = baseDamage * MathHelper.GetRandomNumber(0.85, 1.15);
            return Convert.ToInt32(damage);
        }
    }
}