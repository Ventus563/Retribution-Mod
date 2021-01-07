using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Retribution.NPCs.Bosses.EvilSnowman;

namespace Retribution.NPCs.Bosses.EvilSnowman
{
	public class IceShardH : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snowfalke");
		}

		public override void SetDefaults()
		{
			projectile.width = 40;
			projectile.height = 40;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.ranged = true;
			projectile.timeLeft = 60;
		}

        public override void AI()
        {
			projectile.rotation += 0.2f * (float)projectile.direction;
		}
		public override void Kill(int timeLeft)
        {
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 2, 2, ModContent.ProjectileType<IceShard2H>(), 20, 0f, Main.myPlayer, projectile.whoAmI, 10);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 5, ModContent.ProjectileType<IceShard2H>(), 20, 0f, Main.myPlayer, projectile.whoAmI, 10);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5, 0, ModContent.ProjectileType<IceShard2H>(), 20, 0f, Main.myPlayer, projectile.whoAmI, 10);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5, 0, ModContent.ProjectileType<IceShard2H>(), 20, 0f, Main.myPlayer, projectile.whoAmI, 10);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -5, ModContent.ProjectileType<IceShard2H>(), 20, 0f, Main.myPlayer, projectile.whoAmI, 10);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -2, -2, ModContent.ProjectileType<IceShard2H>(), 20, 0f, Main.myPlayer, projectile.whoAmI, 10);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -2, 2, ModContent.ProjectileType<IceShard2H>(), 20, 0f, Main.myPlayer, projectile.whoAmI, 10);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 2, -2, ModContent.ProjectileType<IceShard2H>(), 20, 0f, Main.myPlayer, projectile.whoAmI, 10);
				
            Main.PlaySound(SoundID.Item27, projectile.position);
        }
    }
}