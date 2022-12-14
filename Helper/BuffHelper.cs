using Celestia.Content.Buffs.Elements;
using Terraria;

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
        public static bool pyroDetect(NPC npc, Player player, int damage)
        {
            if (npc.HasBuff<Electro>())
            {
                // overload
                return true;
            }
            else if (npc.HasBuff<Hydro>())
            {
                // vaporize 1.5x
                return true;
            }
            else if (npc.HasBuff<Cryo>())
            {
                // melt 2x
                return true;
            }
            else if (npc.HasBuff<Dendro>())
            {
                // burning
                return true;
            }
            else if (npc.HasBuff<Anemo>())
            {
                // swirl
                return true;
            }
            return false;
        }
        public static bool cryoDetect(NPC npc, Player player, int damage)
        {
            if (npc.HasBuff<Pyro>())
            {
                // melt 1.5x
                return true;
                return false;
            }
            else if (npc.HasBuff<Hydro>())
            {
                // frozen
                return true;
            }
            else if (npc.HasBuff<Electro>())
            {
                // superconduct
                return true;
            }
            else if (npc.HasBuff<Dendro>())
            {
                // quicken
                return true;
            }
            else if (npc.HasBuff<Anemo>())
            {
                // swirl
                return true;
            }
            return false;
        }
        public static bool dendroDetect(NPC npc, Player player, int damage)
        {
            if (npc.HasBuff<Pyro>())
            {
                // burning
                return true;
            }
            else if (npc.HasBuff<Hydro>())
            {
                // bloom
                return true;
            }
            else if (npc.HasBuff<Electro>())
            {
                // quicken
                return true;
            }
            return false;
        }
        public static bool anemoDetect(NPC npc, Player player, int damage)
        {
            if (npc.HasBuff<Pyro>())
            {
                // swirl
                return true;
            }
            else if (npc.HasBuff<Hydro>())
            {
                // swirl
                return true;
            }
            else if (npc.HasBuff<Cryo>())
            {
                // swirl
                return true;
            }
            else if (npc.HasBuff<Dendro>())
            {
                // swirl
                return true;
            }
            return false;
        }
        public static bool geoDetect(NPC npc, Player player, int damage)
        {
            if (npc.HasBuff<Pyro>())
            {
                // crystalize
                return true;
            }
            else if (npc.HasBuff<Hydro>())
            {
                // crystalize
                return true;
            }
            else if (npc.HasBuff<Cryo>())
            {
                // crystalize
                return true;
            }
            else if (npc.HasBuff<Dendro>())
            {
                // crystalize
                return true;
            }
            return false;
        }
    }
}
