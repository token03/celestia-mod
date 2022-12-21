using Terraria.ModLoader;

namespace Celestia.Common.Players
{
	public class BurstPlayer : ModPlayer
	{
		public enum energyGainPerParticle
		{
			SMALL = 2,
			MEDIUM = 5,
			LARGE = 10
		}
		public int currentEnergy;
		public double energyRecharge = 1;

		public int MaxEnergy { get; set; } = 100;

		public override void ResetEffects()
		{
			currentEnergy = 0;
		}

	}
}

