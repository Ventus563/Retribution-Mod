using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items.Weapons.Mage
{
	public class GalvanationHoldOut : ModProjectile
	{

		public const int NumBeams = 4;

		public const float MaxCharge = 180f;

		public const float DamageStart = 30f;

		private const float AimResponsiveness = 0.08f;

		private const int SoundInterval = 20;

		private const float MaxManaConsumptionDelay = 15f;
		private const float MinManaConsumptionDelay = 5f;

		private float FrameCounter
		{
			get => projectile.ai[0];
			set => projectile.ai[0] = value;
		}

		private float NextManaFrame
		{
			get => projectile.ai[1];
			set => projectile.ai[1] = value;
		}

		private float ManaConsumptionRate
		{
			get => projectile.localAI[0];
			set => projectile.localAI[0] = value;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Galvanation");

			ProjectileID.Sets.NeedsUUID[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.LastPrism);
			projectile.alpha = 255;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			Vector2 rrp = player.RotatedRelativePoint(player.MountedCenter, true);

			UpdateDamageForManaSickness(player);

			FrameCounter += 1f;

			PlaySounds();

			UpdatePlayerVisuals(player, rrp);

			if (projectile.owner == Main.myPlayer)
			{
				UpdateAim(rrp, player.HeldItem.shootSpeed);

				bool manaIsAvailable = !ShouldConsumeMana() || player.CheckMana(player.HeldItem.mana, true, false);

				bool stillInUse = player.channel && manaIsAvailable && !player.noItems && !player.CCed;

				if (stillInUse && FrameCounter == 1f)
				{
					FireBeams();
				}

				else if (!stillInUse)
				{
					projectile.Kill();
				}
			}

			projectile.timeLeft = 2;
		}

		private void UpdateDamageForManaSickness(Player player)
		{
			float ownerCurrentMagicDamage = player.allDamage + (player.magicDamage - 1f);
			projectile.damage = (int)(player.HeldItem.damage * ownerCurrentMagicDamage);
		}

		private void PlaySounds()
		{
			if (projectile.soundDelay <= 0)
			{
				projectile.soundDelay = SoundInterval;

				if (FrameCounter > 1f)
				{
					Main.PlaySound(SoundID.Item15, projectile.position);
				}
			}
		}

		private void UpdatePlayerVisuals(Player player, Vector2 playerHandPos)
		{
			projectile.Center = playerHandPos;
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
			projectile.spriteDirection = projectile.direction;

			player.ChangeDir(projectile.direction);
			player.heldProj = projectile.whoAmI;
			player.itemTime = 2;

			player.itemRotation = (projectile.velocity * projectile.direction).ToRotation();
		}

		private bool ShouldConsumeMana()
		{
			if (ManaConsumptionRate == 0f)
			{
				NextManaFrame = ManaConsumptionRate = MaxManaConsumptionDelay;
				return true;
			}

			bool consume = FrameCounter == NextManaFrame;

			if (consume)
			{
				ManaConsumptionRate = MathHelper.Clamp(ManaConsumptionRate - 1f, MinManaConsumptionDelay, MaxManaConsumptionDelay);
				NextManaFrame += ManaConsumptionRate;
			}
			return consume;
		}

		private void UpdateAim(Vector2 source, float speed)
		{
			Vector2 aim = Vector2.Normalize(Main.MouseWorld - source);
			if (aim.HasNaNs())
			{
				aim = -Vector2.UnitY;
			}

			aim = Vector2.Normalize(Vector2.Lerp(Vector2.Normalize(projectile.velocity), aim, AimResponsiveness));
			aim *= speed;

			if (aim != projectile.velocity)
			{
				projectile.netUpdate = true;
			}
			projectile.velocity = aim;
		}

		private void FireBeams()
		{
			Vector2 beamVelocity = Vector2.Normalize(projectile.velocity);
			if (beamVelocity.HasNaNs())
			{
				beamVelocity = -Vector2.UnitY;
			}

			int uuid = Projectile.GetByUUID(projectile.owner, projectile.whoAmI);

			int damage = projectile.damage;
			float knockback = projectile.knockBack;
			for (int b = 0; b < NumBeams; ++b)
			{
				Projectile.NewProjectile(projectile.Center, beamVelocity, ModContent.ProjectileType<GalvanationBeam>(), damage, knockback, projectile.owner, b, uuid);
			}

			projectile.netUpdate = true;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			SpriteEffects effects = projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = Main.projectileTexture[projectile.type];
			int frameHeight = texture.Height / Main.projFrames[projectile.type];
			int spriteSheetOffset = frameHeight * projectile.frame;
			Vector2 sheetInsertPosition = (projectile.Center + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition).Floor();

			return false;
		}
	}
}