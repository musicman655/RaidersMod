using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using System.IO;
namespace RaidersMod.Items.projectiles.Minions
{
    public class Gelatinous_Drone : ModProjectile
    {
        protected int AttackTimer = 0;
		protected int npcAE = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gelatinous Drone");
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
            Main.projFrames[projectile.type] = 2;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.Homing[projectile.type] = true;
        }
        public override void SetDefaults()
        {
            projectile.width = 18;
		projectile.height = 28;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = 1f;
            projectile.penetrate = -1;
            projectile.scale *= 1.2f;
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
			if (player.dead || !player.active) {
				player.ClearBuff(ModContent.BuffType<Buffs.Gelatinous_Buff>());
			}
			if (player.HasBuff(ModContent.BuffType<Buffs.Gelatinous_Buff>())) {
				projectile.timeLeft = 2;
			}
			
            Vector2 idlePosition = player.Center;
			idlePosition.Y -= 48f;

            float minionPositionOffsetX = (10 + projectile.minionPos * 40) * -player.direction;
			idlePosition.X += minionPositionOffsetX; // Go behind the player
            //Thanks Example Mod

			// Teleport to player if distance is too big
			Vector2 vectorToIdlePosition = idlePosition - projectile.Center;
			float distanceToIdlePosition = vectorToIdlePosition.Length();
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 2000f) {
				projectile.position = idlePosition;
				projectile.velocity *= 0.1f;
				projectile.netUpdate = true;
			}

            float distanceFromTarget = 700f;
			Vector2 targetCenter = projectile.position;
			bool foundTarget = false;

			if (player.HasMinionAttackTargetNPC) {
				NPC npc = Main.npc[player.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, projectile.Center);
				if (between < 2000f) {
					distanceFromTarget = between;
					targetCenter = npc.Center;
					foundTarget = true;
				}
			}
            if(!foundTarget)
            {
                for(int i = 0;i<Main.maxNPCs;i++)
                {
                    NPC npc = Main.npc[i];
                    if (npc.CanBeChasedBy()) {
						bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);

						if (npc.active && !npc.friendly && Vector2.Distance(projectile.Center,npc.Center) < 350 && lineOfSight) {
							distanceFromTarget = Vector2.Distance(projectile.Center,npc.Center);
							targetCenter = npc.Center;
							foundTarget = true;
							npcAE = npc.whoAmI;
						}
					}
                }
            }
            projectile.friendly = foundTarget;

            float speed = 8f;
			float inertia = 20f;
			if (foundTarget) {
				if (distanceFromTarget < 350) {
				NPC npc = Main.npc[npcAE];
				Vector2 targetPos = Vector2.Normalize(npc.Center - projectile.Center) * 10;
				projectile.spriteDirection = npc.position.X > projectile.position.X ? 1 : -1;
                if(++AttackTimer >= 6){
                Projectile.NewProjectile(projectile.Center,targetPos,ProjectileID.Bullet,30,1.5f,projectile.whoAmI);
                AttackTimer = 0;
                }
				}
			}
			else {
                AttackTimer = 0;
                projectile.spriteDirection = projectile.direction;
				if (distanceToIdlePosition > 400f) {
					// Speed up the minion if it's away from the player
					speed = 16f;
					inertia = 10f;
				}
				else {
					// Slow down the minion if closer to the player
					speed = 8f;
					inertia = 20f;
				}
				if (distanceToIdlePosition > 20f) {
					// The immediate range around the player (when it passively floats about)

					// This is a simple movement formula using the two parameters and its desired direction to create a "homing" movement
					vectorToIdlePosition.Normalize();
					vectorToIdlePosition *= speed;
					projectile.velocity = (projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
                    projectile.rotation = projectile.velocity.ToRotation() / 30;
				}
				else if (projectile.velocity == Vector2.Zero) {
					// If there is a case where it's not moving at all, give it a little "poke"
					projectile.velocity.X = -0.15f;
					projectile.velocity.Y = -0.05f;
				}
			}
            if(++projectile.frameCounter > 3)
            {
                projectile.frame++;
                if(projectile.frame > 1) projectile.frame = 0;
            }
        }
    }
}
