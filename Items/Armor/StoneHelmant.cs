using Terraria
using Terraria.ID
using Terraria.ModLoader

namespace Retribution.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class StoneHelment : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stone Helment")
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<StoneBrestplate>() && legs.type == ModContent.ItemType<StoneLeggings>();
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.defense = 2;

		public override void UpdateArmorSet(player player)
		{
			player.allDamage = 0.3f;
		}

		public override void
		{ 
		  ModRecipe recipe = new ModRecipe(mod);
		  recipe.AddIngrediant(ItemID.StoneBlock, 10);
		  recipe.AddTile(TileID.WorkBenches);
		  recipe.SetResult(this);
		  recipe.AddRecipe();
		}
    }
}
