using Celestia.Content.NPCs;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Celestia.Helper.InstantReactions
{
	public class Bloom
	{
		public static void applyBloom(NPC npc, Player player, int baseDamage)
		{
			int npcIndex = NPC.NewNPC(player.GetSource_OnHit(npc), 
				Convert.ToInt32(npc.position.X), 
				Convert.ToInt32(npc.position.Y), 
				ModContent.NPCType<BloomCore>());

			NPC bloomCore = Main.npc[npcIndex];
		}
	}
}
