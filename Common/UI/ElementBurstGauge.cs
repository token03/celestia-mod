using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Celestia.Common.Players;
using Terraria.ModLoader;
using Terraria.GameContent;
using System.Collections.Generic;

namespace Celestia.UI
{
	// Code compeltly based off ExampleMod. Probably change later to suit our needs.
	internal class ElementBurstGauge : UIState
	{
		private UIElement area;
		private UIImage barFrame;
		private Color gradientA;
		private Color gradientB;

		public override void OnInitialize()
		{
			area = new UIElement();
			area.Left.Set(-area.Width.Pixels - 600, 1f); // Place the resource bar to the left of the hearts.
			area.Top.Set(30, 0f); // Placing it just a bit below the top of the screen.
			area.Width.Set(182, 0f); // We will be placing the following 2 UIElements within this 182x60 area.
			area.Height.Set(60, 0f);

			barFrame = new UIImage(ModContent.Request<Texture2D>("Celestia/Common/UI/ElementBurstGauge")); // Frame of our resource bar
			barFrame.Left.Set(22, 0f);
			barFrame.Top.Set(0, 0f);
			barFrame.Width.Set(138, 0f);
			barFrame.Height.Set(34, 0f);

			gradientA = new Color(0, 255, 135); // Green
			gradientB = new Color(96, 239, 255); // Light blue

			area.Append(barFrame);
			Append(area);
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			base.DrawSelf(spriteBatch);

			BurstPlayer modPlayer = Main.LocalPlayer.GetModPlayer<BurstPlayer>();

			// create ratio and normalize between 0 and 1
			float energyRatio = (float)modPlayer.CurrentEnergy / modPlayer.MaxEnergy;
			energyRatio = Utils.Clamp(energyRatio, 0f, 1f);

			// Here we get the screen dimensions of the barFrame element, then tweak the resulting rectangle to arrive at a rectangle within the barFrame texture that we will draw the gradient. These values were measured in a drawing program.
			Rectangle hitbox = barFrame.GetInnerDimensions().ToRectangle();
			hitbox.X += 12;
			hitbox.Width -= 24;
			hitbox.Y += 8;
			hitbox.Height -= 16;

			// Now, using this hitbox, we draw a gradient by drawing vertical lines while slowly interpolating between the 2 colors.
			int left = hitbox.Left;
			int right = hitbox.Right;
			int steps = (int)((right - left) * energyRatio);
			for (int i = 0; i < steps; i += 1)
			{
				// float percent = (float)i / steps; // Alternate Gradient Approach
				float percent = (float)i / (right - left);
				spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Rectangle(left + i, hitbox.Y, 1, hitbox.Height), Color.Lerp(gradientA, gradientB, percent));
			}
		}
	}

	class BurstGaugeUISystem : ModSystem
	{
		private UserInterface BurstGaugeUI;

		internal ElementBurstGauge ElementBurstGauge;

		public override void Load()
		{
			// All code below runs only if we're not loading on a server
			if (!Main.dedServ)
			{
				ElementBurstGauge = new();
				BurstGaugeUI = new();
				BurstGaugeUI.SetState(ElementBurstGauge);
			}
		}

		public override void UpdateUI(GameTime gameTime)
		{
			BurstGaugeUI?.Update(gameTime);
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
			if (resourceBarIndex != -1)
			{
				layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
					"ExampleMod: Example Resource Bar",
					delegate
					{
						BurstGaugeUI.Draw(Main.spriteBatch, new GameTime());
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
		}
	}
}
