using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
namespace RaidersMod.Mounts
{
    public class HelicopterMount : ModMountData
    {
        public override void SetDefaults()
        {
			mountData.buff = ModContent.BuffType<Buffs.HelicopterMountBuff>();
            mountData.spawnDust = DustID.Fire;
			mountData.fallDamage = 0.5f;
			mountData.acceleration = 0.19f;
			mountData.jumpSpeed = 6f;
            mountData.dashSpeed = 8;
            mountData.heightBoost = 5;
            mountData.runSpeed = 4;
            mountData.jumpHeight = 12;
            mountData.blockExtraJumps = true;
            mountData.totalFrames = 3;
            int[] array = new int[mountData.totalFrames];
			for (int l = 0; l < array.Length; l++) {
				array[l] = 5;
			}
            mountData.flightTimeMax = 1200;
            mountData.fatigueMax = 1200;
            mountData.flyingFrameCount = 3;
            mountData.flyingFrameDelay = 5;
            mountData.heightBoost = 16;
            mountData.idleFrameCount = 3;
            mountData.idleFrameDelay = 5;
            mountData.idleFrameStart = 0;
            mountData.standingFrameCount = 0;
            mountData.standingFrameDelay = 0;
            mountData.standingFrameStart = 0;
            mountData.inAirFrameCount = 3;
            mountData.inAirFrameDelay = 5;
            mountData.inAirFrameStart = 0;
            mountData.runningFrameCount = 3;
            mountData.runningFrameDelay = 0;
            mountData.runningFrameStart = 0;
            mountData.swimFrameCount = 3;
            mountData.swimFrameDelay = 0;
            mountData.swimFrameStart = 0;
            mountData.dashingFrameCount = 3;
            mountData.dashingFrameDelay = 0;
            mountData.dashingFrameStart = 0;
            mountData.dashSpeed = 12;
            mountData.xOffset = -8;
            mountData.yOffset = 1;
            mountData.playerYOffsets = array;
            mountData.idleFrameLoop = true;
            mountData.usesHover = true;
            mountData.bodyFrame = 2;

            if (Main.netMode == NetmodeID.Server) {
				return;
			}

			mountData.textureWidth = mountData.backTexture.Width + 20;
			mountData.textureHeight = mountData.backTexture.Height;
        }
        int e = 0;
        public override void UseAbility(Player player, Vector2 mousePosition, bool toggleOn)
        {
            if(Main.mouseLeft)
            {
                if(++e % 7 == 0)
                {
                    Vector2 shootPos = Vector2.Normalize(Main.MouseWorld - player.Center) * 8;
                    Projectile.NewProjectile(player.Center,shootPos,ProjectileID.Bullet,12,1f);
                }
            }
        }
    }
}