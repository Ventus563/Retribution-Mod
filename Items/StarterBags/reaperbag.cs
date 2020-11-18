using Retribution.Items.Weapons.Reaper;
using Retribution.Items.Consumables;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items.StarterBags
{
	public class reaperbag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Grimly Bag");
			Tooltip.SetDefault("Contains Reaper class items\n{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults()
		{
			item.maxStack = 1;
			item.consumable = true;
			item.width = 26;
			item.height = 34;
			item.rare = ItemRarityID.Purple;
			item.expert = true;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			player.QuickSpawnItem(ModContent.ItemType<steelscythe>());
			player.QuickSpawnItem(ModContent.ItemType<soulpotion>(), 5);
			//player.QuickSpawnItem(ModContent.ItemType<accessory>());
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<emptybag>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}