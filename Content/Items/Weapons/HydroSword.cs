using Celestia.Content.Buffs.Elements;
using Celestia.Content.Projectiles;
using Celestia.Helper;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Celestia.Content.Items.Weapons
{
	public class HydroSword : ModItem
    {
		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 42;

			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.autoReuse = true;

			Item.DamageType = DamageClass.Melee;
			Item.damage = 50;
			Item.knockBack = 6;
			Item.crit = 6;

			Item.value = Item.buyPrice(gold: 5);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item1;

			Item.shoot = ModContent.ProjectileType<HydroSwordProjectile>(); // ID of the projectiles the sword will shoot
			Item.shootSpeed = 8f; // Speed of the projectiles the sword will shoot

		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
            if (!ReactionHelper.hydroDetect(target, player, hit.Damage))
            {
                target.AddBuff(ModContent.BuffType<Hydro>(), 1800);
            }
        }


		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float spawnDistance = 100f; // Adjust this value to change how far above the player's head the projectiles spawn
			float speed = 10f; // Adjust this value to change the speed of the projectiles

			// The initial angle depends on which direction the player is facing
			float initialAngle = player.direction == 1 ? MathHelper.ToRadians(45) : MathHelper.ToRadians(135);

			for (int i = 0; i < 3; i++)
			{
				Vector2 spawnPos = player.Center + new Vector2(0, -spawnDistance);

				float angle = initialAngle + MathHelper.ToRadians(5 * (i - 1));
				Vector2 direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
				Vector2 projVelocity = direction * speed;

				Projectile.NewProjectile(source, spawnPos, projVelocity, type, damage, knockback, player.whoAmI);
			}

			return false;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Waterleaf, 5);
			recipe.AddIngredient(ItemID.Excalibur, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}


	}
}