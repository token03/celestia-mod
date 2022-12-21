﻿using Celestia.Common.Players;
using Terraria;
using Terraria.ModLoader;

namespace Celestia.Content.Items
{
	public class EnergyParticle : ModItem
	{
		// Should behave like a heart or mana star. 
		public override bool OnPickup(Player player)
		{
			BurstPlayer burstPlayer = player.GetModPlayer<BurstPlayer>();
			burstPlayer.currentEnergy += 5;
			if (burstPlayer.currentEnergy > burstPlayer.MaxEnergy) burstPlayer.currentEnergy = burstPlayer.MaxEnergy;
			return false;
		}

		public override bool ItemSpace(Player player)
		{
			return true;
		}
	}
}
