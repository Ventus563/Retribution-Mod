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
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using Retribution.Items;

namespace Retribution
{
    public class RetributionWorld : ModWorld
    {
        public static int swampTiles = 0;

        public static bool nightmareMode = false;

        #region Boss Checks
        public static bool downedVilacious = false;
        public static bool downedSanguine = false;
        public static bool downedKane = false;
        public static bool downedMorbus = false;
        public static bool downedTesca = false;
        #endregion

        #region Save/Load
        public override TagCompound Save()
        {
            var nightmare = new List<string>();
            if (nightmareMode)
            {
                nightmare.Add("NightmareMode");
            }

            var downed = new List<string>();
            if (downedKane)
            {
                downed.Add("Kane");
            }

            if (downedSanguine)
            {
                downed.Add("Sanguine");
            }

            if (downedVilacious)
            {
                downed.Add("Vilacious");
            }

            return new TagCompound
            {
                ["downed"] = downed,
                ["nightmare"] = nightmare,
            };
        }

        public override void Load(TagCompound tag)
        {
            var nightmare = tag.GetList<string>("nightmare");
            nightmareMode = nightmare.Contains("NightmareMode");

            var downed = tag.GetList<string>("downed");
            downedKane = downed.Contains("Kane");
            downedSanguine = downed.Contains("Sanguine");
            downedVilacious = downed.Contains("Vilacious");
        }
        #endregion

        // Going to work on later, not currently a priority.
        #region World Gen
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (ShiniesIndex != -1) {

                tasks.Insert(ShiniesIndex + 1, new PassLegacy("Rubidium", Rubidium));
                tasks.Insert(ShiniesIndex + 1, new PassLegacy("Kyanite", Kyanite));
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

        public override void PostWorldGen()
        {
            int[] itemsToPlaceInChests = { ModContent.ItemType<scratchedmirror>()};
            int itemsToPlaceInChestsChoice = 0;
            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];

                if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 0 * 36)
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        {
                            if (Main.rand.NextFloat() < .25f)
                            {
                                if (chest.item[inventoryIndex].type == ItemID.None)
                                {
                                    chest.item[inventoryIndex].SetDefaults(itemsToPlaceInChests[itemsToPlaceInChestsChoice]);
                                    itemsToPlaceInChestsChoice = (itemsToPlaceInChestsChoice + 1) % itemsToPlaceInChests.Length;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

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

        private void Kyanite(GenerationProgress progress)
        {
            progress.Message = "Generating Kyanite";

            for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 3E-05); k++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY);

                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(5, 8), WorldGen.genRand.Next(4, 8), ModContent.TileType<kyanite>());
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