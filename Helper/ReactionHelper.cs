using Celestia.Content.Buffs.Elements;
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
                Overload.applyOverload(target, 1); // applies debuff 
                target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Pyro>())); // removes debuff
                return true; // returns true so the call can know not to apply base element
            } 
            else if (target.HasBuff<Hydro>())
            {
                // electrocharged
                return true;
            } 
            else if (target.HasBuff<Cryo>())
            {
                // superconduct
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
            return false;
        }
        public static bool hydroDetect(NPC target, Player player, int damage)
        {
            if (target.HasBuff<Pyro>())
            {
                // vaporize 2x
                Main.NewText("BOOM! hydro on pyro");
                Vaporize.applyVaporize(target, 1, damage, false);
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
            return false;
        }
        public static bool pyroDetect(NPC target, Player player, int damage)
        {
            if (target.HasBuff<Electro>())
            {
                // overload
                Main.NewText("BOOM (pyro on electro)!"); // 
                Overload.applyOverload(target, damage);
                target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Electro>()));
                return true;
            }
            else if (target.HasBuff<Hydro>())
            {
                // vaporize 1.5x
                Main.NewText("BOOM! pyro on hydro");
                Vaporize.applyVaporize(target, 1, damage, true);
                target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Hydro>()));
                return true;
            }
            else if (target.HasBuff<Cryo>())
            {
                // melt 2x            
                Main.NewText("BOOM! pyro on cryo");
                Melt.applyMelt(target, 1, damage, false);
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
            return false;
        }
        public static bool cryoDetect(NPC target, Player player, int damage)
        {
            if (target.HasBuff<Pyro>())
            {
                // melt 1.5x      
                Main.NewText("BOOM! cryo on pyro");
                Melt.applyMelt(target, 1, damage, true);
                target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Pyro>()));
                return true;
            }
            else if (target.HasBuff<Hydro>())
            {
                // frozen
                return true;
            }
            else if (target.HasBuff<Electro>())
            {
                // superconduct
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
                Main.NewText("boof");
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
