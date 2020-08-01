using Terraria.ID;
using Terraria.ModLoader;

namespace RaidersMod.Items.weapons
{
	public class ColdSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cold Sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("A frigid blade that shoots ice bolts");
		}
		public override void SetDefaults()
		{

			item.damage = 15;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 000010;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ProjectileID.IceBolt;
			item.shootSpeed = 7f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LeadBar, 30);
			recipe.AddIngredient(ItemID.IceBlock, 50);
			recipe.AddIngredient(ItemID.SnowBlock, 80);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		    recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar, 30);
			recipe.AddIngredient(ItemID.IceBlock, 50);
			recipe.AddIngredient(ItemID.SnowBlock, 80);	
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
			public override void OnHitNPC(Terraria.Player player , Terraria.NPC target , int damage, float KnockBack, bool crit) 
		{
			target.AddBuff(BuffID.Frozen,350);//Adds the debuff,second argument = amount of frames
		}
	}
}
