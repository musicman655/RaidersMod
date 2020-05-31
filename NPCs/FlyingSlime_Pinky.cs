using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
namespace RaidersMod.NPCs.Spiker
{
    public class FlyingSlime_Pinky : ModNPC
    {
        public override string Texture => "RaidersMod/NPCs/FlyingSlime_Pinky";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flying Pinky");
            Main.npcFrameCount[npc.type] = 4;
        }
        public override void SetDefaults()
        {
            npc.lifeMax = Main.expertMode ? 500 : 250;
            npc.defense = Main.expertMode ? 25 : 15;
            npc.knockBackResist = 0.15f;
            npc.width = 20;
            npc.height = 24;
            npc.dontTakeDamageFromHostiles = true;
            npc.damage = Main.expertMode ? 150 : 50;
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
                return 0.02f;
            } else return 0f;
        }

        private float Attackcounter
        {
            get => npc.ai[0];
            set => npc.ai[0] = value;
        }
        public override void AI()
        {
            
            npc.TargetClosest(true);
            
            if(  npc.target < 0 || npc.target == 255 ||Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }
            if(Attackcounter < 600)
            {
                MoveTowards(npc,Main.player[npc.target].Center,6,0.02f);
               
            }
            Player target = Main.player[npc.target];
            
            if(Attackcounter >= 600)
            {
                Vector2 direction = (target.Center - npc.Center).SafeNormalize(Vector2.UnitX);
                Projectile.NewProjectile(npc.position,direction,ProjectileID.HarpyFeather,23,1f,npc.type,0,0);
                Attackcounter = 0f;
            }
       
        }
    private void MoveTowards(NPC npc,Vector2 playerTarget,float speed,float turnResistence)
    {
        var move = playerTarget - npc.Center;
        float length = move.Length();
        if(length > speed)
        {
            move *= speed / length;
        }
        move = (npc.velocity * turnResistence + move) / (turnResistence + 1);
        length = move.Length();
        if(length > speed)
        {
            move *= speed / length;
        }
        npc.velocity = move;
    } 
     public override void FindFrame(int frameHeight)
    {
        int frame_State_1 = 0;
        int frame_state_2 = 1;
        int frame_state_3 = 2;
        int frame_state_4 = 3;
        npc.spriteDirection = npc.direction;
        npc.frameCounter++;
        if(npc.frameCounter < 5)
        {
            npc.frame.Y = frame_State_1 * frameHeight;
        }
        else if(npc.frameCounter < 15)
        {
            npc.frame.Y = frame_state_2 * frameHeight;
        }
        else if (npc.frameCounter < 25)
        {
            npc.frame.Y = frame_state_3 * frameHeight;
        }
        else if (npc.frameCounter < 35)
        {
            npc.frame.Y = frame_state_4 * frameHeight;
            npc.frameCounter = 0;
        }
       
    }
       public override void NPCLoot()
    {
        if(Main.rand.Next(1,25) > 23)
        {
                Item.NewItem(npc.position,ModContent.ItemType<Items.weapons.SlimeRifle>());   
        }
 
        Item.NewItem(npc.position,ModContent.ItemType<Items.craftingMaterials.SlimeFeather>(),Main.rand.Next(7,11));
    }
    }
}