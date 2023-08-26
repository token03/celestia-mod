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
	public class HydroSwordProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 32; // The width of projectile hitbox
			Projectile.height = 32; // The height of projectile hitbox
			Projectile.DamageType = DamageClass.Melee; // What type of damage does this projectile affect?
			Projectile.friendly = true; // Can the projectile deal damage to enemies?
			Projectile.hostile = false; // Can the projectile deal damage to the player?
			Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
			Projectile.light = 1f; // How much light emit around the projectile
			Projectile.tileCollide = false; // Can the projectile collide with tiles?
			Projectile.timeLeft = 600; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			Projectile.aiStyle = 81;
		}


		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (!ReactionHelper.hydroDetect(target, Main.player[Projectile.owner], hit.Damage))
			{
				target.AddBuff(ModContent.BuffType<Hydro>(), 1800);
			}
		}
	}
}
