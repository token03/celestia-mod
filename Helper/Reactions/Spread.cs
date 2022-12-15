using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.Graphics.Renderers;
using Terraria.ID;
using Terraria.ModLoader;

namespace Celestia.Helper.Reactions
{
    public static class Spread
    {
        public static void applySpread(NPC npc, int em, int baseDamage)
        {
            int damage = damageCalc(em, baseDamage); // Calculates damage
            CombatText.NewText(npc.Hitbox, Color.ForestGreen, damage, true, false); // Prints the little number
            npc.life -= damage; // Does the damage
        }

        public static int damageCalc(int em, int baseDamage)
        {
            double damage = baseDamage * MathHelper.GetRandomNumber(0.85, 1.15);
            return Convert.ToInt32(damage);
        }
    }
}