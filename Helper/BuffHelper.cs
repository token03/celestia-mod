using Celestia.Content.Buffs.Elements;
using Terraria;

namespace Celestia.Helper
{
    public static class ReactionHelper
    {
        // Each respective detector is called based on elemental application (i.e ElementBuff calls elementDetect).
        // If another element is detected, remove both elements and apply respective reaction to target NPC
        public static bool electroDetect(NPC target, Player player)
        {
            if (target.HasBuff<PyroDebuff>())
            {
                // overload
                return true;
            } 
            else if (target.HasBuff<HydroDebuff>())
            {
                // electrocharged
                return true;
            } 
            else if (target.HasBuff<CryoDebuff>())
            {
                // superconduct
                return true;
            } 
            else if (target.HasBuff<DendroDebuff>())
            {
                // quicken
                return true;
            }
            else if (target.HasBuff<AnemoDebuff>())
            {
                // swirl
                return true;
            }
            return false;
        }
        public static bool hydroDetect(NPC npc, Player player)
        {
            if (npc.HasBuff<PyroDebuff>())
            {
                // vaporize 2x
                return true;
            }
            else if (npc.HasBuff<ElectroDebuff>())
            {
                // electrocharged
                return true;
            }
            else if (npc.HasBuff<CryoDebuff>())
            {
                // frozen
                return true;
            }
            else if (npc.HasBuff<DendroDebuff>())
            {
                // bloom
                return true;
            }
            else if (npc.HasBuff<AnemoDebuff>())
            {
                // swirl
                return true;
            }
            return false;
        }
        public static bool pyroDetect(NPC npc, Player player)
        {
            if (npc.HasBuff<ElectroDebuff>())
            {
                // overload
                return true;
            }
            else if (npc.HasBuff<HydroDebuff>())
            {
                // vaporize 1.5x
                return true;
            }
            else if (npc.HasBuff<CryoDebuff>())
            {
                // melt 2x
                return true;
            }
            else if (npc.HasBuff<DendroDebuff>())
            {
                // burning
                return true;
            }
            else if (npc.HasBuff<AnemoDebuff>())
            {
                // swirl
                return true;
            }
            return false;
        }
        public static bool cryoDetect(NPC npc, Player player)
        {
            if (npc.HasBuff<PyroDebuff>())
            {
                // melt 1.5x
                return true;
                return false;
            }
            else if (npc.HasBuff<HydroDebuff>())
            {
                // frozen
                return true;
            }
            else if (npc.HasBuff<ElectroDebuff>())
            {
                // superconduct
                return true;
            }
            else if (npc.HasBuff<DendroDebuff>())
            {
                // quicken
                return true;
            }
            else if (npc.HasBuff<AnemoDebuff>())
            {
                // swirl
                return true;
            }
            return false;
        }
        public static bool dendroDetect(NPC npc, Player player)
        {
            if (npc.HasBuff<PyroDebuff>())
            {
                // burning
                return true;
            }
            else if (npc.HasBuff<HydroDebuff>())
            {
                // bloom
                return true;
            }
            else if (npc.HasBuff<ElectroDebuff>())
            {
                // quicken
                return true;
            }
            return false;
        }
        public static bool anemoDetect(NPC npc, Player player)
        {
            if (npc.HasBuff<PyroDebuff>())
            {
                // swirl
                return true;
            }
            else if (npc.HasBuff<HydroDebuff>())
            {
                // swirl
                return true;
            }
            else if (npc.HasBuff<CryoDebuff>())
            {
                // swirl
                return true;
            }
            else if (npc.HasBuff<DendroDebuff>())
            {
                // swirl
                return true;
            }
            return false;
        }
        public static bool geoDetect(NPC npc, Player player)
        {
            if (npc.HasBuff<PyroDebuff>())
            {
                // crystalize
                return true;
            }
            else if (npc.HasBuff<HydroDebuff>())
            {
                // crystalize
                return true;
            }
            else if (npc.HasBuff<CryoDebuff>())
            {
                // crystalize
                return true;
            }
            else if (npc.HasBuff<DendroDebuff>())
            {
                // crystalize
                return true;
            }
            return false;
        }
    }
}
