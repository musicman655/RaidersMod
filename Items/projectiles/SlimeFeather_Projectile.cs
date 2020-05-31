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
            projectile.damage = 24;
            projectile.knockBack = 1;
            projectile.aiStyle = -1;
            projectile.tileCollide = true;
            projectile.timeLeft = 1200;
            projectile.ignoreWater = false;
            projectile.penetrate = 3;
            projectile.ranged = true;
        }
        public override void AI()
        {
            projectile.velocity.X += 0.008f;
            projectile.rotation = projectile.velocity.ToRotation();
        }
        
    }
}