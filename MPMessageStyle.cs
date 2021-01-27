using System;

namespace Retribution
{
	public enum MPMessageStyle : byte
	{
		SyncNPCAI0,
		SyncNPCPosition,
		SyncNPCAIPlayer,
		SyncRetributionPlayer,
		ProjectileHitNPC,
		ItemHitNPC,
		NetNPCSpawnedFromStatue,
		NPCSpawnOnPlayer
	}
}
