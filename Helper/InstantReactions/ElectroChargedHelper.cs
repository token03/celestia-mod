using Celestia.Content.NPCs;
using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Celestia.Content.Buffs.Reactions;
using Celestia.Content.Projectiles;

namespace Celestia.Helper.InstantReactions
{
	public class ElectroChargedHelper
	{
		public static void applyElectroCharged(NPC npc, Player player, int baseDamage)
		{
			npc.AddBuff(ModContent.BuffType<ElectroCharged>(), 1800);
			Projectile.NewProjectile(player.GetSource_OnHit(npc), npc.position, 
				Vector2.Zero, ModContent.ProjectileType<ElectroChargedProjectile>(),
				baseDamage, 0, player.whoAmI, ai1: npc.whoAmI);
		}
	}
}
