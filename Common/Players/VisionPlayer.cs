using Celestia.Content.Buffs.Elements;
using System.Diagnostics.Metrics;
using System.Linq;
using Terraria.ModLoader;

namespace Celestia.Common.Players
{
	public class VisionPlayer : ModPlayer
	{
		/// <summary>
		/// Should always be equal to either <b>ModContent.BuffType<Element>()</b> or -1 (No Vision)
		/// </summary>
		private int _vision;
		public int Vision
		{
			get { return _vision; }
			set
			{
				if (new int[] // THIS JUST CHECKS IF GIVE VALUE IS AN ACTUAL ELEMENT! 
				{
					ModContent.BuffType<Pyro>(),
					ModContent.BuffType<Anemo>(),
					ModContent.BuffType<Geo>(),
					ModContent.BuffType<Cryo>(),
					ModContent.BuffType<Hydro>(),
					ModContent.BuffType<Dendro>(),
					ModContent.BuffType<Electro>(), // (PLEASE REFACTOR IF YOU CAN DO BETTER)
				}.Contains(value))
				{
					_vision = value;
				}
			}
		}

		public override void ResetEffects()
		{
			_vision = -1;
		}
	}
}
