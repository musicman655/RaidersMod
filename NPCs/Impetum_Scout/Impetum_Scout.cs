using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using System.IO;
using System;
namespace RaidersMod.NPCs.Bosses.Impetum_Scout
{
    [AutoloadBossHead]
    public class Impetum_Scout : ModNPC
    {
        public override string BossHeadTexture => "RaidersMod/NPCs/Bosses/Impetum_Scout/Impetum_Scout_Map_Icon";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Impetum Scout");
            Main.npcFrameCount[npc.type] = 5;
        }
        public override void SetDefaults()
        {
            
            npc.aiStyle = -1;
            npc.lifeMax = 8500;
            npc.damage = 30;
            npc.defense = 8;
            npc.knockBackResist = 0.1f;
            npc.width = 82;
            npc.height = 46;
            npc.dontTakeDamageFromHostiles = true;
            npc.friendly = false;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = Item.buyPrice(0,1,Main.rand.Next(20,50),Main.rand.Next(20,100));
            npc.noGravity = true;
            npc.boss = true;
            npc.noTileCollide = true;
        }
        private float AttackTimer = 0;
        private float ServantSpawnTimer = 0;
        private float DirectionChangeTimer = 0;
        private int[] ServantNPC = {NPCType<FlyingSlime_Blue>(),NPCType<FlyingSlime_Green>(),NPCType<FlyingSlime_Purple>(),NPCType<Impetum_Soldier>(),NPCType<FlyingSlime_Pinky>()};
        private int ServantSpawnCount;
        private int position = 1;
        public override void AI()
        {
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            if(player.dead || !player.active || npc.target < 0 || npc.target == 255)
            {
                npc.TargetClosest(true);
            }
            if(npc.HasValidTarget)
            {
            int Yposition = (int)player.Center.Y - 250;
            if(++ServantSpawnTimer >= 300)
            {
                ServantSpawnCount = Main.rand.Next(1,3);
                int NPCToSpawn = Main.rand.Next(50) > 46 ? NPCType<FlyingSlime_Pinky>() : Main.rand.Next(ServantNPC);
                for(int i = 0;i<ServantSpawnCount;i++)
                {
                    NPC.NewNPC((int)npc.Center.X - Main.rand.Next(-100,100),(int)npc.Center.Y - Main.rand.Next(-100,100),NPCToSpawn);
                }
                ServantSpawnTimer = 0;
            }
            if(++AttackTimer >= 360)
            {
                if(!Main.expertMode)
                {
                    if(npc.life < npc.lifeMax * 0.5f)
                    {
                        Vector2 ae = Main.player[npc.target].Center - npc.Center;
                        for(int j = 0;j<60;j++)
                        {
                            if(j%6 == 0)
                                Projectile.NewProjectile(npc.Center,ae * 10,ProjectileID.BulletSnowman,16,2);
                        }
                    }
                } else 
                {
                    Vector2 ae = Main.player[npc.target].Center - npc.Center;
                    for(int j = 0;j<60;j++)
                    {
                        if(j%6 == 0)
                            Projectile.NewProjectile(npc.Center,ae * 10,ProjectileID.BulletSnowman,16,2);
                    }
                }
                if(AttackTimer >= 600)
                {
                    Projectile.NewProjectile(npc.Center,Vector2.Normalize(player.Center - npc.Center) * 8,ProjectileType<Items.projectiles.Rocket>(),10,2);
                    AttackTimer = 0;
                }
            }
            npc.position.Y = Yposition - ((float)Math.Sin(Main.GlobalTime * 4) * 15);
            npc.velocity.Y = Vector2.Normalize(new Vector2(0,Yposition) - npc.Center).Y * 6;
            if(++DirectionChangeTimer >= 240)
            {
                position = position == 1 ? -1 : 1;
                DirectionChangeTimer = 0;
            }
            Vector2 Xposition1 = player.position - new Vector2(450 * position,160);
            npc.velocity.X = Vector2.Normalize(Xposition1 - npc.Center).X * 11;

            } else
            {
                npc.velocity.Y -= 1;
                npc.timeLeft = 30;
            }
        }
        private int frameCount;
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = -npc.direction;
            if(++npc.frameCounter >= 6)
            {
            frameCount++;
            if(frameCount == 4) frameCount = 0;
            npc.frameCounter = 0;
            }
            npc.frame.Y = frameHeight * frameCount;
        }
        public override void NPCLoot()
        {
            if(Main.rand.Next(10) == 9)
            {
                Item.NewItem(npc.position,new Vector2(npc.width,npc.height),ItemType<Items.weapons.Gelatinous_Remote>());
            }
            if(Main.rand.Next(3) == 2)
            {
                Item.NewItem(npc.position,new Vector2(npc.width,npc.height),ItemType<Items.weapons.SlimeRifle>());
            }
        }
    }
}
/*Impetum scout (Slime Helicopter Rework thingy)
8500/12500 HP 
He Flies in right and left always up of the player something like he goes right for a while until he starts moving to left. He will always be above the player
Attacks:
Slimes Falling:While he is flying every 5 seconds he throws a random impetum Soldier Or a Flying Slime
At 50% it will start shooting lots of bullets during 5 seconds and then stop during 10 seconds (like a minigun or something like that)(100% in expert)
at 25% he will start shoting homing rockets at the player every 10 seconds(50% in expert)*/