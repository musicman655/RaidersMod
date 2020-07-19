using Terraria.ID;
using Terraria.ModLoader;

namespace RaidersMod.Items.weapons
{
	public class IntrepetusBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("IntrePetus Bow");
			Tooltip.SetDefault("a mythril bow that shoots fast");
		}
		public override void SetDefaults()
		{
			item.damage = 75;
			item.ranged = true;
			item.width = 45;
			item.height = 45;
			item.useTime = 15;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.knockBack = 4;
			item.value = 000050;
			item.rare = 8;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.useAmmo = AmmoID.Arrow;
			item.shoot = 2;
			 item.shootSpeed = 15f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MythrilBar, 20);
			recipe.AddIngredient(ItemID.SoulofNight, 30);
			recipe.AddIngredient(ItemID.SoulofMight, 15);
			recipe.AddIngredient(ItemID.SoulofFright, 10);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
