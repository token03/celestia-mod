using Celestia.Common.Players;
using Celestia.Content.Buffs.Elements;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Celestia.Content.Items.Accessories.Visions
{
	public class CryoVision : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<CelestiaPlayer>().Vision = ModContent.BuffType<Cryo>();
            player.GetModPlayer<CelestiaPlayer>().ElementalMastery += 15;
			player.GetModPlayer<CelestiaPlayer>().EnergyRecharge += .3f;
		}

		public override bool CanEquipAccessory(Player player, int slot, bool modded)
		{
			return player.GetModPlayer<CelestiaPlayer>().Vision == -1; // prevents multiple visions from being equiped
		}

		public override void AddRecipes()
		{
			CreateRecipe(1)
				.AddIngredient(ItemID.Shiverthorn, 99)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}
