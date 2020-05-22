using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
namespace RaidersMod.NPCs
{
    public class Clam : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Clam");
            Main.npcFrameCount[npc.type] = 6;
        }
        public override void SetDefaults()
        {
            npc.defense = 5;
            npc.damage = 35;
            npc.aiStyle = 25;
            npc.friendly = false;
            npc.HitSound = SoundID.NPCHit48;
            npc.DeathSound = SoundID.NPCDeath1;
            animationType = NPCID.Mimic;
            npc.lifeMax = 200;
            npc.knockBackResist = 10f;
            npc.width = 42;
            npc.height = 38;
            aiType = NPCID.Mimic;
            npc.knockBackResist = 0.8f;
            npc.value = 100f;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if(spawnInfo.player.ZoneBeach)
            {
                if(Main.dayTime)
                {
                    return 0.4f;
                } 
                else return 0.2f;
                
            }
            else return 0f;
        }
    }
}