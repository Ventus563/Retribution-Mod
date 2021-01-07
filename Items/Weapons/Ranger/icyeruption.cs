using Retribution.Projectiles;
using Retribution.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Retribution.Items.Weapons.Ranger
{
	public class icyeruption : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Icy Eruption");
			Tooltip.SetDefault("Uses frostfire bullets for ammo");
		}

		public override void SetDefaults()
		{
			item.damage = 18;
			item.crit = 8;
			item.ranged = true;
			item.width = 64;
			item.height = 34;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 80000;
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.useAmmo = ModContent.ItemType<frostfirebulletitem>();
			item.shoot = ModContent.ProjectileType<frostfirebullet>();
			item.shootSpeed = 20f;
		}
	}
}