using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Retribution;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Retribution.Projectiles;
using Retribution.Items.Souls;

namespace Retribution.Items.Weapons.Melee
{
	public class Contagion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Contagion");
		}

		public override void SetDefaults()
		{
			item.maxStack = 1;
			item.damage = 14;
			item.crit = 2;
			item.width = 45;
			item.height = 64;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 1f;
			item.autoReuse = true;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = 0;
			item.melee = true;
			item.UseSound = SoundID.Item1;
			item.useTurn = true;
			item.shoot = ModContent.ProjectileType<morbinspike>();
			item.shootSpeed = 25f;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			float numberProjectiles = 3;
			float rotation = MathHelper.ToRadians(30);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
    }
}
