using Retribution.Dusts;
using Retribution.Items;
using Retribution.NPCs;
using Retribution.Projectiles.Minions;
using Retribution.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Events;
using Terraria.Graphics.Shaders;

namespace Retribution
{
    public abstract class ReaperClass : ModItem
    {
		public override bool CloneNewInstances => true;
		public int soulCost = 0;

		// Custom items should override this to set their defaults
		public virtual void SafeSetDefaults()
		{
		}

		// By making the override sealed, we prevent derived classes from further overriding the method and enforcing the use of SafeSetDefaults()
		// We do this to ensure that the vanilla damage types are always set to false, which makes the custom damage type work
		public sealed override void SetDefaults()
		{
			SafeSetDefaults();
			// all vanilla damage types must be false for custom damage types to work
			item.melee = false;
			item.ranged = false;
			item.magic = false;
			item.thrown = false;
			item.summon = false;
		}

        public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
		{
			var rP = player.GetModPlayer<RetributionPlayer>();

			if (target.CanBeChasedBy())
			{
				Player p = Main.player[item.owner];
				int healingAmount = rP.soulCurrent / 4;
				p.statLife += healingAmount;
				p.HealEffect(healingAmount, true);
				Dust.NewDust(player.position, player.width, player.height, 278, 0f, 0f, 150, default, 1.5f);
			}
		}

		// As a modder, you could also opt to make these overrides also sealed. Up to the modder
		public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
		{
			add += RetributionPlayer.ModPlayer(player).reaperDamageAdd;
			mult *= RetributionPlayer.ModPlayer(player).reaperDamageMult;
		}

		public override void GetWeaponKnockback(Player player, ref float knockback)
		{
			// Adds knockback bonuses
			knockback += RetributionPlayer.ModPlayer(player).reaperKnockback;
		}

		public override void GetWeaponCrit(Player player, ref int crit)
		{
			// Adds crit bonuses
			crit += RetributionPlayer.ModPlayer(player).reaperCrit;
		}

		// Because we want the damage tooltip to show our custom damage, we need to modify it
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			// Get the vanilla damage tooltip
			TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
			if (tt != null)
			{
				// We want to grab the last word of the tooltip, which is the translated word for 'damage' (depending on what language the player is using)
				// So we split the string by whitespace, and grab the last word from the returned arrays to get the damage word, and the first to get the damage shown in the tooltip
				string[] splitText = tt.text.Split(' ');
				string damageValue = splitText.First();
				string damageWord = splitText.Last();
				// Change the tooltip text
				tt.text = damageValue + " soul " + damageWord;
			}
		}

        // Make sure you can't use the item if you don't have enough resource and then use 10 resource otherwise.
        public override bool CanUseItem(Player player)
		{
			var retributionPlayer = player.GetModPlayer<RetributionPlayer>();

			if (retributionPlayer.soulCurrent >= soulCost)
			{
				retributionPlayer.soulCurrent -= soulCost;
				return true;
			}
			return false;
		}
	}
}