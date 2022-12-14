using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Graphics.Renderers;
using Terraria.ID;
using Terraria.ModLoader;

namespace Celestia.Content.Buffs.Elements
{
    // This class serves as an example of a debuff that causes constant loss of life
    // See ExampleLifeRegenDebuffPlayer.UpdateBadLifeRegen at the end of the file for more information
    public class OverloadNPC : GlobalNPC
    {
        // This is required to store information on entities that isn't shared between them.
        public override bool InstancePerEntity => true;

        public bool overload;
        public int overloadDamage;

        public void applyOverload(NPC npc, int em)
        {
            overloadDamage = 100;
            //Damage text above player's head for visibility
            AdvancedPopupRequest popup = new AdvancedPopupRequest { Text = overloadDamage.ToString(), Color = Color.Purple, DurationInFrames = 180, Velocity = new Vector2(0f, 1f) };
            PopupText.NewText(popup, npc.Center + new Vector2(0, -70));
            npc.life -= overloadDamage;
        }

        public override void ResetEffects(NPC npc)
        {
            overload = false;
        }
    }
}