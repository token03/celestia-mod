using Celestia.Common.Players;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;

namespace Celestia.Helper.Reactions
{
	public class Aggravate : InstantReaction
	{
		public static void applyAggravate(NPC npc, Player player, int baseDamage)
		{
			int em = player.GetModPlayer<CelestiaPlayer>().ElementalMastery;
			int damage = damageCalc(em, baseDamage); // Calculates damage
			SoundEngine.PlaySound(SoundID.Item72, npc.position); // plays sound effect
			applyReactionDamage(npc, damage, Color.Orchid, player); // Does the damage
		}

		public static int damageCalc(int em, int baseDamage)
		{
			double damage = baseDamage * MathHelper.GetRandomDouble(0.85, 1.15);
			return Convert.ToInt32(damage);
		}
	}
}