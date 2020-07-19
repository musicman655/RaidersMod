using Terraria.ID;
using Terraria.ModLoader;

namespace RaidersMod.Items.weapons
{
	public class PlanitiumBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Planitium Bow");
			Tooltip.SetDefault("the jungle bow");
		}
		public override void SetDefaults()
		{
			item.damage = 16;
			item.ranged = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 15;
			item.useAnimation = 35;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 000015;
			item.rare = 2;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.useAmmo = AmmoID.Arrow;
			item.shoot = 1;
			 item.shootSpeed = 10f;
		}
    }
}        
