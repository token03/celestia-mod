using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Celestia.Content.Items.Weapons.GuobaStaff
{
	public class Guoba : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Guoba");
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;

			Main.projPet[Projectile.type] = true; 

			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true; 
			ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true; 
		}

		public sealed override void SetDefaults() {
			Projectile.width = 18;
			Projectile.height = 28;
			Projectile.tileCollide = false; // Makes the minion go through tiles freely

			// These below are needed for a minion weapon
			Projectile.friendly = true; // Only controls if it deals damage to enemies on contact (more on that later)
			Projectile.minion = true; // Declares this as a minion (has many effects)
			Projectile.DamageType = DamageClass.Summon; // Declares the damage type (needed for it to deal damage)
			Projectile.minionSlots = 1f; // Amount of slots this minion occupies from the total minion slots available to the player (more on that later)
			Projectile.penetrate = -1; // Needed so the minion doesn't despawn on collision with enemies or tiles
		}

		public override bool? CanCutTiles()
		{
			return false;
		}


		public override void AI()
		{
			Player owner = Main.player[Projectile.owner];

			if (!CheckActive(owner))
			{
				return;
			}

			Projectile.velocity = new Vector2(0, 2);
			float maxDetectRadius = 300f;
			float projSpeed = 5f;

			List<NPC> inRangeNPCs = FindNPCsInRange(maxDetectRadius);

			if (!inRangeNPCs.Any())
				return;

			if (Projectile.ai[0] == 30)
			{
				foreach (NPC npc in inRangeNPCs)
				{
					Projectile.NewProjectile(Projectile.GetSource_FromAI(),
										Projectile.Center,
										Vector2.Normalize(npc.position - Projectile.Center) * projSpeed,
										ProjectileID.BulletHighVelocity, Projectile.damage, 5, Projectile.owner);
				}
				Projectile.ai[0] = 0;
			}
			else
			{
				Projectile.ai[0]++;
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.velocity.Y = 0;
			return false;
		}

		private bool CheckActive(Player owner)
		{
			if (owner.dead || !owner.active)
			{
				owner.ClearBuff(ModContent.BuffType<GuobaBuff>());

				return false;
			}

			if (owner.HasBuff(ModContent.BuffType<GuobaBuff>()))
			{
				Projectile.timeLeft = 2;
			}

			return true;
		}

		private List<NPC> FindNPCsInRange(float maxDetectRadius)
		{
			List<NPC> inRangeNPCs = new List<NPC>();

			for (int i = 0; i < Main.maxNPCs; i++)
			{
				NPC target = Main.npc[i];

				if (target.CanBeChasedBy() && Vector2.Distance(target.Center, Projectile.Center) < maxDetectRadius)
					inRangeNPCs.Add(target);
			}

			return inRangeNPCs;
		}
	}
}
