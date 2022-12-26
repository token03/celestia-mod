using Celestia.Content.Buffs.Elements;
using Celestia.Content.Buffs.Reactions;
using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace Celestia.Content.Items
{
	public class CrystalizeShard : ModItem
	{
		private int _shardElement;
		public int ShardElement
		{
			get { return _shardElement; }
			set
			{
				if (new int[] // THIS JUST CHECKS IF GIVE VALUE IS AN ACTUAL ELEMENT! 
				{
					ModContent.BuffType<Pyro>(),
					ModContent.BuffType<Anemo>(),
					ModContent.BuffType<Geo>(),
					ModContent.BuffType<Cryo>(),
					ModContent.BuffType<Hydro>(),
					ModContent.BuffType<Dendro>(),
					ModContent.BuffType<Electro>(), // (PLEASE REFACTOR IF YOU CAN DO BETTER)
				}.Contains(value))
					_shardElement = value;
			}
		}
		// Should behave like a heart or mana star. 
		public override bool OnPickup(Player player)
		{
			player.AddBuff(ModContent.BuffType<Crystalize>(), 1800);
			CrystalizePlayer crystalizePlayer = player.GetModPlayer<CrystalizePlayer>();
			crystalizePlayer.ShieldHealth = 50;
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
