using Celestia.Content.Buffs.Elements;
using Celestia.Content.Buffs.Reactions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace Celestia.Common.GlobalNPCs
{
	public class GlobalNPCDraw : GlobalNPC
    {
		public override bool InstancePerEntity => true;

		// Create a static dictionary to store the buff types and their corresponding icon textures
		private static Dictionary<int, Texture2D> BuffIcons = new Dictionary<int, Texture2D>();

		public override void SetStaticDefaults()
		{
			// Load the icon textures and add them to the dictionary
			BuffIcons.Add(ModContent.BuffType<Electro>(), ModContent.Request<Texture2D>("Celestia/Content/Buffs/Elements/electroP", AssetRequestMode.ImmediateLoad).Value);
			BuffIcons.Add(ModContent.BuffType<Pyro>(), ModContent.Request<Texture2D>("Celestia/Content/Buffs/Elements/pyroP", AssetRequestMode.ImmediateLoad).Value);
			BuffIcons.Add(ModContent.BuffType<Dendro>(), ModContent.Request<Texture2D>("Celestia/Content/Buffs/Elements/dendroP", AssetRequestMode.ImmediateLoad).Value);
			BuffIcons.Add(ModContent.BuffType<Hydro>(), ModContent.Request<Texture2D>("Celestia/Content/Buffs/Elements/hydroP", AssetRequestMode.ImmediateLoad).Value);
			BuffIcons.Add(ModContent.BuffType<Anemo>(), ModContent.Request<Texture2D>("Celestia/Content/Buffs/Elements/anemoP", AssetRequestMode.ImmediateLoad).Value);
			BuffIcons.Add(ModContent.BuffType<Geo>(), ModContent.Request<Texture2D>("Celestia/Content/Buffs/Elements/geoP", AssetRequestMode.ImmediateLoad).Value);
			BuffIcons.Add(ModContent.BuffType<Cryo>(), ModContent.Request<Texture2D>("Celestia/Content/Buffs/Elements/cryoP", AssetRequestMode.ImmediateLoad).Value);

		}

		public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
		{
			// Get the icon textures and positions for the active buffs
			var activeBuffIcons = BuffIcons.Where(kv => npc.HasBuff(kv.Key))
				.Select(buffIcon => new
				{
					Texture = buffIcon.Value,
					Position = npc.getRect().TopLeft() - screenPos + new Vector2(npc.getRect().Width / 2f, -buffIcon.Value.Height / 2f)
				});

			// Draw the icons above the NPC
			foreach (var icon in activeBuffIcons)
			{
				spriteBatch.Draw(icon.Texture, icon.Position, null, drawColor, 0f, new Vector2(icon.Texture.Width / 2f, icon.Texture.Height), 1f, SpriteEffects.None, 0f);
			}
		}

		public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (npc.HasBuff<Superconduct>())
            {
                drawColor = Color.GhostWhite;
            }
			else if (npc.HasBuff<ElectroCharged>())
			{
				drawColor = Color.Lavender;
			}
			else if (npc.HasBuff<Quicken>())
			{
				drawColor = Color.DarkOliveGreen;
			}
        }
    }
}
