using Terraria.Graphics.Shaders;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Projectiles
{
	public class Sabretooth : ModProjectile
	{

		public override void SetDefaults()
		{
			projectile.width = 38;
			projectile.height = 38;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.timeLeft = 5;
			projectile.penetrate = -1;
            projectile.CloneDefaults(ProjectileID.LightDisc);
		}
	}
}