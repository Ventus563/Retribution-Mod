using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Retribution.Items;

namespace Retribution.NPCs.TownNPCs
{
	[AutoloadHead]
	public class collector : ModNPC
	{
		public override string Texture => "Retribution/NPCs/TownNPCs/collector";

		public override bool Autoload(ref string name)
		{
			name = "Collector";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (!player.active)
				{
					continue;
				}
			}

			if (NPC.downedSlimeKing)
			{
				return true;
			}
			return false;
		}

		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(4))
			{
				case 0:
					return "Christopher";
				case 1:
					return "Charles";
				case 2:
					return "James";
				case 3:
					return "Richard";
				case 4:
					return "Alexander";
				case 5:
					return "Adam";
				case 6:
					return "Theodore";
				case 7:
					return "George";
				case 8:
					return "Abraham";
				default:
					return "Nathanial";
			}
		}

		public override string GetChat()
		{
			switch (Main.rand.Next(5))
			{
				case 0:
					return "I... have a problem.";
				case 1:
					return "The oceans are a nice calm place to relax. But watch out for sharks.";
				case 2:
                    return "I can provide you with Boss loot after it has been defeated at least once.";
				case 3:
					return "For some reason I feel trapped...";
				case 4:
					return "As you can tell, I like collecting... things.";
				default:
					return "Howdy, Partner!";
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			int index = 0;

			if (NPC.downedSlimeKing)
			{
				shop.item[nextSlot].SetDefaults(ItemID.KingSlimeBossBag);
				shop.item[nextSlot].shopCustomPrice = 300000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.KingSlimeTrophy);
				nextSlot++;
			}

			if (NPC.downedBoss1)
			{
				shop.item[nextSlot].SetDefaults(ItemID.EyeOfCthulhuBossBag);
				shop.item[nextSlot].shopCustomPrice = 300000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.EyeofCthulhuTrophy);
				nextSlot++;
			}

			if (NPC.downedBoss2)
			{
				shop.item[nextSlot].SetDefaults(ItemID.EaterOfWorldsBossBag);
				shop.item[nextSlot].shopCustomPrice = 300000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.BrainOfCthulhuBossBag);
				shop.item[nextSlot].shopCustomPrice = 300000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.EaterofWorldsTrophy);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.BrainofCthulhuTrophy);
				nextSlot++;
			}
			if (NPC.downedQueenBee)
			{
				shop.item[nextSlot].SetDefaults(ItemID.QueenBeeBossBag);
				shop.item[nextSlot].shopCustomPrice = 300000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.QueenBeeTrophy);
				nextSlot++;
			}
			if (NPC.downedBoss3)
			{
				shop.item[nextSlot].SetDefaults(ItemID.SkeletronBossBag);
				shop.item[nextSlot].shopCustomPrice = 300000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.SkeletronTrophy);
				nextSlot++;
			}
			if (Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults(ItemID.WallOfFleshBossBag);
				shop.item[nextSlot].shopCustomPrice = 300000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.WallofFleshTrophy);
				nextSlot++;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ProjectileID.SpikyBall;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}