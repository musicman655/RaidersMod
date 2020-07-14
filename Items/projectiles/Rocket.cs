using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
namespace RaidersMod.Items.projectiles
{
    public class Rocket : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Impetum Rocket");
        }
        public override void SetDefaults()
        {
            projectile.height = projectile.width = 20;
            projectile.timeLeft = 660;
            projectile.damage = 45;
            projectile.knockBack = 3f;
            projectile.tileCollide = true;
            projectile.hostile = true;
            projectile.aiStyle = -1;
            projectile.ranged = true;
        }
        public override void AI()
        {
            Player player = Main.player[Main.myPlayer];
            projectile.velocity = Vector2.Normalize(player.Center - projectile.Center) * 8; 
            projectile.rotation = projectile.velocity.ToRotation();
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            projectile.Kill();
        }
        public override void PostAI()
        {
            Dust.NewDust(projectile.Center,15,15,DustID.FlameBurst,-projectile.velocity.X,0,0,default(Color),1.2f);
        }
        public override void Kill(int timeLeft)
        {
            Dust dust;
            Main.PlaySound(SoundID.Item14, (int)projectile.Center.X, (int)projectile.Center.Y);
            for(int i = 0;i<10;i++)
            {
                if (Main.rand.NextFloat() < 0.9f)
					{
						dust = Main.dust[Terraria.Dust.NewDust(projectile.Center, 78, 78, 6, 0f, 0.5263162f, 0, new Color(255, 0, 0), 4.539474f)];
						dust.noGravity = true;
						dust.fadeIn = 2.5f;
					}

					//Dust 2
					if (Main.rand.NextFloat() < 0.6f)
					{
    					dust = Main.dust[Terraria.Dust.NewDust(projectile.Center, 78, 78, 203, 0f, 0f, 0, new Color(255, 255, 255), 3.026316f)];
						dust.noGravity = true;
						dust.noLight = true;
					}

					//Dust 3
					if (Main.rand.NextFloat() < 0.3f)
					{
						dust = Main.dust[Terraria.Dust.NewDust(projectile.Center, 100, 100, 31, 0f, 0f, 0, new Color(255, 255, 255), 5f)];
						dust.noGravity = true;
						dust.noLight = true;
					}
            }
        }
    }
}