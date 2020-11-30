using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Retribution.Items.Accessories;

namespace Retribution.Items.Accessories
{
	public class deathpoweremblem : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Death Power Emblem");
			Tooltip.SetDefault("25% increased soul damage"
				+ "\n75% decreased all non-soul damage"
				+ "\nIncreases maximum soul storage by 30");
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

			rP.reaperDamage += 0.25f;
			player.magicDamage -= 0.75f;
			player.meleeDamage -= 0.75f;
			player.rangedDamage -= 0.75f;
			player.minionDamage -= 0.75f;
			player.thrownDamage -= 0.75f;
			rP.soulMax2 += 30;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<deathfragment>(), 5);
			recipe.AddIngredient(ModContent.ItemType<reaperemblem>(), 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}