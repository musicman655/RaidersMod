using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RaidersMod.NPCs
{
    public class Impetum_Soldier : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Impetum Soldier");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime];
        }
        public override void SetDefaults()
        {
            npc.width = 54;
            npc.height = 42;
            npc.damage = 12;
            npc.defense = 0;
            npc.lifeMax = 90;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 100f;
            npc.knockBackResist = 0.3f;
            npc.aiStyle = 1;
            npc.alpha = 60;
            aiType = NPCID.BlueSlime;
            animationType = NPCID.BlueSlime;
        }
        private int MaxAttackTimer = 0;
        private int Bruh = Main.rand.Next(3);
        private string GunTex;
        public override void AI()
        {
            npc.ai[0]++;
            switch (Bruh)
            { 
                case 0 :
                MaxAttackTimer = 14;
                GunTex = "NPCs/SlimeGun1";
                break;
                case 1 :
                MaxAttackTimer = 40;
                GunTex = "NPCs/SlimeGun2";
                break;
                case 2 : 
                MaxAttackTimer = 70;
                GunTex = "NPCs/SlimeGun3";
                break;
            }
            if(npc.ai[0] % MaxAttackTimer == 0)
            {
                if(Bruh != 2)
                    Projectile.NewProjectile(npc.Center, Vector2.Normalize(Main.player[npc.target].Center - npc.Center) * 10, ProjectileID.BulletSnowman, 6, 0.2f);
                else
                {
                    int numberProjectiles = 4 + Main.rand.Next(2);
			        for (int i = 0; i < numberProjectiles; i++)
			        {
				        Vector2 perturbedSpeed = Vector2.Normalize(Main.player[npc.target].Center - npc.Center).RotatedByRandom(MathHelper.ToRadians(30)) * 6; // 30 degree spread.
				        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, perturbedSpeed.X, perturbedSpeed.Y,ProjectileID.BulletSnowman, 10, 0.2f);
			        }
                }
            } 
        }
        
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            float getRotation = (Main.player[npc.target].Center - npc.Center).ToRotation();
            Texture2D texture = mod.GetTexture(GunTex);
            if(Math.Abs(getRotation) < Math.PI/2)
            {
                npc.ai[3] = -1;
            }
            else
            {
                npc.ai[3] = 1;
            }
            Main.spriteBatch.Draw(texture, npc.Center - Main.screenPosition, new Rectangle(0,0,texture.Width,texture.Height), Color.White, getRotation, new Rectangle(0, 0, texture.Width, texture.Height).Size() / 2, npc.scale, npc.ai[3] == -1 ? SpriteEffects.None : SpriteEffects.FlipVertically, 0);
        }
        public override void NPCLoot()
        {
            Item.NewItem(npc.Center,npc.getRect().Size(),ItemID.Gel,Main.rand.Next(10));
        }
    }
}
