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
        // DisplayName.SetDefault("a"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("This is a basic modded sword.");
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
            Item.rare = 2;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
			swings = 0;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			swings++;
			int vision = player.GetModPlayer<VisionPlayer>().Vision;
			if (swings > 2 && vision != -1)
			{
				if (!ReactionHelper.visionReaction(target, player, damage, vision))
					target.AddBuff(vision, 1800);
				swings = 0;
				Main.NewText(swings);
			}
			else
			{
				if (!ReactionHelper.electroDetect(target, player, damage)) // checks if a reactive element is not applied
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
			BurstPlayer burstPlayer = player.GetModPlayer<BurstPlayer>();
			if (player.altFunctionUse == 2 && burstPlayer.CurrentEnergy >= burstPlayer.MaxEnergy)
			{
				Item.useStyle = ItemUseStyleID.Thrust;
				Item.shoot = ProjectileID.TerraBeam;
				burstPlayer.CurrentEnergy = 0;
			}
			else
			{
				Item.useStyle = ItemUseStyleID.Swing;
				Item.shoot = ProjectileID.None;
			}
			return false;
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