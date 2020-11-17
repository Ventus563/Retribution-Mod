using Retribution.NPCs.Bosses.Kane;
using Retribution.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items
{
	//imported from my tAPI mod because I'm lazy
	public class mysterioustikitotem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mysterious Tiki Totem");
			Tooltip.SetDefault("Summons the God of Life");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 46;
			item.maxStack = 20;
			item.rare = ItemRarityID.Cyan;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return player.ZoneJungle && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.Kane.Kane>());
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Bosses.Kane.Kane>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofMight);
			recipe.AddIngredient(ItemID.SoulofSight);
			recipe.AddIngredient(ItemID.SoulofFright);
			recipe.AddIngredient(ItemID.RichMahogany, 25);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}