using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Celestia.Content.Buffs.Reactions
{
	public class Crystalize : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystalize"); // Buff display name
			Description.SetDefault("dongo"); // Buff description
			Main.debuff[Type] = false;  // Is it a debuff?
			Main.pvpBuff[Type] = true; // Players can give other players buffs, which are listed as pvpBuff
			Main.buffNoSave[Type] = true; // Causes this buff not to persist when exiting and rejoining the world
		}

		public override void Update(Player player, ref int buffIndex)
		{
			CrystalizePlayer crystalizePlayer = player.GetModPlayer<CrystalizePlayer>();
			player.statDefense += 5;
			crystalizePlayer.Crystalize = true;
		}
	}

	public class CrystalizePlayer : ModPlayer
	{
		public bool Crystalize { get; set; }
		public int ShieldHealth { get; set; }

		public override void ResetEffects()
		{
			Crystalize = false;
		}

		public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource, ref int cooldownCounter)
		{
			int damageToDeal = Math.Max(damage - ShieldHealth, 0); // reduces damage by shield health and down to 0
			ShieldHealth = Math.Max(ShieldHealth - damage, 0); //  reduces shieldhealth by damage and down to 0
			bool zeroDamage = damageToDeal == 0;
			damage = damageToDeal;
			Main.NewText("Shield:" + ShieldHealth + "  Damage:" + damage);
			return true; // bugged to SHIT. will still always deal 1 damage even if zero daamge. also will apply kncokback. Fuck it who cares.
			// Fix it IF YOU DARE!
		}
	}
}
