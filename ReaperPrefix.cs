/*using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Retribution.Items;
using Retribution;

namespace Retribution
{
	public class ReaperPrefix : ModPrefix
	{
		private readonly byte _power;

		public override PrefixCategory Category
		{
			get
			{
				return (PrefixCategory)5;
			}
		}

		public ReaperPrefix()
		{
		}

		public ReaperPrefix(string displayName, float damageMult, float shootSpeedMult, float useTimeMult, int critBonus, int knockbackBonus, int harvestBonus, int storageBonus, int valuePlus)
		{
			this.displayName = displayName;
			this.damageMult = damageMult;
			this.shootSpeedMult = shootSpeedMult;
			this.useTimeMult = useTimeMult;
			this.knockbackBonus = knockbackBonus;
			this.critBonus = critBonus;
			this.harvestBonus = harvestBonus;
			this.storageBonus = storageBonus;
			this.value = valuePlus;
		}

		public override void SetDefaults()
		{
			base.DisplayName.SetDefault(this.displayName);
		}

		public override bool Autoload(ref string name)
		{
			if (base.Autoload(ref name))
			{
				//(displayName, damageMult, shootSpeedMult, useTimeMult, knockbackBonus, critBonus, harvestBonus, storageBonus, value));


				ReaperPrefix.ReaperPrefixes = new List<byte>();
				//positive modifiers
				this.AddReaperPrefix(ReaperPrefixType.Spooky, "Spooky", 1.15f, 1.15f, 1f, 1, 5, 0, 20, 1);
				this.AddReaperPrefix(ReaperPrefixType.Deadly, "Deadly", 1.15f, 1.15f, 1f, 1, 5, 0, 20, 1);
				this.AddReaperPrefix(ReaperPrefixType.Grim, "Grim", 1.15f, 1.15f, 1f, 1, 5, 0, 20, 1);
				this.AddReaperPrefix(ReaperPrefixType.Wicked, "Wicked", 1.15f, 1.15f, 1f, 1, 5, 0, 20, 1);
				this.AddReaperPrefix(ReaperPrefixType.Eerie, "Eerie", 1.15f, 1.15f, 1f, 1, 5, 0, 20, 1);
				this.AddReaperPrefix(ReaperPrefixType.Haunting, "Haunting", 1.15f, 1.15f, 1f, 1, 5, 0, 20, 1);
				this.AddReaperPrefix(ReaperPrefixType.Ghoulish, "Ghoulish", 1.15f, 1.15f, 1f, 1, 5, 0, 20, 1);
				this.AddReaperPrefix(ReaperPrefixType.Supernatural, "Supernatural", 1.15f, 1.15f, 1f, 1, 5, 0, 20, 1);
				//negative modifiers
				this.AddReaperPrefix(ReaperPrefixType.Treacherous, "Treacherous", 1.15f, 1.15f, 1f, 1, 5, 0, 20, 1);
				this.AddReaperPrefix(ReaperPrefixType.Foul, "Foul", 1.15f, 1.15f, 1f, 1, 5, 0, 20, 1);
				this.AddReaperPrefix(ReaperPrefixType.Inferior, "Inferior", 1.15f, 1.15f, 1f, 1, 5, 0, 20, 1);
				this.AddReaperPrefix(ReaperPrefixType.Useless, "Useless", 1.15f, 1.15f, 1f, 1, 5, 0, 20, 1);
			}
			return false;
		}

		public override void Apply(Item item)
		{
			ReaperClass reaperItem;
			var rP = Main.LocalPlayer.GetModPlayer<RetributionPlayer>();

			if ((reaperItem = (item.modItem as ReaperClass)) != null)
			{
				rP.soulRecieve += (short)(this.harvestBonus);
			}
		}

		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 1f + value;
		}

		public override bool CanRoll(Item item)
		{
			if (item.modItem is ReaperClass && (item.maxStack == 1 && item.damage > 0))
			{
				return true;
			}
			else {
				return false;
			}
		}

		public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
		{
			damageMult = this.damageMult;
			shootSpeedMult = this.shootSpeedMult;
			useTimeMult = this.useTimeMult;
			critBonus = this.critBonus;
			knockbackMult = this.knockbackBonus;
		}

		private void AddReaperPrefix(ReaperPrefixType prefixType, string displayName, float damageMult = 1f, float shootSpeedMult = 1f, float useTimeMult = 1f, int knockbackBonus = 1, int harvestBonus = 0, int critBonus = 0, int storageBonus = 0, int valuePlus = 0)
		{
			base.mod.AddPrefix(prefixType.ToString(), new ReaperPrefix(displayName, damageMult, shootSpeedMult, useTimeMult, knockbackBonus, critBonus, harvestBonus, storageBonus, valuePlus));
			ReaperPrefix.ReaperPrefixes.Add(base.mod.GetPrefix(prefixType.ToString()).Type);
		}

		internal static List<byte> ReaperPrefixes;

		internal float damageMult = 1f;

		internal float shootSpeedMult = 1f;

		internal float useTimeMult = 1f;

		internal int knockbackBonus;

		internal int critBonus;

		internal int harvestBonus;

		internal int value;

		internal int storageBonus;

		internal string displayName;
	}
}*/

