using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RaidersMod.Items.weapons
{
	public class StingingSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Stinging Sword"); 
		}

		public override void SetDefaults() 
		{
			item.damage = 16;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 8;
			item.useAnimation = 8;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = Item.buyPrice(0, 0, 78, 0);
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Stinger, 10);
			recipe.AddIngredient(ItemID.RichMahogany, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}