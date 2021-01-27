using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items.Weapons.Mage
{
	public class Galvanation : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Galvanation");
			Tooltip.SetDefault("A slightly different laser-firing Prism Ignores NPC immunity frames and fires 10 beams at once instead of 6.");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LastPrism);
			item.mana = 8;
			item.damage = 6;
			item.shoot = ModContent.ProjectileType<GalvanationHoldOut>();
			item.shootSpeed = 30f;
			item.rare = ItemRarityID.Orange;
		}

		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Something, 10);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/

		public override bool CanUseItem(Player player) => player.ownedProjectileCounts[ModContent.ProjectileType<GalvanationHoldOut>()] <= 0;
	}
}