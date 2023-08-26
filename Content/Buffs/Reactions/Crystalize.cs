using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Celestia.Content.Buffs.Reactions
{
	public class Crystalize : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Crystalize"); // Buff display name
			// Description.SetDefault("dongo"); // Buff description
			Main.debuff[Type] = false;  // Is it a debuff?
			Main.pvpBuff[Type] = true; // Players can give other players buffs, which are listed as pvpBuff
			Main.buffNoSave[Type] = true; // Causes this buff not to persist when exiting and rejoining the world
		}

		public override void Update(Player player, ref int buffIndex)
		{
			CrystalizePlayer crystalizePlayer = player.GetModPlayer<CrystalizePlayer>();
			player.statDefense += 5;
			crystalizePlayer.Crystalize = true;
			if (crystalizePlayer.ShieldHealth <= 0)
				player.DelBuff(player.FindBuffIndex(ModContent.BuffType<Crystalize>()));
		}
	}

	public class CrystalizePlayer : ModPlayer
	{
		public bool Crystalize { get; set; }
		public int ShieldHealth { get; set; }

		public override void ResetEffects()
		{
			Crystalize = false;
			if (!Player.HasBuff(ModContent.BuffType<Crystalize>()))
				ShieldHealth = 0;
		}

		public override bool ConsumableDodge(Player.HurtInfo info)
		{
			int damage = info.Damage;
			int damageToDeal = Math.Max(damage - ShieldHealth, 0); // reduces damage by shieldhealth and down to 0

			if (ShieldHealth > 0)
			{
				SoundEngine.PlaySound(SoundID.Item50, Player.position); // plays sound effect
				Main.NewText("Shield:" + ShieldHealth + "Damage:" + damageToDeal);
				Player.noKnockback = true;
				// maybe add sound effect if the shield is broken; maybe also change color of combattext from shield.
			}
			else
				Player.noKnockback = false;

			ShieldHealth = Math.Max(ShieldHealth - damage, 0); //  reduces shieldhealth by damage and down to 0
			info.Damage = damageToDeal;

			if (damageToDeal > 0)
			{
				return false;
			}
			else
			{
				// make player imune
				Player.immune = true;
				Player.immuneNoBlink = true;
				Player.immuneTime = 60;

				return true;
			}
		}

		public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
		{
			if (Crystalize)
			{
				r = 200;
				g = 150;
				b = 23;
			}

		}
	}
}
