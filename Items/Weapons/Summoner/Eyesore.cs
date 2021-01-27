using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Retribution.Projectiles;
using Microsoft.Xna.Framework.Graphics;

namespace Retribution.Items.Weapons.Summoner
{
    public class Eyesore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eyesore");
        }
        public override void SetDefaults()
        {
			item.width = 48;
			item.height = 44;
            item.useStyle = 5;
            item.channel = true;
            item.useAnimation = 18;
            item.useTime = 18;
            item.UseSound = SoundID.Item19;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.summon = true;
            item.damage = 32;
            item.knockBack = 3.5f;
            item.shoot = ModContent.ProjectileType<spinalfractureproj>();
            item.shootSpeed = 80f;
            item.rare = 0;
            item.value = Item.sellPrice(0,0,0,80);
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Rope, 50);
            recipe.AddIngredient(ItemID.Gel, 15);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, 0, 
            Main.rand.Next(-300, 300) * 0.001f * player.gravDir);
            return false;
        }
    }

    public class eyesorewhip : ModProjectile
    {
        public const float whipLength = 30f;
        public const bool whipSoftSound = true;
        public const int handleHeight = 24;
        public const int chainHeight = 12;
        public const int partHeight = 12;
        public const int tipHeight = 12;
        public const bool doubleCritWindow = true;
        public const bool ignoreLighting = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eyesore");
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
        }
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.scale = 1f;
            projectile.aiStyle = 75;
            projectile.penetrate = -1;
            projectile.alpha = 0;
            projectile.hide = true;
            projectile.extraUpdates = 4;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.usesLocalNPCImmunity = true;
        }

        public override void AI()
        {
            LashProj.LashAI(projectile, whipLength);
        }

        #region BaseWhip Stuff

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            LashProj.ModifyHitAny(projectile, ref damage, ref knockback, ref crit, doubleCritWindow);
        }
        public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
        {
            LashProj.ModifyHitAny(projectile, ref damage, ref crit);
        }
        public override void ModifyHitPvp(Player target, ref int damage, ref bool crit)
        {
            LashProj.ModifyHitAny(projectile, ref damage, ref crit);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            LashProj.OnHitAny(projectile, target, crit, whipSoftSound);
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            LashProj.OnHitAny(projectile, crit, whipSoftSound);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            LashProj.OnHitAny(projectile, crit, whipSoftSound);
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            return LashProj.Colliding(projectile, targetHitbox);
        }

        public override bool? CanCutTiles()
        {
            return LashProj.CanCutTiles(projectile);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            return LashProj.PreDraw(projectile, handleHeight, chainHeight, partHeight, tipHeight, 3, ignoreLighting, doubleCritWindow);
        }

        #endregion
    }
}