using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items.Weapons.Ranger
{
  public class Goblin_Bow : ModItem
  {
  public override void SetStaticDefaults()
  {
  DisplayName.SetDefault("Windbreaker");
  Tooltip.SetDefault("A strong and sturdy bow that shoots out a gust of wind.");
  }

  public override void SetDefaults()
  {
  item.damage = 16;
  item.ranged = true;
  item.width = 12;
  item.height = 38;
  item.maxStack = 1;
  item.useTime = 28;
  item.useAnimation = 28;
  item.useStyle = 5;
  item.knockBack = 2;
  item.value = 12000;
  item.rare = 2;
  item.UseSound = SoundID.Item5;
  item.noMelee = true;
  item.shoot = ModContent.ProjectileType<WindWave>();
  item.useAmmo = AmmoID.Arrow;
  item.shootSpeed = 10f;
  item.autoReuse = false;
  }
  }
}