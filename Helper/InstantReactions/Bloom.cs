using Celestia.Content.NPCs;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Celestia.Helper.InstantReactions
{
	public class Bloom
	{
		public const int BLOOM_CORE_LIMIT = 5;
		public static void applyBloom(NPC npc, Player player, int baseDamage)
		{
			int npcIndex = NPC.NewNPC(player.GetSource_OnHit(npc),
				Convert.ToInt32(npc.position.X),
				Convert.ToInt32(npc.position.Y),
				ModContent.NPCType<BloomCore>());

			int oldestIndex = manageBloomCoreCount();
			// explodes the oldest bloomcore
			if (oldestIndex != -1)
			{
				NPC oldestCore = Main.npc[oldestIndex];
				oldestCore.ai[0] = BloomGlobalNPC.LIFE_SPAN;
			}
			BloomGlobalNPC bloomCore = Main.npc[npcIndex].GetGlobalNPC<BloomGlobalNPC>();
			bloomCore.OrginPlayer = player;
			bloomCore.BaseDamage = baseDamage;
		}

		/// <summary>
		/// Returns the index of the oldest BloomCore if total BloomCores is over BLOOM_CORE_LIMIT
		/// otherwise, returns -1
		/// </summary>
		/// <returns></returns>
		public static int manageBloomCoreCount()
		{
			int count = 0;
			int oldestBloomCoreIndex = -1;
			for (int i = 0; i < Main.npc.Length; i++)
			{
				NPC npc = Main.npc[i];
				if (npc.type == ModContent.NPCType<BloomCore>())
				{
					count++;
					if (oldestBloomCoreIndex == -1)
						oldestBloomCoreIndex = i;
					if (Main.npc[i].ai[0] > Main.npc[oldestBloomCoreIndex].ai[0]) // this might be unneeded. optimization probably not worth it tho
						oldestBloomCoreIndex= i;
				}
					
			}
			if (count >= BLOOM_CORE_LIMIT) 
				return oldestBloomCoreIndex;
			else 
				return -1;
		}
	}
}
