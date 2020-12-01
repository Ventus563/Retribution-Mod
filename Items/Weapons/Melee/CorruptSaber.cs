using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items.Weapons.Melee
{
	public class CorruptSaber : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corrupt Saber")
		}

		public override void SetStaticDefaults()
		{
			item.damage = 12;
			item.width = 40;
			item.hight = 40;
			item.melee = true;
			item.useTime = 10;
			item.useAnimation = 10;
			item.knockBack = 6;
			item.value = Item.buyPrice(Silver: 25);
			item.rare = ItemRarityID.Green;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.autoReuse = false;
			item.crit = 1;
		}

		public override void AddRecipies()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.EbonstoneBlock, 15);
			recipe.AddIngredient(ItemID.IronBar 5); //uses either Iron or Lead Bars
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe()
		}
	}
}
