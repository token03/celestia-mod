using Celestia.Content.Buffs.Elements;
using Celestia.Content.Buffs.Reactions;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Celestia.Content.Projectiles
{
	public class ElectroChargedProjectile : ModProjectile
	{
		private NPC trackedNPC;
		private ref float aiTimer => ref Projectile.ai[0];
		private ref float aiTracker => ref Projectile.ai[1];
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
			Projectile.tileCollide = false; // Can the projectile collide with tiles?
			Projectile.timeLeft = 600;

		}
		public override void OnSpawn(IEntitySource source)
		{
			trackedNPC = Main.npc[(int)aiTracker];
		}
		public override void AI()
		{
			float maxDetectRadius = 300f;
			float projSpeed = 5f;

			if (trackedNPC.HasBuff<ElectroCharged>())
			{
				Projectile.timeLeft = 2;
			}

			Projectile.position.X = trackedNPC.position.X;
			Projectile.position.Y = trackedNPC.position.Y - 10;

			List<NPC> inRangeNPCs = FindNPCsInRange(maxDetectRadius);

			if (!inRangeNPCs.Any())
				return;
;			if (aiTimer == 30)
			{
				foreach (NPC npc in inRangeNPCs)
				{
					Projectile.NewProjectile(Projectile.GetSource_FromAI(),
										Projectile.Center,
										Vector2.Normalize(npc.position - Projectile.Center) * projSpeed,
										ProjectileID.TerraBeam, Projectile.damage, 5, Projectile.owner);
				}
				aiTimer = 0;
				return;
			}
			aiTimer++;
		}

		private List<NPC> FindNPCsInRange(float maxDetectRadius)
		{
			List<NPC> inRangeNPCs = new List<NPC>();

			for (int i = 0; i < Main.maxNPCs; i++)
			{
				NPC target = Main.npc[i];

				if (target.CanBeChasedBy() && Vector2.Distance(target.Center, Projectile.Center) < maxDetectRadius && target.HasBuff<Hydro>()) 
					inRangeNPCs.Add(target);
			}

			return inRangeNPCs;
		}
	}
}
