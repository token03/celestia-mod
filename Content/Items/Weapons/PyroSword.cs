using Celestia.Content.Buffs.Elements;
using Celestia.Helper;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Celestia.Content.Items.Weapons
{
	public class PyroSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Kl33");
        }

        public override void SetDefaults()
        {
            Item.damage = 25;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 4;
            Item.useAnimation = 4;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!ReactionHelper.pyroDetect(target, player, hit.Damage))
            {
                target.AddBuff(ModContent.BuffType<Pyro>(), 1800);
            }
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