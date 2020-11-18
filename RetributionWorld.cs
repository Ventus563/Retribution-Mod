using System.IO;
using System.Collections.Generic;
using Terraria;
using System;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using System.Linq;
using Retribution.Tiles;

namespace Retribution
{
    public class RetributionWorld : ModWorld
    {
        public static int swampTiles = 0;

        public static bool downedKane = false;


        // Going to work on later, not currently a priority.
        #region World Gen
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
        	int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex != -1) {

				tasks.Insert(ShiniesIndex + 1, new PassLegacy("Rubidium", Rubidium));
			}

            /*int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Jungle"));
            if (genIndex == -1)
            {
                return;
            }
            tasks.Insert(genIndex + 1, new PassLegacy("ZoneSwamp", delegate (GenerationProgress progress)
			{
				progress.Message = "Spreading Moss";
				for (int i = 0; i < Main.maxTilesX / 1000; i++)
				{
					int X = WorldGen.genRand.Next(1, Main.maxTilesX +- 100);
					int Y = WorldGen.genRand.Next((int)WorldGen.worldSurface - 200, Main.maxTilesY - 800);
                    int SS = mod.TileType("sicklysapling");
                    int SH = mod.TileType("swampherb");

                    WorldGen.TileRunner(X +- 300, Y, 400, WorldGen.genRand.Next(100, 300), ModContent.TileType<bluemoss>(), false, 0f, 0f, true, true);
                    WorldGen.PlaceObject(X, Y - 1, SS);
                    WorldGen.PlaceObject(X, Y - 1, SH);
                    WorldGen.GrowTree(X, Y - 1);
                }
			}));*/
		}
        #endregion

        private void Rubidium(GenerationProgress progress)
        {
            progress.Message = "Generating Rubidium";

            for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY);

                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), ModContent.TileType<rubidium>());
            }
        }

        public override void TileCountsAvailable(int[] tileCounts)
        {
            swampTiles = tileCounts[mod.TileType("bluemoss")];
        }

        public override void ResetNearbyTileEffects()
        {
            swampTiles = 0;
        }
    }
}