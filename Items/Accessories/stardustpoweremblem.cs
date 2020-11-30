using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Retribution.Items.Accessories
{
	public class stardustpoweremblem : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stardust Power Emblem");
			Tooltip.SetDefault("25% increased minion damage"
				+ "\n75% decreased all non-minion damage"
				+ "\nIncreases your max number of minions by 1");
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

			player.minionDamage += 0.25f;
			player.meleeDamage -= 0.75f;
			player.rangedDamage -= 0.75f;
			player.magicDamage -= 0.75f;
			player.thrownDamage -= 0.75f;
			rP.reaperDamage -= 0.75f;
			player.maxMinions++;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentStardust, 5);
			recipe.AddIngredient(ItemID.SummonerEmblem, 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}