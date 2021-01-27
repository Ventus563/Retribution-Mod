using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;

namespace Retribution
{
    public abstract class NightmareRarity : NightmareColor
    {
        public Color? Magenta = null;

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            if (Magenta != null)
            {
                foreach (TooltipLine line2 in list)
                {
                    if (line2.mod == "Terraria" && line2.Name == "ItemName")
                    {
                        line2.overrideColor = (Color)Magenta;
                    }
                }
                return;
            }

            if (item.modItem is NightmareColor MyModItem && MyModItem.nightmareRarity != 0)
            {
                Color Rare;
                switch (MyModItem.nightmareRarity)
                {
                    default: Rare = Color.White; break;
                    case 12: Rare = NightmareColor.Magenta; break;
                }
                foreach (TooltipLine line2 in list)
                {
                    if (line2.mod == "Terraria" && line2.Name == "ItemName")
                    {
                        line2.overrideColor = Rare;
                    }
                }
            }
        }
    }
}
