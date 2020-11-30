using Retribution.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Retribution.Waters
{
	public class swampwater : ModWaterStyle
	{
		public override bool ChooseWaterStyle()
			=> Main.bgStyle == mod.GetSurfaceBgStyleSlot("swampBg");

		public override int ChooseWaterfallStyle() 
			=> mod.GetWaterfallStyleSlot("swampwaterfall");

		public override int GetSplashDust()
			=> DustType<swampwatersplash>();

		public override int GetDropletGore() 
			=> mod.GetGoreSlot("Gores/swampdroplet");

		public override void LightColorMultiplier(ref float r, ref float g, ref float b) {
			r = 1f;
			g = 1f;
			b = 1f;
		}

		public override Color BiomeHairColor() 
			=> Color.DarkGreen;
	}
}