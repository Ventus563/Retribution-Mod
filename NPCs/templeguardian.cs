using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Retribution;

namespace Retribution.NPCs
{
	public class templeguardian : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Temple Guardian");
		}

		public override void SetDefaults()
		{
			npc.width = 110;
			npc.height = 106;
			npc.damage = 100000;
			npc.defense = 100000;
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return !NPC.downedPlantBoss ? SpawnCondition.JungleTemple.Chance * 1f : 0f;
		}

        public override void AI()
        {
			npc.rotation += 0.3f;
        }
    }
}
