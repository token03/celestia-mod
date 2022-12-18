using Celestia.Common.Players;
using Microsoft.Xna.Framework;
using System;
using Terraria;

namespace Celestia.Helper.Reactions
{
	public class Overload : InstantReaction
    {
        private const int BASE_DAMAGE = 20; 
        public static void applyOverload(NPC npc, Player player)
		{
			int em = player.GetModPlayer<EMPlayer>().elementalMastery;
			int damage = damageCalc(em); // Calcs the damage
			ApplyReactionDamage(npc, damage, Color.Purple, player);
        }

        public static int damageCalc(int em)
        {
            double damage = em * MathHelper.GetRandomNumber(0.85, 1.15);
            return Convert.ToInt32(damage);
        }
    }
}