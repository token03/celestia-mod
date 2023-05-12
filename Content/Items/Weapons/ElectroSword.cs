using Celestia.Common.Players;
using Celestia.Content.Buffs.Elements;
using Celestia.Helper;
using Microsoft.Xna.Framework;
using System.Diagnostics.Tracing;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Celestia.Content.Items.Weapons
{
	public class ElectroSword : ModItem
    {
		private int swings;
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("This is a basic modded sword.");
        }
		
        public override void SetDefaults()
        {
            Item.damage = 25;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 4;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.knockBack = 6;
            Item.value = 10000;
			Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
			Item.shootSpeed = 10;
			swings = 0;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
			swings++;
			int visionElement = player.GetModPlayer<CelestiaPlayer>().Vision;
			if (swings > 2 && visionElement != -1)
			{
				if (!ReactionHelper.ElementReaction(target, player, hit.Damage, visionElement))
					target.AddBuff(visionElement, 1800);
				swings = 0;
				Main.NewText(swings);
			}
			else
			{
				if (!ReactionHelper.electroDetect(target, player, hit.Damage)) // checks if a reactive element is not applied
					target.AddBuff(ModContent.BuffType<Electro>(), 1800); // if a reactive element is not applied, apply base element
				Main.NewText(swings);
			}
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool? UseItem(Player player)
		{	
			CelestiaPlayer burstPlayer = player.GetModPlayer<CelestiaPlayer>();
			if (player.altFunctionUse == 2 && burstPlayer.CurrentEnergy >= burstPlayer.MaxEnergy)
			{
				// NONE OF THIS SHIT WORKS? WHY? SOMEONE FIX!
				// CURRENTLY IT JUST SWINGS WHEN RIGHT CLICK? WHY???
				Item.channel = true;
				Item.autoReuse = false;
				Item.useStyle = ItemUseStyleID.RaiseLamp;
				Projectile.NewProjectile(Item.GetSource_ItemUse(Item),
									Main.MouseWorld,
									Vector2.Normalize(player.position - Main.MouseWorld) * 5,
									ProjectileID.BulletHighVelocity, 100, 5, player.whoAmI); // PROJECTILE GETS FIRED BUT WHY SWING? JUST HOLD OUT SWORD PLEASE!!!
				burstPlayer.CurrentEnergy = 0;
			}
			else
			{
				Item.channel = false;
				Item.autoReuse = true;
				Item.noMelee = false;
				Item.useStyle = ItemUseStyleID.Swing;
				Item.shoot = ProjectileID.None;
			}
			return false;
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ProjectileID.BulletHighVelocity;
			damage *= 100;
		}
		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
	}
}