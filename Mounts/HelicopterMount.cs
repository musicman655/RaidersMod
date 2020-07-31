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
		mountData.fallDamage = 0.5f;
		mountData.acceleration = 0.19f;
		mountData.jumpSpeed = 6f;
            mountData.dashSpeed = 12;
            mountData.heightBoost = 5;
            mountData.runSpeed = 12;
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
            mountData.standingFrameCount = 3;
            mountData.standingFrameDelay = 5;
            mountData.standingFrameStart = 0;
            mountData.inAirFrameCount = 3;
            mountData.inAirFrameDelay = 5;
            mountData.inAirFrameStart = 0;
            mountData.runningFrameCount = 3;
            mountData.runningFrameDelay = 5;
            mountData.runningFrameStart = 0;
            mountData.swimFrameCount = 3;
            mountData.swimFrameDelay = 0;
            mountData.swimFrameStart = 0;
            mountData.dashingFrameCount = 3;
            mountData.dashingFrameDelay = 5;
            mountData.dashingFrameStart = 0;
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
        public override void UpdateEffects(Player player)
        {
            RaidersModPlayer.HelicopterMount = true;
        }
        int e = 0;
        public override void UseAbility(Player player, Vector2 mousePosition, bool toggleOn)
        {
            if(Main.mouseLeft)
            {
                if(++e % 7 == 0)
                {
                    Vector2 shootPos = Vector2.Normalize(Main.MouseWorld - player.Center) * 8;
                    Projectile.NewProjectile(player.Center,shootPos,ProjectileID.Bullet,16,1f,player.whoAmI);
                }
            }
        }
    }
}
