using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Retribution.NPCs.Bosses.EvilSnowman;

namespace Retribution.NPCs.Bosses.EvilSnowman
{
	public class IceShard2H : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snowflake");
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

		}
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item27, projectile.position);
		}
	}
}