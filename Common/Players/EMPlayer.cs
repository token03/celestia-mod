using Terraria.ModLoader;

namespace Celestia.Common.Players
{
	public class EMPlayer : ModPlayer
    {
		public int ElementalMastery { get; set; }

		public override void ResetEffects()
        {
            ElementalMastery = 0;
        }
    }
}
