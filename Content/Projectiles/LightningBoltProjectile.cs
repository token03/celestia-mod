using Celestia.Content.Buffs.Elements;
using Celestia.Helper;
using Humanizer.Localisation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Celestia.Content.Projectiles
{
	public class LightningBoltProjectile : ModProjectile
	{
		private ref float aiTimer => ref Projectile.ai[0];
		private Vector2 targetPos;
		private float speed = 20f; // Increased speed of the projectile

		public override void SetDefaults()
		{
			Projectile.width = 8; // The width of projectile hitbox
			Projectile.height = 8; // The height of projectile hitbox
			Projectile.DamageType = DamageClass.Magic; // What type of damage does this projectile affect?
			Projectile.friendly = true; // Can the projectile deal damage to enemies?
			Projectile.hostile = false; // Can the projectile deal damage to the player?
			Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
			Projectile.light = 1f; // How much light emit around the projectile
			Projectile.tileCollide = false; // Can the projectile collide with tiles?
			Projectile.timeLeft = 600; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			Projectile.aiStyle = 0;
		}

		float angleToTarget;

		public override void AI()
		{
			aiTimer++;

			if (aiTimer % 20 == 0) // change angle every 20 frames
			{
				Vector2 directionToTarget = targetPos - Projectile.Center;
				angleToTarget = (float)Math.Atan2(directionToTarget.Y, directionToTarget.X);
			}

			float distanceToTarget = Vector2.Distance(Projectile.Center, targetPos);

			if (distanceToTarget > speed)
			{
				float randomAngleOffset = Main.rand.Next(-30, 31); // More drastic random angle offset between -30 and 30 degrees
				float totalAngle = angleToTarget + MathHelper.ToRadians(randomAngleOffset);

				Vector2 direction = new Vector2((float)Math.Cos(totalAngle), (float)Math.Sin(totalAngle));
				Projectile.velocity = direction * speed;

				// Rotate sprite based on velocity
				Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + MathHelper.ToRadians(45);

				// Generate dust along the path of the projectile
				Vector2 startPosition = Projectile.position;
				Vector2 endPosition = Projectile.position + Projectile.velocity;
				Vector2 directionNormalized = (endPosition - startPosition);
				directionNormalized.Normalize();
				for (float i = 0; i <= Projectile.velocity.Length(); i += 4f)  // The smaller the increment, the more solid the line will be
				{
					Dust dust = Dust.NewDustPerfect(startPosition + directionNormalized * i, DustID.ShadowbeamStaff, null, 100, default, 1.5f);
					dust.noGravity = true;
				}
			}
			else
			{
				// Snap to target and update the target position
				Projectile.Center = targetPos;
			}
		}


		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (!ReactionHelper.electroDetect(target, Main.player[Projectile.owner], hit.Damage)) // checks if a reactive element is not applied
				target.AddBuff(ModContent.BuffType<Electro>(), 1800); // if a reactive element is not applied, apply base element
		}

		public override void OnSpawn(IEntitySource source)
		{
			targetPos = FindNPCNearMouse(500f);
		}
		private Vector2 FindNPCNearMouse(float maxDetectRadius)
		{
			for (int i = 0; i < Main.maxNPCs; i++)
			{
				NPC checkNPC = Main.npc[i];

				if (checkNPC.CanBeChasedBy() && Vector2.Distance(checkNPC.Center, Main.MouseWorld) < maxDetectRadius)
					return checkNPC.position;
			}

			return Main.MouseWorld;
		}
	}
}