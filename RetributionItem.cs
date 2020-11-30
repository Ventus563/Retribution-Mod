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
    public class RetributionItem : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            item.autoReuse = true;
        }
    }
}