using Celestia.Common.Players;
using Celestia.Content.Items;
using IL.Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Celestia.Helper.Reactions
{
	public class Overload : InstantReaction
    {
        private const int BASE_DAMAGE = 20; 
        public static void applyOverload(NPC npc, Player player)
		{
			int em = player.GetModPlayer<EMPlayer>().elementalMastery;
			int damage = damageCalc(em); // Calcs the damage
			ApplyReactionDamage(npc, damage, Color.Purple, player); // does damage and other stuff
			Item.NewItem(npc.GetSource_FromAI(), npc.getRect(), ModContent.ItemType<EnergyParticle>()); // drops particle?
        }

        public static int damageCalc(int em)
        {
            double damage = em * MathHelper.GetRandomDouble(0.85, 1.15);
            return Convert.ToInt32(damage);
        }
    }
}