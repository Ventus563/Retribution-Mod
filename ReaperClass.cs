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

		public virtual void SafeSetDefaults()
		{
		}
		public sealed override void SetDefaults()
		{
			SafeSetDefaults();
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

		public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
		{
			mult *= RetributionPlayer.ModPlayer(player).reaperDamage;
		}

		public override void GetWeaponKnockback(Player player, ref float knockback)
		{
			knockback += RetributionPlayer.ModPlayer(player).reaperKnockback;
		}

		public override void GetWeaponCrit(Player player, ref int crit)
		{
			crit += RetributionPlayer.ModPlayer(player).reaperCrit;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
			if (tt != null)
			{
				string[] splitText = tt.text.Split(' ');
				string damageValue = splitText.First();
				string damageWord = splitText.Last();
				tt.text = damageValue + " necrotic " + damageWord;
			}
		}

        public override bool CanUseItem(Player player)
		{
			var rP = player.GetModPlayer<RetributionPlayer>();

			if (rP.soulCurrent >= soulCost)
			{
				rP.soulCurrent -= soulCost;
				return true;
			}
			return false;
		}
	}
}