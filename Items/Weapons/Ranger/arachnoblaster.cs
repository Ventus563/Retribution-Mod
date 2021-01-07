using Retribution.Projectiles;
using Retribution.Items.Souls;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Retribution.Items.Weapons.Ranger
{
	public class arachnoblaster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arachnoblaster");
			Tooltip.SetDefault("Uses Cobwebs for ammo");
		}

		public override void SetDefaults()
		{
			item.damage = 24;
			item.ranged = true;
			item.width = 50;
			item.height = 26;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 80000;
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.DD2_OgreSpit;
			item.autoReuse = true;
			item.useAmmo = ItemID.Cobweb;
			item.shoot = ModContent.ProjectileType<webshot>();
			item.shootSpeed = 16f;
		}
	}
}