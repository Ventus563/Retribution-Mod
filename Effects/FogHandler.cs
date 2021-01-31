using System;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Retribution.Effects
{
	public class FogHandler : ModWorld
	{
		private FogScreenFX hematicFog = new FogScreenFX(false);

		public override void PostDrawTiles()
		{
			hematicFog.Update(base.mod.GetTexture("Effects/Fog"));
			hematicFog.Draw(base.mod.GetTexture("Effects/Fog"), false, Color.White, true);
		}
	}
}
