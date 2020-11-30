using Retribution.Projectiles;
using Retribution.Items.Souls;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Retribution.Items.Weapons.Ranger
{
	public class autorifle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Auto Rifle");
		}

		public override void SetDefaults()
		{
			item.damage = 1;
			item.ranged = true;
			item.width = 50;
			item.height = 28;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 80000;
			item.rare = 0;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Bullet;
		}
	}
}