using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.Enums;
using Terraria.GameContent.Shaders;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items.Weapons.Mage
{
	public class GalvanationBeam : ModProjectile
	{
		private const float PiBeamDivisor = MathHelper.Pi / GalvanationHoldOut.NumBeams;

		private const float MaxDamageMultiplier = 1.5f;

		private const float MaxBeamScale = 1.8f;

		private const float MaxBeamSpread = 2f;

		private const float MaxBeamLength = 2400f;

		private const float BeamTileCollisionWidth = 1f;

		private const float BeamHitboxCollisionWidth = 22f;

		private const int NumSamplePoints = 3;

		private const float BeamLengthChangeFactor = 0.75f;

		private const float VisualEffectThreshold = 0.1f;

		private const float OuterBeamOpacityMultiplier = 0.75f;
		private const float InnerBeamOpacityMultiplier = 0.1f;

		private const float BeamLightBrightness = 0.75f;

		private const float BeamColorHue = 1f;
		private const float BeamHueVariance = 0.05f;
		private const float BeamColorSaturation = 1f;
		private const float BeamColorLightness = 0.53f;

		private float BeamID
		{
			get => projectile.ai[0];
			set => projectile.ai[0] = value;
		}

		private float HostPrismIndex
		{
			get => projectile.ai[1];
			set => projectile.ai[1] = value;
		}

		private float BeamLength
		{
			get => projectile.localAI[1];
			set => projectile.localAI[1] = value;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Example Prism Beam");
		}

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.magic = true;
			projectile.penetrate = -1;
			projectile.alpha = 255;
		    projectile.tileCollide = false;

			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 10;
		}

		public override void SendExtraAI(BinaryWriter writer) => writer.Write(BeamLength);
		public override void ReceiveExtraAI(BinaryReader reader) => BeamLength = reader.ReadSingle();

		public override void AI()
		{
			Projectile hostPrism = Main.projectile[(int)HostPrismIndex];
			if (projectile.type != ModContent.ProjectileType<GalvanationBeam>() || !hostPrism.active || hostPrism.type != ModContent.ProjectileType<GalvanationHoldOut>())
			{
				projectile.Kill();
				return;
			}

			Vector2 hostPrismDir = Vector2.Normalize(hostPrism.velocity);
			float chargeRatio = MathHelper.Clamp(hostPrism.ai[0] / GalvanationHoldOut.MaxCharge, 0f, 1f);

			projectile.damage = (int)(hostPrism.damage * GetDamageMultiplier(chargeRatio));

			projectile.friendly = hostPrism.ai[0] > GalvanationHoldOut.DamageStart;

			float beamIdOffset = BeamID - GalvanationHoldOut.NumBeams / 2f + 0.5f;
			float beamSpread;
			float spinRate;
			float beamStartSidewaysOffset;
			float beamStartForwardsOffset;

			if (chargeRatio < 1f)
			{
				projectile.scale = MathHelper.Lerp(0f, MaxBeamScale, chargeRatio);
				beamSpread = MathHelper.Lerp(MaxBeamSpread, 0f, chargeRatio);
				beamStartSidewaysOffset = MathHelper.Lerp(20f, 6f, chargeRatio);
				beamStartForwardsOffset = MathHelper.Lerp(-21f, -17f, chargeRatio);

				if (chargeRatio <= 0.66f)
				{
					float phaseRatio = chargeRatio * 1.5f;
					projectile.Opacity = MathHelper.Lerp(0f, 0.4f, phaseRatio);
					spinRate = MathHelper.Lerp(20f, 16f, phaseRatio);
				}

				else
				{
					float phaseRatio = (chargeRatio - 0.66f) * 3f;
					projectile.Opacity = MathHelper.Lerp(0.4f, 1f, phaseRatio);
					spinRate = MathHelper.Lerp(16f, 6f, phaseRatio);
				}
			}

			else
			{
				projectile.scale = MaxBeamScale;
				projectile.Opacity = 1f;
				beamSpread = 0f;
				spinRate = 6f;
				beamStartSidewaysOffset = 6f;
				beamStartForwardsOffset = -17f;
			}

			float deviationAngle = (hostPrism.ai[0] + beamIdOffset * spinRate) / (spinRate * GalvanationHoldOut.NumBeams) * MathHelper.TwoPi;

			Vector2 unitRot = Vector2.UnitY.RotatedBy(deviationAngle);
			Vector2 yVec = new Vector2(4f, beamStartSidewaysOffset);
			float hostPrismAngle = hostPrism.velocity.ToRotation();
			Vector2 beamSpanVector = (unitRot * yVec).RotatedBy(hostPrismAngle);
			float sinusoidYOffset = unitRot.Y * PiBeamDivisor * beamSpread;

			projectile.Center = hostPrism.Center;
			projectile.position += hostPrismDir * 16f + new Vector2(0f, -hostPrism.gfxOffY);
			projectile.position += hostPrismDir * beamStartForwardsOffset;
			projectile.position += beamSpanVector;

			projectile.velocity = hostPrismDir.RotatedBy(sinusoidYOffset);
			if (projectile.velocity.HasNaNs() || projectile.velocity == Vector2.Zero)
			{
				projectile.velocity = -Vector2.UnitY;
			}
			projectile.rotation = projectile.velocity.ToRotation();

			float hitscanBeamLength = PerformBeamHitscan(hostPrism, chargeRatio >= 1f);
			BeamLength = MathHelper.Lerp(BeamLength, hitscanBeamLength, BeamLengthChangeFactor);

			Vector2 beamDims = new Vector2(projectile.velocity.Length() * BeamLength, projectile.width * projectile.scale);
			Color beamColor = GetOuterBeamColor();
			if (chargeRatio >= VisualEffectThreshold)
			{
				ProduceBeamDust(beamColor);

				if (Main.netMode != NetmodeID.Server)
				{
					ProduceWaterRipples(beamDims);
				}
			}

			DelegateMethods.v3_1 = beamColor.ToVector3() * BeamLightBrightness * chargeRatio;
			Utils.PlotTileLine(projectile.Center, projectile.Center + projectile.velocity * BeamLength, beamDims.Y, new Utils.PerLinePoint(DelegateMethods.CastLight));
		}

		private float GetDamageMultiplier(float chargeRatio)
		{
			float f = chargeRatio * chargeRatio * chargeRatio;
			return MathHelper.Lerp(1f, MaxDamageMultiplier, f);
		}

		private float PerformBeamHitscan(Projectile prism, bool fullCharge)
		{
			Vector2 samplingPoint = projectile.Center;
			if (fullCharge)
			{
				samplingPoint = prism.Center;
			}

			Player player = Main.player[projectile.owner];
			if (!Collision.CanHitLine(player.Center, 0, 0, prism.Center, 0, 0))
			{
				samplingPoint = player.Center;
			}

			float[] laserScanResults = new float[NumSamplePoints];
			Collision.LaserScan(samplingPoint, projectile.velocity, BeamTileCollisionWidth * projectile.scale, MaxBeamLength, laserScanResults);
			float averageLengthSample = 0f;
			for (int i = 0; i < laserScanResults.Length; ++i)
			{
				averageLengthSample += laserScanResults[i];
			}
			averageLengthSample /= NumSamplePoints;

			return averageLengthSample;
		}

		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			if (projHitbox.Intersects(targetHitbox))
			{
				return true;
			}

			float _ = float.NaN;
			Vector2 beamEndPos = projectile.Center + projectile.velocity * BeamLength;
			return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), projectile.Center, beamEndPos, BeamHitboxCollisionWidth * projectile.scale, ref _);
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			if (projectile.velocity == Vector2.Zero)
			{
				return false;
			}

			Texture2D texture = Main.projectileTexture[projectile.type];
			Vector2 centerFloored = projectile.Center.Floor() + projectile.velocity * projectile.scale * 10.5f;
			Vector2 drawScale = new Vector2(projectile.scale);

			float visualBeamLength = BeamLength - 14.5f * projectile.scale * projectile.scale;

			DelegateMethods.f_1 = 1f;
			Vector2 startPosition = centerFloored - Main.screenPosition;
			Vector2 endPosition = startPosition + projectile.velocity * visualBeamLength;

			DrawBeam(spriteBatch, texture, startPosition, endPosition, drawScale, GetOuterBeamColor() * OuterBeamOpacityMultiplier * projectile.Opacity);

			drawScale *= 0.5f;
			DrawBeam(spriteBatch, texture, startPosition, endPosition, drawScale, GetInnerBeamColor() * InnerBeamOpacityMultiplier * projectile.Opacity);

			return false;
		}

		private void DrawBeam(SpriteBatch spriteBatch, Texture2D texture, Vector2 startPosition, Vector2 endPosition, Vector2 drawScale, Color beamColor)
		{
			Utils.LaserLineFraming lineFraming = new Utils.LaserLineFraming(DelegateMethods.RainbowLaserDraw);

			DelegateMethods.c_1 = beamColor;
			Utils.DrawLaser(spriteBatch, texture, startPosition, endPosition, drawScale, lineFraming);
		}

		private Color GetOuterBeamColor()
		{
			float hue = (BeamID / GalvanationHoldOut.NumBeams) % BeamHueVariance + BeamColorHue;

			Color c = Main.hslToRgb(hue, BeamColorSaturation, BeamColorLightness);

			c.A = 64;
			return c;
		}

		private Color GetInnerBeamColor() => Color.White;

		private void ProduceBeamDust(Color beamColor)
		{
			const int type = 15;
			Vector2 endPosition = projectile.Center + projectile.velocity * (BeamLength - 14.5f * projectile.scale);

			float angle = projectile.rotation + (Main.rand.NextBool() ? 1f : -1f) * MathHelper.PiOver2;
			float startDistance = Main.rand.NextFloat(1f, 1.8f);
			float scale = Main.rand.NextFloat(0.7f, 1.1f);
			Vector2 velocity = angle.ToRotationVector2() * startDistance;
			Dust dust = Dust.NewDustDirect(endPosition, 0, 0, type, velocity.X, velocity.Y, 0, beamColor, scale);
			dust.color = beamColor;
			dust.noGravity = true;

			if (projectile.scale > 1f)
			{
				dust.velocity *= projectile.scale;
				dust.scale *= projectile.scale;
			}
		}

		private void ProduceWaterRipples(Vector2 beamDims)
		{
			WaterShaderData shaderData = (WaterShaderData)Filters.Scene["WaterDistortion"].GetShader();

			float waveSine = 0.1f * (float)Math.Sin(Main.GlobalTime * 20f);
			Vector2 ripplePos = projectile.position + new Vector2(beamDims.X * 0.5f, 0f).RotatedBy(projectile.rotation);

			Color waveData = new Color(0.5f, 0.1f * Math.Sign(waveSine) + 0.5f, 0f, 1f) * Math.Abs(waveSine);
			shaderData.QueueRipple(ripplePos, waveData, beamDims, RippleShape.Square, projectile.rotation);
		}


		public override void CutTiles()
		{
			DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
			Utils.PerLinePoint cut = new Utils.PerLinePoint(DelegateMethods.CutTiles);
			Vector2 beamStartPos = projectile.Center;
			Vector2 beamEndPos = beamStartPos + projectile.velocity * BeamLength;

			Utils.PlotTileLine(beamStartPos, beamEndPos, projectile.width * projectile.scale, cut);
		}
	}
}