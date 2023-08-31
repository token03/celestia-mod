using Celestia.Common.Players;
using Terraria;
using Terraria.ModLoader;

namespace Celestia.Content.Items
{
	public class CrystalChunk : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 12;
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.CrystalChunk>());
		}
		public override void AddRecipes()
		{

		}


	}
}
