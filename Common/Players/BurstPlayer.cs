using Terraria.ModLoader;

namespace Celestia.Common.Players
{
	public class BurstPlayer : ModPlayer
	{
		public int MaxEnergy { get; set; } = 100;
		public double EnergyRecharge { get; set; }
		public int CurrentEnergy { get; set; }

		public override void ResetEffects()
		{
			EnergyRecharge = 0;
		}

	}
}

