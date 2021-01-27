using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items.Weapons.Summoner
{
	public class RodofSoil : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Rod of Soil");
			base.Tooltip.SetDefault("Summons an earth worm to devour your enemies");
		}

		public override void SetDefaults()
		{
			base.item.width = 60;
			base.item.height = 64;
			base.item.damage = 11;
			base.item.knockBack = 3f;
			base.item.mana = 10;
			base.item.useTime = 26;
			base.item.useAnimation = 26;
			base.item.useStyle = 1;
			base.item.UseSound = SoundID.Item44;
			base.item.summon = true;
			base.item.noMelee = true;
			base.item.rare = 11;
			base.item.value = Item.sellPrice(0, 25, 0, 0);
			base.item.shoot = base.mod.ProjectileType("EarthHead");
			base.item.shootSpeed = 7f;
		}

		public override bool CanUseItem(Player player)
		{
			float minions = 0f;
			for (int i = 0; i < 1000; i++)
			{
				if (Main.projectile[i].active && Main.projectile[i].owner == player.whoAmI && Main.projectile[i].minion)
				{
					minions += Main.projectile[i].minionSlots;
				}
			}
			return minions < (float)player.maxMinions;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
			float velocityX = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
			float velocityY = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
			int head = -1;
			int tail = -1;
			for (int i = 0; i < 1000; i++)
			{
				if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer)
				{
					if (head == -1 && Main.projectile[i].type == base.mod.ProjectileType("EarthHead"))
					{
						head = i;
					}
					if (tail == -1 && Main.projectile[i].type == base.mod.ProjectileType("EarthTail"))
					{
						tail = i;
					}
					if (head != -1 && tail != -1)
					{
						break;
					}
				}
			}
			if (head == -1 && tail == -1)
			{
				velocityX = 0f;
				vector2.X = (float)Main.mouseX + Main.screenPosition.X;
				vector2.Y = (float)Main.mouseY + Main.screenPosition.Y;
				int current = Projectile.NewProjectile(vector2.X, vector2.Y, velocityX, velocityX, base.mod.ProjectileType("EarthHead"), damage, knockBack, Main.myPlayer, 0f, 0f);
				int previous = current;
				current = Projectile.NewProjectile(vector2.X, vector2.Y, velocityX, velocityX, base.mod.ProjectileType("EarthBody"), damage, knockBack, Main.myPlayer, (float)previous, 0f);
				previous = current;
				current = Projectile.NewProjectile(vector2.X, vector2.Y, velocityX, velocityX, base.mod.ProjectileType("EarthTail"), damage, knockBack, Main.myPlayer, (float)previous, 0f);
				Main.projectile[previous].localAI[1] = (float)current;
				Main.projectile[previous].netUpdate = true;
			}
			else if (head != -1 && tail != -1)
			{
				int body = Projectile.NewProjectile(vector2.X, vector2.Y, velocityX, velocityY, base.mod.ProjectileType("EarthBody"), damage, knockBack, Main.myPlayer, Main.projectile[tail].ai[0], 0f);
				Main.projectile[body].localAI[1] = (float)tail;
				Main.projectile[body].ai[1] = 1f;
				Main.projectile[body].netUpdate = true;
				Main.projectile[tail].ai[0] = (float)body;
				Main.projectile[tail].netUpdate = true;
				Main.projectile[tail].ai[1] = 1f;
			}
			return false;
		}
	}
}
