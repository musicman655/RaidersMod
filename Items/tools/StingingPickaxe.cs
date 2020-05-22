using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace RaidersMod.Items.tools
{
	public class StingingPickaxe : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 10;
			item.width = 32;
			item.height = 32;
			item.useTime = 6;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.knockBack = 3.25f;
			item.value = Item.buyPrice(0, 0, 85, 0);
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.melee = true;

			item.pick = 30;
		}
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Stinger, 12); //modded materials
            recipe.AddIngredient(ItemID.RichMahogany, 10); //modded materials
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
