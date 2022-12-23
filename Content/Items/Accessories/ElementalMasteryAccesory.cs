using Celestia.Common.Players;
using Terraria;
using Terraria.ModLoader;

namespace Celestia.Content.Items.Accessories
{
	public class ElementalMasteryAccesory : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases elemental mastery by 500\n" +
                               "Increasese base damage for all weapons by 5");
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<EMPlayer>().ElementalMastery += 500;
        }
    }
}
