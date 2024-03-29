﻿using Microsoft.Xna.Framework;
using System;
using Terraria;

namespace Celestia.Helper.Reactions
{
	public class InstantReaction
	{
		/// <summary>
		/// Applies damage to given NPC and sets the CombatText to given Color.
		/// </summary>
		/// <param name="npc">NPC to deal damage to</param>
		/// <param name="damage">Damage to deal</param>
		/// <param name="color">Color of CombatText</param>
		/// <param name="player">Player who dealt the damage</param>
		public static void applyReactionDamage(NPC npc, int damage, Color color, Player player)
		{
			
			double strikeDamage = npc.SimpleStrikeNPC(Convert.ToInt32(damage / 2), 0, true); // converts to crit to reduce errors (lol)
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
