using Terraria.ID;
using Terraria.ModLoader;

namespace RaidersMod.Items.weapons
{
	public class FrostyBreath : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frosty Breath");
			Tooltip.SetDefault("a cold bow that can be useful for fights");
		}
		public override void SetDefaults()
		{
			item.damage = 60;
			item.ranged = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 15;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.knockBack = 2;
			item.value = 000035;
			item.rare = 7;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.useAmmo = AmmoID.Arrow;
			item.shoot = 2;
			 item.shootSpeed = 10f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IceBlock, 50);
			recipe.AddIngredient(ItemID.Diamond, 15);
			recipe.AddIngredient(ItemID.IronBar, 35);
			recipe.AddIngredient(ItemID.SnowBlock, 85);
			recipe.AddIngredient(ItemID.IceBow, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IceBlock, 50);
			recipe.AddIngredient(ItemID.Diamond, 15);
			recipe.AddIngredient(ItemID.LeadBar, 35);
			recipe.AddIngredient(ItemID.SnowBlock, 85);
			recipe.AddIngredient(ItemID.IceBow, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
