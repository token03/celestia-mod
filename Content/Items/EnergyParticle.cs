using Celestia.Common.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Celestia.Content.Items
{
	public class EnergyParticle : ModItem
	{
		// Should behave like a heart or mana star. 
		public override bool OnPickup(Player player)
		{
			CelestiaPlayer burstPlayer = player.GetModPlayer<CelestiaPlayer>();
			int energyGained = Convert.ToInt32(burstPlayer.EnergyRecharge * 50); 

			burstPlayer.CurrentEnergy += energyGained;

			if (burstPlayer.CurrentEnergy > burstPlayer.MaxEnergy) 
				burstPlayer.CurrentEnergy = burstPlayer.MaxEnergy;

			return false;
		}

		public override bool ItemSpace(Player player)
		{
			return true;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.Lerp(lightColor, Color.White, 0.4f);
		}

		public override void PostUpdate()
		{
			Lighting.AddLight(Item.Center, Color.White.ToVector3() * 0.4f);
		}
	}
}
