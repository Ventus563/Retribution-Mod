using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Projectiles
{
	public class WaxWhizProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {

			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 3.5f;
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 300f;
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 13f;
		}

		public override void SetDefaults() {
			projectile.extraUpdates = 0;
			projectile.width = 16;
			projectile.height = 16;
			
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
		}
		
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 16);
				dust.noGravity = true;
				dust.scale = 1.6f;
			}
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if(player.altFunctionUse == 1)
			{
				target.AddBuff(BuffID.Poisoned, 5);
	
		}
    
	}
	}
}
