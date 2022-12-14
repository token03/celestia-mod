using System;
using Terraria;
using Terraria.Graphics.Renderers;
using Terraria.ID;
using Terraria.ModLoader;

namespace Celestia.Content.Buffs.Elements
{
    // This class serves as an example of a debuff that causes constant loss of life
    // See ExampleLifeRegenDebuffPlayer.UpdateBadLifeRegen at the end of the file for more information
    public class Electro : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Electro Debuff"); // Buff display name
            Description.SetDefault("Losing life"); // Buff description
            Main.debuff[Type] = true;  // Is it a debuff?
            Main.pvpBuff[Type] = true; // Players can give other players buffs, which are listed as pvpBuff
            Main.buffNoSave[Type] = true; // Causes this buff not to persist when exiting and rejoining the world
            BuffID.Sets.LongerExpertDebuff[Type] = true; // If this buff is a debuff, setting this to true will make this buff last twice as long on players in expert mode
            BuffID.Sets.IsAnNPCWhipDebuff[Type] = true;
        }
        /*
        // Allows you to make this buff give certain effects to the given player
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<ElectroDebuffNPC>().electroApplied = true;
            if (!npc.friendly)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }

                npc.lifeRegen -= 12;
                npc.defense = (int)(npc.defense * 0.95f);
            }
        }

        public class ElectroDebuffNPC : GlobalNPC
        {
            // This is required to store information on entities that isn't shared between them.
            public override bool InstancePerEntity => true;

            public bool electroApplied;

            public override void ResetEffects(NPC npc)
            {
                electroApplied = false;
            }
        }
        */
    }
}