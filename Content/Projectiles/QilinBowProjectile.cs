using Celestia.Content.Buffs.Elements;
using Celestia.Helper;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Celestia.Content.Projectiles
{
	public class QilinBowProjectile : ModProjectile
	{
		private ref float parent => ref Projectile.ai[1];

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Qilin Bow Projectile");
		}

		public override void SetDefaults()
		{
			Projectile.width = 8; // The width of projectile hitbox
			Projectile.height = 8; // The height of projectile hitbox
			Projectile.DamageType = DamageClass.Ranged; // What type of damage does this projectile affect?
			Projectile.friendly = true; // Can the projectile deal damage to enemies?
			Projectile.hostile = false; // Can the projectile deal damage to the player?
			Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
			Projectile.light = 1f; // How much light emit around the projectile
			Projectile.tileCollide = true; // Can the projectile collide with tiles?
			Projectile.timeLeft = 600; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			Projectile.aiStyle = 1;
		}


		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (!ReactionHelper.cryoDetect(target, Main.player[Projectile.owner], hit.Damage))
			{
				target.AddBuff(ModContent.BuffType<Cryo>(), 1800);
			}
		}

		public override void Kill(int timeLeft)
		{
			Bloom(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.damage, Projectile.knockBack);
		}

		private void Bloom(Vector2 target, int damage, float knockback)
		{
			if (parent != 1)
			{
				Vector2 targetPosition = new Vector2(target.X, target.Y - 200); // set the target position
				float projectileSpeed = 16f; // set the speed of the projectiles

				// Define the five normalized vectors
				Vector2[] directions = new Vector2[]
				{
					new Vector2(0.13f, 0.99f),
					new Vector2(0.25f, 0.96f),
					new Vector2(0f, 1f),
					new Vector2(-0.25f, 0.96f),
					new Vector2(-0.13f, 0.99f)
				};

				// Spawn the projectiles above the target
				foreach (Vector2 direction in directions)
				{
					int projectileType = ModContent.ProjectileType<QilinBowProjectile>(); // set the type of projectile

					// Spawn the projectile
					Projectile.NewProjectile(Projectile.GetSource_Death(), targetPosition, direction * projectileSpeed, projectileType, damage, (int)knockback, Projectile.owner, ai1: 1);
				}
			}
			else
			{

			}
		}
	}
}
