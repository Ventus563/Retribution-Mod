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
        public static int mossTiles = 0;

        public static bool downedKane = false;

		/*public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {

            int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Terrain"));
            if (genIndex == -1)
            {
                return;
            }
            tasks.Insert(genIndex + 1, new PassLegacy("ZoneInfection", delegate (GenerationProgress progress)
            {
                progress.Message = "Spreading the Infection";
                for (int i = 0; i < Main.maxTilesX / 1000; i++)
                {
                    int X = WorldGen.genRand.Next(1, Main.maxTilesX - 900);
                    int Y = WorldGen.genRand.Next((int)WorldGen.worldSurface, Main.maxTilesY - 800);
                    int IE = TileID.Stone;
                    int SS = mod.TileType("sicklysapling");

                    WorldGen.TileRunner(Main.spawnTileX, Main.spawnTileY - 46, 6, Main.rand.Next(1, 3), IE, true, 0f, 0f, true, true);
                    WorldGen.PlaceObject(X, Y - 1, SS);
                    WorldGen.GrowTree(X, Y - 1);
                }
            }));
        }*/

		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
            int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Jungle"));
            if (genIndex == -1)
            {
                return;
            }
            tasks.Insert(genIndex + 1, new PassLegacy("OverworldMoss", delegate (GenerationProgress progress)
			{
				progress.Message = "Spreading Moss";
				for (int i = 0; i < Main.maxTilesX / 1000; i++)
				{
					int X = WorldGen.genRand.Next(1, Main.maxTilesX +- 100);
					int Y = WorldGen.genRand.Next((int)WorldGen.worldSurface - 200, Main.maxTilesY - 800);
                    int SS = mod.TileType("sicklysapling");

                    WorldGen.TileRunner(X +- 300, Y, 400, WorldGen.genRand.Next(100, 300), ModContent.TileType<bluemoss>(), false, 0f, 0f, true, true);
                    WorldGen.PlaceObject(X, Y - 1, SS);
                    WorldGen.GrowTree(X, Y - 1);
                }
			}));
		}


        public override void TileCountsAvailable(int[] tileCounts)
        {
            mossTiles = tileCounts[mod.TileType("bluemoss")];
        }

        public override void ResetNearbyTileEffects()
        {
            mossTiles = 0;
        }
    }
}