using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
namespace RaidersMod.Items.projectiles
{
    public class SpikeySpike : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spikey Spike");
        }
        public override void SetDefaults()
        {
            projectile.damage = 10;
            projectile.Size = new Microsoft.Xna.Framework.Vector2(15);
            projectile.tileCollide = true;
            projectile.timeLeft = 200;
            projectile.penetrate = 2;
            projectile.aiStyle = -1;
            projectile.ranged = true;
            projectile.ignoreWater = false;
            projectile.friendly = true;
        }
        public override void AI()
        {
            projectile.velocity *= 1.1f;
            projectile.rotation = projectile.velocity.ToRotation();
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (!target.friendly)
            {
                target.AddBuff(BuffID.Bleeding,30,false);
            }
        }
    }
}