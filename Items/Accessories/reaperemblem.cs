using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Retribution.Items.Accessories
{
	public class reaperemblem : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reaper Emblem");
			Tooltip.SetDefault("15% increased soul damage");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.value = 1000;
			item.rare = ItemRarityID.LightRed;
			item.accessory = true;
			item.maxStack = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			var rP = player.GetModPlayer<RetributionPlayer>();

			rP.reaperDamage += 0.15f;
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