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
        public static void applyOverload(NPC npc, int em)
        {
            int damage = damageCalc(npc, em);
            //Damage text above player's head for visibility
            CombatText.NewText(npc.Hitbox, Color.MediumPurple, damage, true, false);
            npc.life -= damage;
        }

        public static int damageCalc(NPC npc, int em)
        {
            return 100;
        }
    }
}