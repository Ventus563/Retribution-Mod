using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Projectiles
{
	public class IceShard2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snowflake");
		}

		public override void SetDefaults()
		{
			projectile.width = 40;
			projectile.height = 40;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.timeLeft = 45;
		}

        public override void AI()
        {

		}
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item27, projectile.position);
		}
	}
}