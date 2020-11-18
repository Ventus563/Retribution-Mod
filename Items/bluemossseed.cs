using Terraria.ModLoader;
using Terraria.ID;
using Retribution.Tiles;

namespace Retribution.Items
{
	public class bluemossseed : ModItem
	{
		public override void SetDefaults()
		{
			item.autoReuse = true;
			item.useTurn = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 15;
			item.useTime = 10;
			item.maxStack = 99;
			item.consumable = true;
			item.placeStyle = 0;
			item.width = 12;
			item.height = 14;
			item.value = 80;
			item.createTile = mod.TileType("swampherb");
		}
	}
}