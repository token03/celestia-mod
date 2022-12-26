using Celestia.Content.Items;
using Terraria;
using Terraria.ModLoader;

namespace Celestia.Helper.InstantReactions
{
	public class Crystalize
	{
		public static void applyCrystalize(NPC npc, Player player, int baseDamage)
		{
			int itemIndex = Item.NewItem(player.GetSource_OnHit(npc), npc.position, ModContent.ItemType<CrystalizeShard>());
			Item crystalizeShard = Main.item[itemIndex];
		}
	}
}
