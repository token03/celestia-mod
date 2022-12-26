using Celestia.Content.Buffs.Elements;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Celestia.Content.NPCs
{
	public class BloomCore : ModNPC
	{
		private bool electroTrigger, pyroTrigger;
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Flutter Slime"); // Automatic from localization files
			Main.npcFrameCount[NPC.type] = 6; // make sure to set this for your modnpcs.

			// Specify the debuffs it is immune to
			NPCID.Sets.DebuffImmunitySets.Add(Type, new NPCDebuffImmunityData
			{
				SpecificallyImmuneTo = new int[] {
					BuffID.Poisoned // This NPC will be immune to the Poisoned debuff.
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
			NPC.ai[0] = 180;
		}

		public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
		{
			damage = 0f;
			return false;
		}

		public override void AI()
		{
			if (NPC.ai[0] == 0)
			{
				NPC.life = 0;
				NPC.active = false;
				Main.NewText("BOOM!");
			}

			if (electroTrigger || pyroTrigger)
			{
				NPC.ai[0]--;
				return;
			}

			if (NPC.HasBuff(ModContent.BuffType<Electro>()))
			{
				NPC.ai[0] = 60;
				electroTrigger = true;
			} else if (NPC.HasBuff(ModContent.BuffType<Pyro>()))
			{
				NPC.ai[0] = 60;
				pyroTrigger = true;
			} else
			{
				NPC.ai[0]--;
			}
		}
	}
}
