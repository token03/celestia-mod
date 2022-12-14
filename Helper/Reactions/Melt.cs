using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.Graphics.Renderers;
using Terraria.ID;
using Terraria.ModLoader;

namespace Celestia.Helper.Reactions
{
    public static class Melt
    {
        public static void applyMelt(NPC npc, int em, int baseDamage, bool reverse)
        {
            int damage = damageCalc(em, baseDamage, reverse); // Calculates damage
            CombatText.NewText(npc.Hitbox, Color.LightBlue, damage, true, false); // Prints the little number
            npc.life -= damage; // Does the damage
        }

        public static int damageCalc(int em, int baseDamage, bool reverse)
        {
            double meltMultiplier = reverse ? 2.5 : 4;
            double damage = baseDamage * MathHelper.GetRandomNumber(0.85, 1.15) * meltMultiplier;
            return Convert.ToInt32(damage);
        }
    }
}