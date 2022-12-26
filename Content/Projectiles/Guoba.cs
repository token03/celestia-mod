using FullSerializer.Internal;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Celestia.Content.Projectiles
{
	public class Guoba : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Guoba");

			ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.width = 8; // The width of projectile hitbox
			Projectile.height = 8; // The height of projectile hitbox
			Projectile.aiStyle = 0; // The ai style of the projectile (0 means custom AI). For more please reference the source code of Terraria
			Projectile.DamageType = DamageClass.Melee; // What type of damage does this projectile affect?
			Projectile.friendly = true; // Can the projectile deal damage to enemies?
			Projectile.hostile = false; // Can the projectile deal damage to the player?
			Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
			Projectile.light = 1f; // How much light emit around the projectile
			Projectile.tileCollide = true; // Can the projectile collide with tiles?
			Projectile.timeLeft = 600; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
		}

		public override void AI()
		{
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
			} else
			{
				Projectile.ai[0]++;
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.velocity.Y = 0;
			return false;
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
