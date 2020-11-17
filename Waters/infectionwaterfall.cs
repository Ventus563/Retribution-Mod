using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Retribution.Waters
{
	public class infectionwaterfall : ModWaterfallStyle
	{
		public override void AddLight(int i, int j) =>
			Lighting.AddLight(new Vector2(i, j).ToWorldCoordinates(), Color.DarkGreen.ToVector3() * 0.5f);
	}
}