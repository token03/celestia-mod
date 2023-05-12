using Celestia.Content.Buffs.Elements;
using Celestia.Content.Buffs.Reactions;
using Celestia.Helper.InstantReactions;
using Celestia.Helper.Reactions;
using Terraria;
using Terraria.ModLoader;

namespace Celestia.Helper
{
    public static class ReactionHelper
    {
		/// <summary>
		/// Applies a elemental reaction using current player vision element.
		/// </summary>
		/// <param name="target"></param>
		/// <param name="player"></param>
		/// <param name="damage"></param>
		/// <param name="vision"></param>
		/// <returns></returns>
		public static bool ElementReaction(NPC target, Player player, int damage, int element)
		{
			switch (element)
			{ 
				case var value when value == ModContent.BuffType<Pyro>(): // I WISH i knew how this worked. 
					return pyroDetect(target, player, damage); // Like look at this: https://stackoverflow.com/questions/7593377/switch-case-in-c-sharp-a-constant-value-is-expected
				case var value when value == ModContent.BuffType<Geo>():
					return geoDetect(target, player, damage);
				case var value when value == ModContent.BuffType<Hydro>():
					return hydroDetect(target, player, damage);
				case var value when value == ModContent.BuffType<Cryo>():
					return cryoDetect(target, player, damage);
				case var value when value == ModContent.BuffType<Dendro>():
					return dendroDetect(target, player, damage);
				case var value when value == ModContent.BuffType<Anemo>():
					return anemoDetect(target, player, damage);
				case var value when value == ModContent.BuffType<Electro>():
					return electroDetect(target, player, damage);
				default:
					return false;
			}
		}
        // Each respective detector is called based on elemental application (i.e Applying element calls elementDetect).
        // If another element is detected apply respective reaction to target NPC and remove base element.
        public static bool electroDetect(NPC target, Player player, int damage)
        {
            if (target.HasBuff<Pyro>())
            {
                // overload	
                Overload.applyOverload(target, player); // applies debuff 
                target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Pyro>())); // removes debuff
                return true; // returns true so the orginal call can know not to apply base element
            } 
            else if (target.HasBuff<Hydro>())
            {
				// electrocharged
				ElectroChargedHelper.applyElectroCharged(target, player, damage); // applies debuff 
				target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Hydro>())); // removes debuff
				return true;
            } 
            else if (target.HasBuff<Cryo>())
            {
                // superconduct
                target.AddBuff(ModContent.BuffType<Superconduct>(), 480); // applies debuff 
                target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Cryo>())); // removes debuff
                return true;
            } 
            else if (target.HasBuff<Dendro>())
            {
				// quicken
				target.AddBuff(ModContent.BuffType<Quicken>(), 480);
				target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Dendro>()));
                return true;
            }
            else if (target.HasBuff<Anemo>())
            {
                // swirl
                return true;
            }
            else if (target.HasBuff<Geo>())
            {
                // crystalize
                return true;
            }
            else if (target.HasBuff<Quicken>())
            {
                // aggravate
                Aggravate.applyAggravate(target, player, damage); // applies debuff
                return true;
            }
            return false;
        }
        public static bool hydroDetect(NPC target, Player player, int damage)
        {
            if (target.HasBuff<Pyro>())
            {
                // vaporize 2x
                Vaporize.applyVaporize(target, player, damage, false);
                target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Pyro>()));
                return true;
            }
            else if (target.HasBuff<Electro>())
            {
				// electrocharged
				ElectroChargedHelper.applyElectroCharged(target, player, damage); // applies debuff 
				target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Electro>())); // removes debuff
				return true;
            }
            else if (target.HasBuff<Cryo>())
            {
				// frozen
				target.AddBuff(ModContent.BuffType<Frozen>(), 480); // applies debuff 
				target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Cryo>())); // removes debuff
				return true;
            }
            else if (target.HasBuff<Dendro>())
            {
				// bloom
				Bloom.applyBloom(target, player, damage);
				target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Dendro>()));
				return true;
            }
            else if (target.HasBuff<Anemo>())
            {
                // swirl
                return true;
            }
            else if (target.HasBuff<Geo>())
            {
                // crystalize
                return true;
            }
            else if (target.HasBuff<Quicken>())
            {
                // bloom 
                return true;
            }
            return false;
        }
        public static bool pyroDetect(NPC target, Player player, int damage)
        {
            if (target.HasBuff<Electro>())
            {
                // overload
                Overload.applyOverload(target, player);
                target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Electro>()));
                return true;
            }
            else if (target.HasBuff<Hydro>())
            {
                // vaporize 1.5x
                Vaporize.applyVaporize(target, player, damage, true);
                target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Hydro>()));
                return true;
            }
            else if (target.HasBuff<Cryo>())
            {
                // melt 2x            
                Melt.applyMelt(target, player, damage, false);
                target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Cryo>()));
                return true;
            }
            else if (target.HasBuff<Dendro>())
            {
				// burning
                return true;
            }
            else if (target.HasBuff<Anemo>())
            {
                // swirl
                return true;
            }
            else if (target.HasBuff<Geo>())
            {
                // crystalize
                return true;
            }
            else if (target.HasBuff<Quicken>())
            {
                // burning
                return true;
            }
            return false;
        }
        public static bool cryoDetect(NPC target, Player player, int damage)
        {
            if (target.HasBuff<Pyro>())
            {
                // melt 1.5x      
                Melt.applyMelt(target, player, damage, true);
                target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Pyro>()));
                return true;
            }
            else if (target.HasBuff<Hydro>())
            {
				// frozen
				target.AddBuff(ModContent.BuffType<Frozen>(), 480); // applies debuff 
				target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Hydro>())); // removes debuff
				return true;
            }
            else if (target.HasBuff<Electro>())
            {
                // superconduct
                target.AddBuff(ModContent.BuffType<Superconduct>(), 480); // applies debuff 
                target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Electro>())); // removes debuff
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
            else if (target.HasBuff<Geo>())
            {
                // cryatlize
                return true;
            }
            return false;
        }
        public static bool dendroDetect(NPC target, Player player, int damage)
        {
            if (target.HasBuff<Pyro>())
            {
                // burning
                return true;
            }
            else if (target.HasBuff<Hydro>())
            {
				// bloom
				Bloom.applyBloom(target, player, damage);
				target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Hydro>()));
				return true;
            }
            else if (target.HasBuff<Electro>())
            {
                // quicken
                return true;
            }
            else if (target.HasBuff<Quicken>())
            {
                // spread
                Spread.applySpread(target, player, damage); // applies debuff
                return true;
            }
            return false;
        }
        public static bool anemoDetect(NPC target, Player player, int damage)
        {
            if (target.HasBuff<Pyro>())
            {
				// swirl
				target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Pyro>()));
				Swirl.applySwirl(target, player, damage, ModContent.BuffType<Pyro>());
				return true;
            }
            else if (target.HasBuff<Hydro>())
            {
				// swirl
				target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Hydro>()));
				Swirl.applySwirl(target, player, damage, ModContent.BuffType<Hydro>());
				return true;
            }
			else if (target.HasBuff<Electro>())
			{
				// swirl
				target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Electro>()));
				Swirl.applySwirl(target, player, damage, ModContent.BuffType<Electro>());
				return true;
			}
			else if (target.HasBuff<Cryo>())
            {
				// swirl
				target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Cryo>()));
				Swirl.applySwirl(target, player, damage, ModContent.BuffType<Cryo>());
				return true;
            }
            return false;
        }
        public static bool geoDetect(NPC target, Player player, int damage)
        {
            if (target.HasBuff<Pyro>())
            {
				// crystalize
				target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Pyro>()));
				InstantReactions.Crystalize.applyCrystalize(target, player, damage);
                return true;
            }
            else if (target.HasBuff<Hydro>())
            {
				// crystalize
				target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Hydro>()));
				InstantReactions.Crystalize.applyCrystalize(target, player, damage);
				return true;
            }
            else if (target.HasBuff<Cryo>())
            {
				// crystalize
				target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Cryo>()));
				InstantReactions.Crystalize.applyCrystalize(target, player, damage);
				return true;
            }
            else if (target.HasBuff<Dendro>())
            {
				// crystalize 
				target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Dendro>()));
				InstantReactions.Crystalize.applyCrystalize(target, player, damage);
				return true;
            }
            return false;
        }
    }
}
