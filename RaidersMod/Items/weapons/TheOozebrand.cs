using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RaidersMod.Items.weapons
{
	public class TheOozebrand : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("the oozebrand");
            Tooltip.SetDefault("The last resort of the living slimy machinery"); 
		}

		public override void SetDefaults() 
		{
			item.damage = 45;
			item.melee = true;
			item.width = 45;
			item.height = 45;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = Item.buyPrice(0, 0, 50, 0);
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
        }
    }
}