using Celestia.Common.Players;
using Celestia.Content.Buffs.Elements;
using Celestia.Content.Buffs.Reactions;
using Celestia.Helper.Reactions;
using Terraria;
using Terraria.ModLoader;

namespace Celestia.Helper
{
    public static class ReactionHelper
    {
        // Each respective detector is called based on elemental application (i.e Applying element calls elementDetect).
        // If another element is detected apply respective reaction to target NPC and remove base element.
        public static bool electroDetect(NPC target, Player player, int damage)
        {
            if (target.HasBuff<Pyro>())
            {
                // overload
                Main.NewText("BOOM! electron on pyro"); // for debuging purposes
                Overload.applyOverload(target, player); // applies debuff 
                target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Pyro>())); // removes debuff
                return true; // returns true so the orginal call can know not to apply base element
            } 
            else if (target.HasBuff<Hydro>())
            {
                // electrocharged
                return true;
            } 
            else if (target.HasBuff<Cryo>())
            {
                // superconduct
                Main.NewText("BOOM! electron on cryo"); // for debuging purposes
                target.AddBuff(ModContent.BuffType<Superconduct>(), 480); // applies debuff 
                target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Cryo>())); // removes debuff
                return true;
            } 
            else if (target.HasBuff<Dendro>())
            {
                // quicken
                return true;
            }
            else if (target.HasBuff<Anemo>())
            {
                // swirl
                return true;
            }
            else if (target.HasBuff<Geo>())
            {
                // crystalize
                return true;
            }
            else if (target.HasBuff<Quicken>())
            {
                // aggravate
                Main.NewText("BOOM! aggravate"); // for debuging purposes
                Aggravate.applyAggravate(target, player, damage); // applies debuff
                return true;
            }
            return false;
        }
        public static bool hydroDetect(NPC target, Player player, int damage)
        {
            if (target.HasBuff<Pyro>())
            {
                // vaporize 2x
                Main.NewText("BOOM! hydro on pyro");
                Vaporize.applyVaporize(target, player, damage, false);
                target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Pyro>()));
                return true;
            }
            else if (target.HasBuff<Electro>())
            {
                // electrocharged
                return true;
            }
            else if (target.HasBuff<Cryo>())
            {
				// frozen
				Main.NewText("BOOM! cryo on electro"); // for debuging purposes
				target.AddBuff(ModContent.BuffType<Frozen>(), 480); // applies debuff 
				target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Cryo>())); // removes debuff
				return true;
            }
            else if (target.HasBuff<Dendro>())
            {
                // bloom
                return true;
            }
            else if (target.HasBuff<Anemo>())
            {
                // swirl
                return true;
            }
            else if (target.HasBuff<Geo>())
            {
                // crystalize
                return true;
            }
            else if (target.HasBuff<Quicken>())
            {
                // bloom 
                return true;
            }
            return false;
        }
        public static bool pyroDetect(NPC target, Player player, int damage)
        {
            if (target.HasBuff<Electro>())
            {
                // overload
                Main.NewText("BOOM (pyro on electro)!"); // 
                Overload.applyOverload(target, player);
                target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Electro>()));
                return true;
            }
            else if (target.HasBuff<Hydro>())
            {
                // vaporize 1.5x
                Main.NewText("BOOM! pyro on hydro");
                Vaporize.applyVaporize(target, player, damage, true);
                target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Hydro>()));
                return true;
            }
            else if (target.HasBuff<Cryo>())
            {
                // melt 2x            
                Main.NewText("BOOM! pyro on cryo");
                Melt.applyMelt(target, player, damage, false);
                target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Cryo>()));
                return true;
            }
            else if (target.HasBuff<Dendro>())
            {
				// burning
                return true;
            }
            else if (target.HasBuff<Anemo>())
            {
                // swirl
                return true;
            }
            else if (target.HasBuff<Geo>())
            {
                // crystalize
                return true;
            }
            else if (target.HasBuff<Quicken>())
            {
                // burning
                return true;
            }
            return false;
        }
        public static bool cryoDetect(NPC target, Player player, int damage)
        {
            if (target.HasBuff<Pyro>())
            {
                // melt 1.5x      
                Main.NewText("BOOM! cryo on pyro");
                Melt.applyMelt(target, player, damage, true);
                target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Pyro>()));
                return true;
            }
            else if (target.HasBuff<Hydro>())
            {
				// frozen
				Main.NewText("BOOM! cryo on electro"); // for debuging purposes
				target.AddBuff(ModContent.BuffType<Frozen>(), 480); // applies debuff 
				target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Hydro>())); // removes debuff
				return true;
            }
            else if (target.HasBuff<Electro>())
            {
                // superconduct
                Main.NewText("BOOM! cryo on electro"); // for debuging purposes
                target.AddBuff(ModContent.BuffType<Superconduct>(), 480); // applies debuff 
                target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Electro>())); // removes debuff
                return true;
            }
            else if (target.HasBuff<Dendro>())
            {
                // quicken
                return true;
            }
            else if (target.HasBuff<Anemo>())
            {
                // swirl
                return true;
            }
            else if (target.HasBuff<Geo>())
            {
                // cryatlize
                return true;
            }
            return false;
        }
        public static bool dendroDetect(NPC target, Player player, int damage)
        {
            if (target.HasBuff<Pyro>())
            {
                // burning
                return true;
            }
            else if (target.HasBuff<Hydro>())
            {
                // bloom
                return true;
            }
            else if (target.HasBuff<Electro>())
            {
                // quicken
                return true;
            }
            else if (target.HasBuff<Quicken>())
            {
                // spread
                Main.NewText("BOOM! spread"); // for debuging purposes
                Spread.applySpread(target, player, damage); // applies debuff
                return true;
            }
            return false;
        }
        public static bool anemoDetect(NPC target, Player player, int damage)
        {
            if (target.HasBuff<Pyro>())
            {
                // swirl
                return true;
            }
            else if (target.HasBuff<Hydro>())
            {
                // swirl
                return true;
            }
            else if (target.HasBuff<Cryo>())
            {
                // swirl
                return true;
            }
            else if (target.HasBuff<Dendro>())
            {
                // swirl
                return true;
            }
            return false;
        }
        public static bool geoDetect(NPC target, Player player, int damage)
        {
            if (target.HasBuff<Pyro>())
            {
                // crystalize
                return true;
            }
            else if (target.HasBuff<Hydro>())
            {
                // crystalize
                return true;
            }
            else if (target.HasBuff<Cryo>())
            {
                // crystalize
                return true;
            }
            else if (target.HasBuff<Dendro>())
            {
                // crystalize 
                return true;
            }
            return false;
        }
    }
}
