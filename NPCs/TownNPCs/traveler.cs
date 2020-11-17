using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Retribution.Items;
using Retribution.Items.Consumables;

namespace Retribution.NPCs.TownNPCs
{
	// [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
	[AutoloadHead]
	public class traveler : ModNPC
	{
		public override string Texture => "Retribution/NPCs/TownNPCs/traveler";

		public override bool Autoload(ref string name)
		{
			name = "Traveler";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[npc.type] = 26;
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

		/*public override void HitEffect(int hitDirection, double damage)
		{
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, DustType<Sparkle>());
			}
		}*/

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

			if (NPC.downedBoss1)  //so after the EoC is killed
			{
				return true;
			}

			return false;
		}

		public override bool CheckConditions(int left, int right, int top, int bottom)    //Allows you to define special conditions required for this town NPC's house
		{
			return true;  //so when a house is available the npc will  spawn
		}

		// Example Person needs a house built out of ExampleMod tiles. You can delete this whole method in your townNPC for the regular house conditions.
		/*public override bool CheckConditions(int left, int right, int top, int bottom)
		{
			int score = 0;
			for (int x = left; x <= right; x++)
			{
				for (int y = top; y <= bottom; y++)
				{
					int type = Main.tile[x, y].type;
					if (type == TileType<ExampleBlock>() || type == TileType<ExampleChair>() || type == TileType<ExampleWorkbench>() || type == TileType<ExampleBed>() || type == TileType<ExampleDoorOpen>() || type == TileType<ExampleDoorClosed>())
					{
						score++;
					}
					if (Main.tile[x, y].wall == WallType<ExampleWall>())
					{
						score++;
					}
				}
			}
			return score >= (right - left) * (bottom - top) / 2;
		}*/

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

		public override void FindFrame(int frameHeight)
		{
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}

		public override string GetChat()
		{
			/*int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.NextBool(4))
			{
				return "Can you please tell " + Main.npc[partyGirl].GivenName + " hi";
			}*/
			switch (Main.rand.Next(5))
			{
				case 0:
					return "Traveling is my hobby. You should try it some time!";
				case 1:
					return "The oceans are a nice calm place to relax. But watch out for sharks.";
				case 2:
                    return "Have you ever been to the underworld? It's pretty freaky.";
				case 3:
					return "For some reason I feel trapped...";
				case 4:
					return "I can provide you with an easy way to travel across the world!";
				case 5:
					return "Howdy, Partner!";
				default:
					return "You can only travel to certain parts of the world after some conditions have been met.";
			}
		}

		/* 
		// Consider using this alternate approach to choosing a random thing. Very useful for a variety of use cases.
		// The WeightedRandom class needs "using Terraria.Utilities;" to use
		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();
			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.NextBool(4))
			{
				chat.Add("Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?");
			}
			chat.Add("Sometimes I feel like I'm different from everyone else here.");
			chat.Add("What's your favorite color? My favorite colors are white and black.");
			chat.Add("What? I don't have any arms or legs? Oh, don't be ridiculous!");
			chat.Add("This message has a weight of 5, meaning it appears 5 times more often.", 5.0);
			chat.Add("This message has a weight of 0.1, meaning it appears 10 times as rare.", 0.1);
			return chat; // chat is implicitly cast to a string. You can also do "return chat.Get();" if that makes you feel better
		}
		*/

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");
			//if (Main.LocalPlayer.HasItem(ItemID.HiveBackpack))
				//button = "Upgrade " + Lang.GetItemNameValue(ItemID.HiveBackpack);
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				// We want 3 different functionalities for chat buttons, so we use HasItem to change button 1 between a shop and upgrade action.
				/*if (Main.LocalPlayer.HasItem(ItemID.HiveBackpack))
				{
					Main.PlaySound(SoundID.Item37); // Reforge/Anvil sound
					Main.npcChatText = $"I upgraded your {Lang.GetItemNameValue(ItemID.HiveBackpack)} to a {Lang.GetItemNameValue(ItemType<Items.Accessories.WaspNest>())}";
					int hiveBackpackItemIndex = Main.LocalPlayer.FindItem(ItemID.HiveBackpack);
					Main.LocalPlayer.inventory[hiveBackpackItemIndex].TurnToAir();
					Main.LocalPlayer.QuickSpawnItem(ItemType<Items.Accessories.WaspNest>());
					return;
				}*/
				shop = true;
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			int index = 0;

			shop.item[nextSlot].SetDefaults(ItemID.FallenStar);
			nextSlot++;
		}

		/*public override void NPCLoot()
		{
			Item.NewItem(npc.getRect(), ItemType<Items.Armor.ExampleCostume>());
		}*/

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