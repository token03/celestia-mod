using Celestia.Content.Buffs.Elements;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Celestia.Content.NPCs
{
	public class BloomCore : ModNPC
	{
		private const int NO_TRIGGER = 0;
		private const int ELECTRO_TRIGGER = 1;
		private const int PYRO_TRIGGER = 2;
		private const int LIFE_SPAN = BloomGlobalNPC.LIFE_SPAN;
		private ref float aiTimer => ref NPC.ai[0];
		private ref float aiTrigger => ref NPC.ai[1];
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 1; // make sure to set this for your modnpcs.

			// Specify the debuffs it is immune to
			NPCID.Sets.DebuffImmunitySets.Add(Type, new NPCDebuffImmunityData
			{
				SpecificallyImmuneTo = new int[] {
					ModContent.BuffType<Hydro>(),
					ModContent.BuffType<Dendro>(),
					ModContent.BuffType<Cryo>(),
					ModContent.BuffType<Geo>(),
					ModContent.BuffType<Anemo>(),
				}
			});
		}

		public override void SetDefaults()
		{
			NPC.width = 36; // The width of the npc's hitbox (in pixels)
			NPC.height = 36; // The height of the npc's hitbox (in pixels)
			NPC.aiStyle = -1; // This npc has a completely unique AI, so we set this to -1. The default aiStyle 0 will face the player, which might conflict with custom AI code.
			NPC.damage = 0; // The amount of damage that this npc deals
			NPC.defense = 0; // The amount of defense that this npc has
			NPC.lifeMax = 1; // The amount of health that this npc has
			NPC.HitSound = SoundID.NPCHit1; // The sound the NPC will make when being hit.
			NPC.DeathSound = SoundID.NPCDeath1; // The sound the NPC will make when it dies.
			NPC.value = 0f; // How many copper coins the NPC will drop when killed.
			aiTimer = 0;
			aiTrigger = NO_TRIGGER;
		}

		public override bool? CanBeHitByItem(Player player, Item item)
		{
			return aiTimer != LIFE_SPAN;
		}

		public override bool? CanBeHitByProjectile(Projectile projectile)
		{
			return aiTimer != LIFE_SPAN;
		}

		public override bool SpecialOnKill()
		{
			if (NPC.GetGlobalNPC<BloomGlobalNPC>().OrginPlayer == null)
			{
				return false;
			}

			Player orginPlayer = NPC.GetGlobalNPC<BloomGlobalNPC>().OrginPlayer;
			Main.NewText("Owner: " + orginPlayer.name);

			switch (aiTrigger)
			{
				case NO_TRIGGER:
					Projectile.NewProjectile(NPC.GetSource_Death(), NPC.position, new Vector2(0, 2), ProjectileID.BallofFire,
				NPC.GetGlobalNPC<BloomGlobalNPC>().BaseDamage, 0, orginPlayer.whoAmI);
					break;
				case ELECTRO_TRIGGER:
					break;
				case PYRO_TRIGGER:
					break;
			}

			return true;
		}
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.RemoveWhere((IItemDropRule dropRule) => true, includeGlobalDrops: true);
		}

		public override void AI()
		{

			if (aiTimer >= LIFE_SPAN)
			{
				NPC.SimpleStrikeNPC(1, 0, crit: false, noPlayerInteraction: true);
				return;
			}

			if (aiTrigger is ELECTRO_TRIGGER or PYRO_TRIGGER)
			{
				aiTimer++;
				return;
			}
			
			if (NPC.HasBuff(ModContent.BuffType<Electro>()))
			{
				aiTimer = LIFE_SPAN - 10;
				aiTrigger = ELECTRO_TRIGGER;
				return;
			} 
			else if (NPC.HasBuff(ModContent.BuffType<Pyro>()))
			{
				aiTimer = LIFE_SPAN - 10;
				aiTrigger = PYRO_TRIGGER;
				return;
			} 

			aiTimer++;
		}
	}

	public class BloomGlobalNPC : GlobalNPC
	{
		public const int LIFE_SPAN = 2000;
		public override bool InstancePerEntity => true;
		public Player OrginPlayer { get; set; }
		public int BaseDamage { get; set; }
	}
}
