//using Retribution.Dusts;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace Retribution.Tiles
{
	public class bluemoss_tree : ModTree
	{
		private Mod mod => ModLoader.GetMod("Retribution");

		/*public override int CreateDust()
		{
			return ModContent.DustType<Sparkle>();
		}

		public override int GrowthFXGore()
		{
			return mod.GetGoreSlot("Gores/ExampleTreeFX");
		}*/

		public override int DropWood()
		{
			return ModContent.ItemType<Items.Blocks.infectedgrassblock>();
		}

		public override Texture2D GetTexture()
		{
			return mod.GetTexture("Tiles/bluemoss_tree");
		}

		public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
		{
			return mod.GetTexture("Tiles/bluemoss_tree_tops");
		}

		public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
		{
			return mod.GetTexture("Tiles/bluemoss_tree_branches");
		}
	}
}