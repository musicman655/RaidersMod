using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace RaidersMod.Items.projectiles
{
	public class SpikeySpike : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spikey Spike"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}
		public override void SetDefaults()
		{

			projectile.damage = 15;
			projectile.melee = true;
			projectile.width = 15;
			projectile.height = 20;
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 500;
            projectile.light = 0;
            projectile.ignoreWater = false;
			projectile.knockBack = 2;
			projectile.aiStyle = -1;
        }
         public override void AI()
        {
			projectile.velocity.X = projectile.velocity.X;
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y,(double)projectile.velocity.X) + 2f;
			projectile.velocity.Y = ran.Next(-1,1);
        }    
    }
}        
