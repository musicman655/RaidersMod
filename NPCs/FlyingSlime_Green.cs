using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
namespace RaidersMod.NPCs
{
    public class FlyingSlime_Green : ModNPC
    {
             public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flying Slime");
            Main.npcFrameCount[npc.type] = 4;
        }
        public override void SetDefaults()
        {
            npc.lifeMax = Main.expertMode ? 84 : 42;
            npc.defense = Main.expertMode ? 25 : 18;
            npc.knockBackResist = 0.016f;
            npc.width = 20;
            npc.height = 24;
            npc.dontTakeDamageFromHostiles = true;
            npc.damage = Main.expertMode ? 30 : 70;
            npc.aiStyle = -1;
            npc.friendly = false;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 100f;
            npc.noGravity = true;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if(spawnInfo.player.ZoneSkyHeight && Main.hardMode)
            {
                return 0.08f;
            } else return 0f;
        }

        private float Attackcounter;
        public override void AI()
        {
            npc.TargetClosest(true);
            Attackcounter++;
            Player player = Main.player[npc.target];
            if(  npc.target < 0 || npc.target == 255 || player.dead)
            {
                npc.TargetClosest(true);
            }
            npc.velocity = Vector2.Normalize(player.Center - npc.Center) * 4.1f;  

            if(Attackcounter >= 360)
            {
                Vector2 direction = Vector2.Normalize(player.Center - npc.Center) * 5f;
                Projectile.NewProjectile(npc.Center,direction * 2,ProjectileID.HarpyFeather,23,1);
                Attackcounter = 0f;
            }
            npc.spriteDirection = npc.direction;
        }
        private int FrameTimer;
        private int frameCount;
     public override void FindFrame(int frameHeight)
    {
        if(++FrameTimer > 8)
        {
            frameCount++;
            if(frameCount == 4) frameCount = 0;
            FrameTimer = 0;
        }
        npc.frame.Y = frameHeight * frameCount;
    }
       public override void NPCLoot()
       {
        Item.NewItem(npc.position,ModContent.ItemType<Items.craftingMaterials.SlimeFeather>(),Main.rand.Next(5,10));
       }
    }
}
