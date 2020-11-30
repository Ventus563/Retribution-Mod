using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraHeartsTest.Items.Weapons
{
	public class Sirius : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("Sirius"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Shoots a powerful star everytime you right click.");
		}

		public override void SetDefaults() 
		{
			item.damage = 74;
			item.melee = true;
			item.width = 60;
			item.height = 60;
			item.useTime =15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FallingStar, 10);
            recipe.AddIngredient(ItemID.HallowedBar, 15);
            recipe.AddIngredient(ItemsID.SoulOfLight, 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if(player.altFunctionUse == 2)
			{
				item.useTime = 20;
				item.useAnimation = 20;
				item.shootSpeed = 16f;
				item.shoot = ProjectileID.FallingStar;
				item.mana = 13;
			} else
			{
				item.useTime = 20;
				item.useAnimation = 20;
				item.shootSpeed = 0f;
				item.shoot = 0;
			}
			return base.CanUseItem(player);

        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if(player.altFunctionUse == 2)
			{
				target.AddBuff(BuffID.OnFire, 50);

		}

		
    
	}
	}
}