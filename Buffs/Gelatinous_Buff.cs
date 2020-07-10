using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace RaidersMod.Buffs
{
    public class Gelatinous_Buff : ModBuff
    {
        public override void SetDefaults() {
			DisplayName.SetDefault("Gelatinous Helicopter");
			Description.SetDefault("A Gelatinous Helicopter will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Items.projectiles.Minions.Gelatinous_Drone>()] > 0) {
				player.buffTime[buffIndex] = 18000;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
    }
}