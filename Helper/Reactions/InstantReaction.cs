using Microsoft.Xna.Framework;
using System;
using Terraria;

namespace Celestia.Helper.Reactions
{
	public class InstantReaction
	{
		public static void ApplyReactionDamage(NPC npc, int damage, Color color, Player player)
		{
			double strikeDamage = npc.StrikeNPC(Convert.ToInt32(damage / 2), 0, 0, true); // converts to crit to reduce errors (lol)
			// checks for the newest matching combattext in main.combattext and edits it 
			for (int i = 99; i >= 0; i--)
			{
				CombatText ctToCheck = Main.combatText[i];
				if ((ctToCheck.lifeTime == 60 || ctToCheck.lifeTime == 120) 
					&& ctToCheck.alpha == 1f 
					&& ctToCheck.color == CombatText.DamagedHostileCrit
					&& ctToCheck.text == Convert.ToString(Math.Floor(strikeDamage))) 
				{
					ctToCheck.color = color;
					ctToCheck.scale *= 1.3f;
					break;
				}
			}
			npc.netUpdate = true; // syncs damage across clients
			player.addDPS(Convert.ToInt32(strikeDamage)); // updates info for dps meter accessory
		}
	}
}
