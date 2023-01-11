using Celestia.Common.Players;
using Celestia.Content.Buffs.Elements;
using Terraria;
using Terraria.ModLoader;

namespace Celestia.Content.Items.Accessories.Visions
{
	public class ElectroVision : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increases Electro damage by 10% \n" +
								"Increases Element Recharge by 30%\n" +
								"Imbues your weapons with the power of Electro");
		}
		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<CelestiaPlayer>().Vision = ModContent.BuffType<Electro>();
			player.GetModPlayer<CelestiaPlayer>().EnergyRecharge += .3f;
		}

		public override bool CanEquipAccessory(Player player, int slot, bool modded)
		{
			return player.GetModPlayer<CelestiaPlayer>().Vision == -1; // prevents multiple visions from being equiped
		}
	}
}
