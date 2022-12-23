using Celestia.Common.Players;
using Celestia.Content.Buffs.Elements;
using Terraria;
using Terraria.ModLoader;

namespace Celestia.Content.Items.Accessories.Visions
{
	public class PyroVision : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increases Pyro damage by 10% \n" +
								"Increases Element Recharge by 30%\n" +
								"Imbues your weapons with the power of Pyro");
		}
		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<VisionPlayer>().Vision = ModContent.BuffType<Pyro>();
		}
	}
}
