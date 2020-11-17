using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Enums;
using Retribution.Tiles;

namespace Retribution.Tiles
{
    public class bluemoss : ModTile
    {
        int distance = 1;

        public override void SetDefaults()
        {
            Main.tileBrick[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            dustType = mod.DustType("Stone");
            AddMapEntry(new Color(84, 202, 232));
            SetModTree(new bluemoss_tree());

            drop = mod.ItemType("bluemossseed");
        }
        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return ModContent.TileType<sicklysapling>();
        }
    }
}