using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.Graphics.Renderers;
using Terraria.ID;
using Terraria.ModLoader;

namespace Celestia.Helper.Reactions
{
    public static class Overload
    {
        private const int BASE_DAMAGE = 20; 
        public static void applyOverload(NPC npc, int em)
        {
            int damage = damageCalc(npc, em); // Calcs the damage
            CombatText.NewText(npc.Hitbox, Color.MediumPurple, damage, true, false); // Prints little number
            npc.life -= damage; // Deals the damage
        }

        public static int damageCalc(NPC npc, int em)
        {
            double damage = BASE_DAMAGE * MathHelper.GetRandomNumber(0.85, 1.15);
            return Convert.ToInt32(damage);
        }
    }
}