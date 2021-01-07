using Terraria;
using Retribution.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items.Weapons
{
	public class CoolWeapon : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("This is a modded magic weapon.");
			Item.staff[item.type] = true; 
		}

		public override void SetDefaults()
		{
			item.damage = 20;
			item.magic = true;
			item.mana = 12;
			item.width = 40;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item28;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<Snowflake>();
			item.shootSpeed = 8f;
		}
	}
}