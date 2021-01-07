using Retribution.Projectiles;
using Retribution.Items.Souls;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Retribution.Items.Materials;

namespace Retribution.Items.Weapons.Mage
{
	public class oculus : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Oculus");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 46;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useTime = 30;
			item.useAnimation = 30;
			item.damage = 16;
			item.crit = 4;
			item.noMelee = true;
			item.magic = true;
			item.autoReuse = true;
			item.UseSound = SoundID.Item8;
			item.shoot = ModContent.ProjectileType<oculusproj>();
			item.shootSpeed = 9f;
			item.mana = 8;
		}
	}
}