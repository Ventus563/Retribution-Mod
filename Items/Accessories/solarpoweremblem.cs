using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Retribution.Items.Accessories
{
	public class solarpoweremblem : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Solar Power Emblem");
			Tooltip.SetDefault("25% increased melee damage"
				+ "\n75% decreased all non-melee damage"
				+ "\nArmor Penetration is equal to 1/4 of the user's current defense");
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 30;
			item.value = 1000;
			item.rare = ItemRarityID.Red;
			item.accessory = true;
			item.maxStack = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			var rP = player.GetModPlayer<RetributionPlayer>();

			player.meleeDamage += 0.25f;
			player.minionDamage -= 0.75f;
			player.rangedDamage -= 0.75f;
			player.magicDamage -= 0.75f;
			player.thrownDamage -= 0.75f;
			rP.reaperDamage -= 0.75f;
			player.armorPenetration += player.statDefense / 4;
		}

        public override void UpdateEquip(Player player)
        {
			player.armorPenetration += player.statDefense / 2;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentSolar, 5);
			recipe.AddIngredient(ItemID.WarriorEmblem, 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}