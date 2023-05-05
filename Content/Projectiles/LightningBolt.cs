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
	public class LightningBolt : ModProjectile
	{
		private ref float aiTimer => ref Projectile.ai[0];
		private ref float owner => ref Projectile.ai[1];
		private Vector2 targetPos;
		private float speed = 20f; // Increased speed of the projectile

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lightning Bolt");
		}

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

			if (aiTimer % 10 == 0) // Change angle every 10 frames
			{
				angleToTarget = (float)Math.Atan2(targetPos.Y - Projectile.Center.Y, targetPos.X - Projectile.Center.X);
			}

			float distanceToTarget = Vector2.Distance(Projectile.Center, targetPos);

			if (distanceToTarget > speed)
			{
				float randomAngleOffset = Main.rand.Next(-90, 91); // More drastic random angle offset between -90 and 90 degrees
				float totalAngle = angleToTarget + MathHelper.ToRadians(randomAngleOffset);

				Vector2 direction = new Vector2((float)Math.Cos(totalAngle), (float)Math.Sin(totalAngle));
				Projectile.velocity = direction * speed;

				// Rotate sprite based on velocity
				Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + MathHelper.ToRadians(45);
			}
			else
			{
				// Snap to target and update the target position
				Projectile.Center = targetPos;
				targetPos = FindNPCNearMouse(300f);
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			ReactionHelper.electroDetect(target, Main.player[Projectile.owner], damage);
		}

		public override void OnSpawn(IEntitySource source)
		{
			targetPos = FindNPCNearMouse(300f);
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