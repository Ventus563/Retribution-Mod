using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;

namespace Retribution
{
    public abstract class NightmareColor : ModItem
    {
        internal int nightmareRarity;

        public static Color Magenta => new Color(148, 0, 54);
    }
}
