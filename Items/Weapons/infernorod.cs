using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items.Weapons
{
	public class infernorod : ModItem
	{

		public override void SetDefaults()
		{

			item.damage = 10000;
			item.mana = 0;
			item.width = 42;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 4f;
			item.value = Item.buyPrice(0, 1, 0, 0);
			item.rare = 3;
			item.UseSound = SoundID.Item44;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("infernoring");
			item.sentry = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Holy Scepter");
			Tooltip.SetDefault("Summons a Holy Ring to shoot homing spheres of light at your enemies" +
                "\nAny player standing inside the ring gets increased health regeneration");
		}

		public override bool AltFunctionUse(Player player)
		{
			return false;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 SPos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			position = SPos;
			for (int l = 0; l < Main.projectile.Length; l++)
			{
				Projectile proj = Main.projectile[l];
				if (proj.active && proj.type == item.shoot && proj.owner == player.whoAmI)
				{
					proj.active = false;
				}
			}
			return player.altFunctionUse != 2;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FallenStar, 20);
			//recipe.AddIngredient(ItemID.BrokenRod, 1);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}