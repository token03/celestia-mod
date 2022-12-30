using Celestia.Content.Buffs.Elements;
using System.Linq;
using Terraria.ModLoader;

namespace Celestia.Common.Players
{
	public class CelestiaPlayer : ModPlayer
	{
		public int MaxEnergy { get; set; } = 100;
		public float EnergyRecharge { get; set; }
		public int CurrentEnergy { get; set; }
		public int ElementalMastery { get; set; }

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
					_vision = value;
			}
		}
		public override void ResetEffects()
		{
			EnergyRecharge = 1f;
			ElementalMastery = 0;
			_vision = -1;
		}
	}
}

