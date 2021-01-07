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
using Retribution.Items;
using Retribution.Projectiles;

namespace Retribution
{
    public class RetributionItem : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            item.autoReuse = true;

            if (item.type == ItemID.Cobweb)
            {
                item.ammo = ItemID.Cobweb;
                item.shoot = ModContent.ProjectileType<webshot>();
            }

            if (item.type == ModContent.ItemType<frostfirebulletitem>())
            {
                item.ammo = ModContent.ItemType<frostfirebulletitem>();
                item.shoot = ModContent.ProjectileType<frostfirebullet>();
            }
        }
    }
}