using Celestia.Content.Buffs.Elements;
using Terraria;
using Terraria.ModLoader;

namespace Celestia.Helper
{
    public static class ReactionHelper
    {
        // Each respective detector is called based on elemental application (i.e ElementBuff calls elementDetect).
        // If another element is detected, remove both elements and apply respective reaction to target NPC
        public static bool electroDetect(NPC target, Player player, int damage)
        {
            if (target.HasBuff<Pyro>())
            {
                // overload
                Main.NewText("BOOM! electron on pyro");
                target.GetGlobalNPC<OverloadNPC>().applyOverload(target, damage); // THIS IS COMPLTELY UNESSECARY ATM, CONSIDER CHANGING/
                target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Pyro>())); 
                return true;
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
            return false;
        }
        public static bool hydroDetect(NPC npc, Player player, int damage)
        {
            if (npc.HasBuff<Pyro>())
            {
                // vaporize 2x
                return true;
            }
            else if (npc.HasBuff<Electro>())
            {
                // electrocharged
                return true;
            }
            else if (npc.HasBuff<Cryo>())
            {
                // frozen
                return true;
            }
            else if (npc.HasBuff<Dendro>())
            {
                // bloom
                return true;
            }
            else if (npc.HasBuff<Anemo>())
            {
                // swirl
                return true;
            }
            return false;
        }
        public static bool pyroDetect(NPC target, Player player, int damage)
        {
            if (target.HasBuff<Electro>())
            {
                // overload
                Main.NewText("BOOM (pyro on electro)!");
                target.GetGlobalNPC<OverloadNPC>().applyOverload(target, damage); // THIS IS COMPLTELY UNESSECARY ATM, CONSIDER CHANGING/
                target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Electro>()));
                return true;
            }
            else if (target.HasBuff<Hydro>())
            {
                // vaporize 1.5x
                return true;
            }
            else if (target.HasBuff<Cryo>())
            {
                // melt 2x
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
            return false;
        }
        public static bool cryoDetect(NPC target, Player player, int damage)
        {
            if (target.HasBuff<Pyro>())
            {
                // melt 1.5x
                return true;
                return false;
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
