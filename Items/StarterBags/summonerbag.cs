using Retribution.Items.Weapons.Summoner;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Retribution.Items.Materials;

namespace Retribution.Items.StarterBags
{
	public class summonerbag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Summoner's Bag");
			Tooltip.SetDefault("Contains Summoner class items\n{$CommonItemTooltip.RightClickToOpen}");
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
			player.QuickSpawnItem(ModContent.ItemType<flamelingstaff>());
			player.QuickSpawnItem(ModContent.ItemType<brokenrod>());
			player.QuickSpawnItem(ItemID.PygmyNecklace);
			player.QuickSpawnItem(ItemID.SummoningPotion, 2);
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