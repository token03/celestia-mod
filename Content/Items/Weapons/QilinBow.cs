using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Celestia.Content.Items.Weapons
{
	 public class QilinBow : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 2;
		}

		public override void SetDefaults()
		{
			NPC.width = 32;
			NPC.height = 32;
			NPC.aiStyle = 1;
			NPC.damage = 7;
			NPC.defense = 2;
			NPC.lifeMax = 25;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = 25f;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.OverworldDay.Chance * 0.1f;
		}
	}
}
