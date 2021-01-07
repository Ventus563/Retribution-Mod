using Retribution.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items.Weapons.Mage
{
	public class honeyray : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Honey Ray");
			Tooltip.SetDefault("Generates a honey beam to pulverize your enemies");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 12;
			item.channel = true;
			item.magic = true;
			item.mana = 5;
			item.rare = ItemRarityID.Blue;
			item.width = 44;
			item.height = 44;
			item.useTime = 20;
			item.UseSound = SoundID.Item13;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.shootSpeed = 14f;
			item.useAnimation = 20;
			item.shoot = ModContent.ProjectileType<honeybeamproj>();
			item.value = Item.sellPrice(silver: 3);
		}
	}
}