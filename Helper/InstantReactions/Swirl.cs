using Celestia.Common.Players;
using Celestia.Helper.Reactions;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace Celestia.Helper.InstantReactions
{
	public class Swirl : InstantReaction
	{
		public static void applySwirl(NPC npc, Player player, int baseDamage, int element)
		{
			int em = player.GetModPlayer<CelestiaPlayer>().ElementalMastery;
			int damage = damageCalc(em, baseDamage); // Calculates damage
			applyReactionDamage(npc, damage, Color.LightCyan, player);
			swirlAoe(npc, player, damage, element);
		}

		public static int damageCalc(int em, int baseDamage)
		{
			double swirlMultiplier = 1.1;
			double damage = baseDamage * MathHelper.GetRandomDouble(0.85, 1.15) * swirlMultiplier;
			return Convert.ToInt32(damage);
		}

		public static void swirlAoe(NPC npc, Player player, int damage, int element)
		{
			float maxDetectRadius = 300f;

			List<NPC> inRangeNPCs = new List<NPC>();

			for (int i = 0; i < Main.maxNPCs; i++)
			{
				NPC target = Main.npc[i];

				if (target.CanBeChasedBy() && Vector2.Distance(target.Center, npc.Center) < maxDetectRadius && target != npc)
					inRangeNPCs.Add(target);
			}

			if (!inRangeNPCs.Any())
				return;

			foreach (NPC n in inRangeNPCs)
			{
				if (!ReactionHelper.elementReaction(n, player, damage, element))
					n.AddBuff(element, 1800);
			}
		}
	}
}