using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Retribution
{
	public class ReaperPrefix : ModPrefix
	{
		public override PrefixCategory Category
		{
			get
			{
				return (PrefixCategory)5;
			}
		}

		public ReaperPrefix()
		{
		}

		public ReaperPrefix(float damageMult = 1f, float useTimeMult = 1f, int critBonus = 0, float shootSpeedMult = 1f, int harvestBonus = 0, int storageBonus = 0)
		{
			this.damageMult = damageMult;
			this.useTimeMult = useTimeMult;
			this.critBonus = critBonus;
			this.shootSpeedMult = shootSpeedMult;
			this.harvestBonus = harvestBonus;
			this.storageBonus = storageBonus;
		}

		public override bool Autoload(ref string name)
		{
			if (base.Autoload(ref name))
			{
				ReaperPrefix.ReaperModifiers = new List<byte>();

				//Positive Modifiers
				ReaperPrefix.AddReaperPrefix(base.mod, ReaperPrefixType.Spooky, 1.1f, 1f, 0, 1f, 1, 1);
				ReaperPrefix.AddReaperPrefix(base.mod, ReaperPrefixType.Deadly, 1.1f, 1f, 0, 1f, 1, 1);
				ReaperPrefix.AddReaperPrefix(base.mod, ReaperPrefixType.Grim, 1.1f, 1f, 0, 1f, 1, 1);
				ReaperPrefix.AddReaperPrefix(base.mod, ReaperPrefixType.Wicked, 1.1f, 1f, 0, 1f, 1, 1);
				ReaperPrefix.AddReaperPrefix(base.mod, ReaperPrefixType.Eerie, 1.1f, 1f, 0, 1f, 1, 1);
				ReaperPrefix.AddReaperPrefix(base.mod, ReaperPrefixType.Haunting, 1.1f, 1f, 0, 1f, 1, 1);
				ReaperPrefix.AddReaperPrefix(base.mod, ReaperPrefixType.Ghoulish, 1.1f, 1f, 0, 1f, 1, 1);
				ReaperPrefix.AddReaperPrefix(base.mod, ReaperPrefixType.Supernatural, 1.1f, 1f, 0, 1f, 1, 1);

				//Negative Modifiers
				ReaperPrefix.AddReaperPrefix(base.mod, ReaperPrefixType.Treacherous, 1.1f, 1f, 0, 1f, 1, 1);
				ReaperPrefix.AddReaperPrefix(base.mod, ReaperPrefixType.Foul, 1.1f, 1f, 0, 1f, 1, 1);
				ReaperPrefix.AddReaperPrefix(base.mod, ReaperPrefixType.Inferior, 1.1f, 1f, 0, 1f, 1, 1);
				ReaperPrefix.AddReaperPrefix(base.mod, ReaperPrefixType.Useless, 1.1f, 1f, 0, 1f, 1, 1);
			}
			return false;
		}

		public override void Apply(Item item)
		{
			ModItem moddedItem = item.modItem;
			ReaperClass reaperWep;
			var rP = Main.LocalPlayer.GetModPlayer<RetributionPlayer>();

			if (moddedItem != null && (reaperWep = (moddedItem as ReaperClass)) != null)
			{
				rP.soulRecieve += this.harvestBonus;
			}
		}

		public override void ModifyValue(ref float valueMult)
		{
			float extraValue = 1f + 1f * (this.damageMult - 1f);
			valueMult *= extraValue;
		}

		public override bool CanRoll(Item item)
		{
			return item.modItem is ReaperClass && (item.maxStack == 1 && item.damage > 0);
		}

		public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
		{
			damageMult = this.damageMult;
			useTimeMult = this.useTimeMult;
			critBonus = this.critBonus;
			shootSpeedMult = this.shootSpeedMult;
		}

		private static void AddReaperPrefix(Mod mod, ReaperPrefixType prefixType, float damageMult = 1f, float useTimeMult = 1f, int critBonus = 0, float shootSpeedMult = 1f, int harvestBonus = 0, int storageBonus = 0)
		{
			string name = prefixType.ToString();
			mod.AddPrefix(name, new ReaperPrefix(damageMult, useTimeMult, critBonus, shootSpeedMult, harvestBonus, storageBonus));
			ReaperPrefix.ReaperModifiers.Add(mod.GetPrefix(name).Type);
		}

		public override void ValidateItem(Item item, ref bool invalid)
		{
			if ((double)item.damage == Math.Round((double)((float)item.damage * this.damageMult)) && this.damageMult != 1f)
			{
				invalid = true;
			}
			if ((double)item.useAnimation == Math.Round((double)((float)item.useAnimation * this.useTimeMult)) && this.useTimeMult != 1f)
			{
				invalid = true;
			}
		}

		internal static List<byte> ReaperModifiers;

		internal float damageMult = 1f;

		internal float useTimeMult = 1f;

		internal int critBonus;

		internal float shootSpeedMult = 1f;

		internal int harvestBonus = 0;

		internal int storageBonus = 0;
	}
}