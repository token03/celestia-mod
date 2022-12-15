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
    public class Aggravate : InstantReaction
    {
        public static void applyAggravate(NPC npc, Player player, int baseDamage)
		{
			int em = player.GetModPlayer<EMPlayer>().elementalMastery;
			int damage = damageCalc(em, baseDamage); // Calculates damage
            ApplyReactionDamage(npc, damage, Color.Orchid, player); // Does the damage
		}

        public static int damageCalc(int em, int baseDamage)
        {
            double damage = baseDamage * MathHelper.GetRandomNumber(0.85, 1.15);
            return Convert.ToInt32(damage);
        }
    }
}