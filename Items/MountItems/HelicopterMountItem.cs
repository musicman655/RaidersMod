using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace RaidersMod.Items.MountItems
{
    public class HelicopterMountItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Helicopter Mount");
        }
        public override void SetDefaults()
        {
            item.width = 20;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 30000;
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item79;
			item.noMelee = true;
			item.mountType = ModContent.MountType<Mounts.HelicopterMount>();
        }
    }
}