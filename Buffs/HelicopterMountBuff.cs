using Terraria;
using Terraria.ModLoader;
namespace RaidersMod.Buffs
{
    public class HelicopterMountBuff : ModBuff
    {
        public override void SetDefaults() {
			DisplayName.SetDefault("Helicopter");
			Description.SetDefault("haha helicopter go SHOOOT");//yogurt set the buff description here
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) 
        {
			player.mount.SetMount(ModContent.MountType<Mounts.HelicopterMount>(), player);
			player.buffTime[buffIndex] = 10;
		}
    }
}