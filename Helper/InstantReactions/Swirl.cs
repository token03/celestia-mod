using Celestia.Common.Players;
using Celestia.Helper.Reactions;
using Microsoft.Xna.Framework;
using System;
using Terraria;

namespace Celestia.Helper.InstantReactions
{
	public class Swirl : InstantReaction
	{
		public static void applySwirl(NPC npc, Player player, int baseDamage, int element)
		{
			int em = player.GetModPlayer<CelestiaPlayer>().ElementalMastery;
			int damage = damageCalc(em, baseDamage); // Calculates damage
			applyReactionDamage(npc, damage, Color.LightCyan, player);
		}

		public static int damageCalc(int em, int baseDamage)
		{
			double swirlMultiplier = em * 50;
			double damage = baseDamage * MathHelper.GetRandomDouble(0.85, 1.15) * swirlMultiplier;
			return Convert.ToInt32(damage);
		}
	}
}
