using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Retribution;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;

namespace Retribution.Items.Weapons.Melee
{
	public class blazingchakram : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blazing Chakram");
			Tooltip.SetDefault("Homes into enemies and stays on them for 5 seconds");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
			ItemID.Sets.AnimatesAsSoul[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.maxStack = 1;
			item.damage = 160;
			item.width = 46;
			item.height = 46;
			item.useTime = 12;
			item.useAnimation = 12;
			item.autoReuse = true;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.knockBack = 3f;
			item.value = Item.sellPrice(0, 25, 0, 0);
			item.rare = ItemRarityID.Red;
			item.melee = true;
			item.UseSound = SoundID.Item1;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("blazingchakramproj");
			item.shootSpeed = 12f;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			for (int i = 0; i < 3; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override void PostUpdate()
		{
			Lighting.AddLight((int)((item.position.X + item.width / 2) / 16f), (int)((item.position.Y + item.height / 2) / 16f), 0.8f, 0.5f, 0.2f);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentSolar, 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
