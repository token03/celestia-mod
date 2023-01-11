using Celestia.Common.Players;
using Microsoft.Xna.Framework;
using Terraria.ID;
using System;
using Terraria;
using Terraria.Audio;

namespace Celestia.Helper.Reactions
{
	public class Melt : InstantReaction
    {
        public static void applyMelt(NPC npc, Player player, int baseDamage, bool reverse)
		{
			int em = player.GetModPlayer<CelestiaPlayer>().ElementalMastery;
			int damage = damageCalc(em, baseDamage, reverse); // Calculates damage
			SoundEngine.PlaySound(SoundID.Item66, npc.position); // plays sound effect
			applyReactionDamage(npc, damage, Color.LightBlue, player);
		}

        public static int damageCalc(int em, int baseDamage, bool reverse)
        {
            double meltMultiplier = reverse ? 2.5 : 4;
            double damage = baseDamage * MathHelper.GetRandomDouble(0.85, 1.15) * meltMultiplier;
            return Convert.ToInt32(damage);
        }
    }
}