using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace RaidersMod.Items.projectiles
{
    public class SlimeFeather_Projectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slime Feather");
        }
        public override void SetDefaults()
        {
            projectile.Size = new Microsoft.Xna.Framework.Vector2(15);
            projectile.scale *= 0.7f;
            projectile.damage = 25;
            projectile.knockBack = 1;
            projectile.aiStyle = -1;
            projectile.tileCollide = true;
            projectile.timeLeft = 1200;
            projectile.ignoreWater = false;
            projectile.penetrate = 2;
            projectile.ranged = true;
            projectile.friendly = true;
            
        }
        public override void AI()
        {
            projectile.velocity.X += 0.008f;
            projectile.rotation = projectile.velocity.ToRotation();
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if(!target.friendly)
            {
                target.AddBuff(BuffID.Slow,600,false);
            }
        }
    }
}
