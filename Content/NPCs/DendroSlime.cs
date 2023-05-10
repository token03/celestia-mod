using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Celestia.Content.NPCs
{
	public class DendroSlime : ModNPC
	{
		private enum ActionState
		{
			Asleep,
			Notice,
			Jump,
			Fall
		}
	
		private enum Frame
		{
			Static,
			Moving
		}

		public ref float AI_State => ref NPC.ai[0];
		public ref float AI_Timer => ref NPC.ai[1];
		public ref float AI_FlutterTime => ref NPC.ai[2];
		private float jumpVelocity;
		private int jumpDuration;

		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 2; 

			NPCID.Sets.DebuffImmunitySets.Add(Type, new NPCDebuffImmunityData
			{
				SpecificallyImmuneTo = new int[] {
					BuffID.Poisoned 
				}
			});
		}

		public override void SetDefaults()
		{
			NPC.width = 36; 
			NPC.height = 36; 
			NPC.aiStyle = -1;
			NPC.damage = 7; 
			NPC.defense = 2;
			NPC.lifeMax = 25;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1; 
			NPC.value = 25f;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.OverworldDaySlime.Chance * 0.1f;
		}

		// Our AI here makes our NPC sit waiting for a player to enter range, jumps to attack, flutter mid-fall to stay afloat a little longer, then falls to the ground. Note that animation should happen in FindFrame
		public override void AI()
		{
			// The npc starts in the asleep state, waiting for a player to enter range
			switch (AI_State)
			{
				case (float)ActionState.Asleep:
					FallAsleep();
					break;
				case (float)ActionState.Notice:
					Notice();
					break;
				case (float)ActionState.Jump:
					Jump();
					break;
				case (float)ActionState.Fall:
					if (NPC.velocity.Y == 0)
					{
						NPC.velocity.X = 0;
						AI_State = (float)ActionState.Asleep;
						AI_Timer = 0;
					}

					break;
			}
		}

		// Here in FindFrame, we want to set the animation frame our npc will use depending on what it is doing.
		// We set npc.frame.Y to x * frameHeight where x is the xth frame in our spritesheet, counting from 0. For convenience, we have defined a enum above.
		public override void FindFrame(int frameHeight)
		{
			NPC.spriteDirection = NPC.direction;

			// For the most part, our animation matches up with our states.
			switch (AI_State)
			{
				case (float)ActionState.Asleep:
					NPC.frame.Y = (int)Frame.Static * frameHeight;
					break;
				case (float)ActionState.Notice:
					// Going from Notice to Asleep makes our npc look like it's crouching to jump.
					if (AI_Timer < 10)
					{
						NPC.frame.Y = (int)Frame.Static * frameHeight;
					}
					else
					{
						NPC.frame.Y = (int)Frame.Static * frameHeight;
					}

					break;
				case (float)ActionState.Jump:
					NPC.frame.Y = (int)Frame.Moving * frameHeight;
					break;
				case (float)ActionState.Fall:
					NPC.frame.Y = (int)Frame.Moving * frameHeight;
					break;
			}
		}

		public override bool? CanFallThroughPlatforms()
		{
			if (AI_State == (float)ActionState.Fall && NPC.HasValidTarget && Main.player[NPC.target].Top.Y > NPC.Bottom.Y)
			{
				return true;
			}

			return false;
		}

		private void FallAsleep()
		{
			// TargetClosest sets npc.target to the player.whoAmI of the closest player.
			// The faceTarget parameter means that npc.direction will automatically be 1 or -1 if the targeted player is to the right or left.
			// This is also automatically flipped if npc.confused.
			NPC.TargetClosest(true);

			// Now we check the make sure the target is still valid and within our specified notice range (500)
			if (NPC.HasValidTarget && Main.player[NPC.target].Distance(NPC.Center) < 500f)
			{
				// Since we have a target in range, we change to the Notice state. (and zero out the Timer for good measure)
				AI_State = (float)ActionState.Notice;
				AI_Timer = 0;
			}
		}

		private void Notice()
		{
			// If the targeted player is in attack range (250).
			if (Main.player[NPC.target].Distance(NPC.Center) < 250f)
			{
				// Here we use our Timer to wait .33 seconds before actually jumping. In FindFrame you'll notice AI_Timer also being used to animate the pre-jump crouch
				AI_Timer++;

				if (AI_Timer >= 20)
				{
					AI_State = (float)ActionState.Jump;
					AI_Timer = 0;
				}
			}
			else
			{
				NPC.TargetClosest(true);

				if (!NPC.HasValidTarget || Main.player[NPC.target].Distance(NPC.Center) > 500f)
				{
					// Out targeted player seems to have left our range, so we'll go back to sleep.
					AI_State = (float)ActionState.Asleep;
					AI_Timer = 0;
				}
			}
		}

		private void Jump()
		{
			AI_Timer++;

			if (AI_Timer == 1)
			{
				// Generate random values for jump velocity and duration on the server
				if (Main.netMode != NetmodeID.MultiplayerClient)
				{
					jumpVelocity = Main.rand.NextFloat(8f, 12f); // Random jump velocity between 8f and 12f
					jumpDuration = Main.rand.Next(30, 51); // Random jump duration between 30 and 50 frames
					NPC.netUpdate = true; // Flag the NPC for syncing
				}

				// Apply the initial velocity
				NPC.velocity = new Vector2(NPC.direction * 2, -jumpVelocity);
			}
			else if (AI_Timer > jumpDuration)
			{
				AI_State = (float)ActionState.Fall;
				AI_Timer = 0;
			}
		}

		public override void SendExtraAI(BinaryWriter writer)
		{
			writer.Write(jumpVelocity);
			writer.Write(jumpDuration);
		}

		public override void ReceiveExtraAI(BinaryReader reader)
		{
			jumpVelocity = reader.ReadSingle();
			jumpDuration = reader.ReadInt32();
		}

		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			Main.NewText("Hello");
		}
	}
}
