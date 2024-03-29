﻿using Celestia.Common.Players;
using Celestia.Content.Items;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Celestia.Helper.Reactions
{
	public class Overload : InstantReaction
    {
        private const int BASE_DAMAGE = 20; 
        public static void applyOverload(NPC npc, Player player)
		{
			int em = player.GetModPlayer<CelestiaPlayer>().ElementalMastery;
			int damage = damageCalc(em); // Calcs the damage 
			applyReactionDamage(npc, damage, Color.Purple, player); // does damage and other stuff
			SoundEngine.PlaySound(SoundID.Item109, npc.position); // plays sound effect
			Item.NewItem(npc.GetSource_FromAI(), npc.getRect(), ModContent.ItemType<EnergyParticle>()); // drops particle?
        }

        public static int damageCalc(int em)
        {
            double damage = em * MathHelp.GetRandomDouble(0.85, 1.15);
            return Convert.ToInt32(damage);
        }
    }
}